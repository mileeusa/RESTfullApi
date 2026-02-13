using dotnet_etcd.interfaces;
using Etcdserverpb;

namespace EtcdImpl.services
{
    // Helper to release lock on Dispose
    public class EtcdLockRelease : IDisposable
    {
        private readonly IEtcdClient _client;
        private readonly long _leaseId;

        public EtcdLockRelease(IEtcdClient client, long leaseId)
        {
            _client = client;
            _leaseId = leaseId;
        }

        public void Dispose()
        {
            _client.LeaseRevoke(new LeaseRevokeRequest { ID = _leaseId });
        }
    }
}
