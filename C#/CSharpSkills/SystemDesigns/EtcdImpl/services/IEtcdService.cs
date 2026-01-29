namespace EtcdImpl.services
{
    public interface IEtcdService
    {
        // Basic KV Operations
        Task<T?> GetAsync<T>(string key);
        Task PutAsync<T>(string key, T value, int? ttlSeconds = null);
        Task DeleteAsync(string key);

        // Watch for changes
        void Watch<T>(string key, Action<T> onUpdate);

        // Distributed Locking (Optional but common)
        Task<IDisposable> AcquireLockAsync(string lockKey, int ttlSeconds = 10);
    }
}
