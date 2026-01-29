using dotnet_etcd.interfaces;
using Etcdserverpb;
using Google.Protobuf;
using Grpc.Core;
using System.Text.Json;

namespace EtcdImpl.services
{
    public class EtcdService : IEtcdService
    {
        private readonly IEtcdClient _client;
        private readonly string _username;
        private readonly string _password;

        // Cache the auth token
        private string _authToken = string.Empty;

        public EtcdService(IEtcdClient client, IConfiguration config)
        {
            _client = client;
            _username = config["Etcd:Username"] ?? "";
            _password = config["Etcd:Password"] ?? "";
        }

        public async Task<T?> GetAsync<T>(string key)
        {
            var headers = await GetHeadersAsync();

            try
            {
                var response = await _client.GetValAsync(key, headers);

                if (string.IsNullOrEmpty(response)) 
                    return default;

                return JsonSerializer.Deserialize<T>(response);
            }
            catch (RpcException ex) when (ex.StatusCode == StatusCode.Unauthenticated)
            {
                // Token expired? Retry once after logging in again
                _authToken = ""; // Clear token
                headers = await GetHeadersAsync(); // Re-login
                var response = await _client.GetValAsync(key, headers);

                return string.IsNullOrEmpty(response) ? default : JsonSerializer.Deserialize<T>(response);
            }
        }

        public async Task PutAsync<T>(string key, T value, int? ttlSeconds = null)
        {
            var json = JsonSerializer.Serialize(value);
            var headers = await GetHeadersAsync();

            if (ttlSeconds.HasValue)
            {
                // Pass headers to LeaseGrant as well if your etcd enforces auth on leases
                var leaseRes = await _client.LeaseGrantAsync(new LeaseGrantRequest { TTL = ttlSeconds.Value }, headers);

                await _client.PutAsync(new PutRequest
                {
                    Key = ByteString.CopyFromUtf8(key),
                    Value = ByteString.CopyFromUtf8(json),
                    Lease = leaseRes.ID
                }, headers);
            }
            else
            {
                await _client.PutAsync(key, json, headers);
            }
        }

        public async Task DeleteAsync(string key)
        {
            var headers = await GetHeadersAsync();
            await _client.DeleteRangeAsync(key, headers);
        }

        public void Watch<T>(string key, Action<T> onUpdate)
        {
            // dotnet-etcd Watch is a blocking call or needs a separate thread/task.
            // In a real service, you usually fire-and-forget this task or manage it via a background service.
            _ = Task.Run(() =>
            {
                _client.Watch(key, response =>
                {
                    foreach (var eventData in response.Events)
                    {
                        if (eventData.Type == Mvccpb.Event.Types.EventType.Put)
                        {
                            var json = eventData.Kv.Value.ToStringUtf8();
                            var data = JsonSerializer.Deserialize<T>(json);
                            onUpdate(data);
                        }
                    }
                });
            });
        }

        public async Task<IDisposable> AcquireLockAsync(string lockKey, int ttlSeconds = 10)
        {
            // Simple distributed lock implementation
            var session = await _client.LeaseGrantAsync(new LeaseGrantRequest { TTL = ttlSeconds });

            // Use a transaction to try and claim the key
            var tx = new TxnRequest();
            tx.Compare.Add(new Compare
            {
                Key = ByteString.CopyFromUtf8(lockKey),
                Target = Compare.Types.CompareTarget.Create,
                CreateRevision = 0 // Revision 0 means key does not exist
            });

            tx.Success.Add(new RequestOp
            {
                RequestPut = new PutRequest
                {
                    Key = ByteString.CopyFromUtf8(lockKey),
                    Value = ByteString.CopyFromUtf8("locked"),
                    Lease = session.ID
                }
            });

            var result = await _client.TransactionAsync(tx);

            if (!result.Succeeded)
            {
                throw new InvalidOperationException("Could not acquire lock");
            }

            // Return a disposable that releases the lock (revokes lease)
            return new EtcdLockRelease(_client, session.ID);
        }

        // Helper to ensure we have a valid token
        private async Task<Metadata> GetHeadersAsync()
        {
            var headers = new Metadata();

            // If no credentials, return empty headers
            if (string.IsNullOrEmpty(_username)) return headers;

            // If we don't have a token yet, authenticate
            if (string.IsNullOrEmpty(_authToken))
            {
                await LoginAsync();
            }

            headers.Add("token", _authToken);
            return headers;
        }

        private async Task LoginAsync()
        {
            var authRequest = new AuthenticateRequest { Name = _username, Password = _password };
            var response = await _client.AuthenticateAsync(authRequest);
            _authToken = response.Token;
        }
    }    
}
