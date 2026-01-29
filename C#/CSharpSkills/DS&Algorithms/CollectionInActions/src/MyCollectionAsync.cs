using CollectionInActions.model;
using System.Collections;
using System.Linq.Expressions;

namespace CollectionInActions.src
{
    public class MyCollectionAsync<T> : ICollection<T>
    {
        private readonly HashSet<T> _set = [];
        private readonly AsyncReaderWriterLock _lock = new();

        public int Count
        {
            get
            {
                // Synchronous method must block - ICollection<T> requires sync API
                using var _ = _lock.ReaderLockAsync().GetAwaiter().GetResult();
                return _set.Count;
            }
        }

        public bool IsReadOnly => false;


        public void Add(T item)
        {
            using var _ = _lock.WriterLockAsync().GetAwaiter().GetResult();
            _set.Add(item);
        }

        public bool Remove(T item)
        {
            using var _ = _lock.WriterLockAsync().GetAwaiter().GetResult();
            return _set.Remove(item);
        }

        public bool Contains(T item)
        {
            using var _ = _lock.ReaderLockAsync().GetAwaiter().GetResult();
            return _set.Contains(item);
        }

        public void Clear()
        {
            using var _ = _lock.WriterLockAsync().GetAwaiter().GetResult();
            _set.Clear();
        }

        public void CopyTo(T[] array, int index)
        {
            using var _ = _lock.ReaderLockAsync().GetAwaiter().GetResult();
            _set.CopyTo(array, index);
        }
        // ICollection<T> itself inherits from both of these: IEnumerable<T>, IEnumerable
        // so we must implement both GetEnumerator methods

        // required by IEnumerable<T>
        public IEnumerator<T> GetEnumerator()
        {
            List<T> snapshot;

            using (_lock.ReaderLockAsync().GetAwaiter().GetResult())
            {
                snapshot = new List<T>(_set);
            }

            return snapshot.GetEnumerator();
        }

        // required by IEnumerable
        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();

        
        /////////////////// async implementation ////////////////////////
        public async Task AddAsync(T item)
        {
            using var _ = _lock.WriterLockAsync();
            _set.Add(item);
        }

        public async Task<bool> RemoveAsync(T item)
        {
            using var _ = _lock.WriterLockAsync();
            return _set.Remove(item);
        }

        public async Task<bool> ContainsAsync(T item)
        {
            using var _ = _lock.ReaderLockAsync();
            return _set.Contains(item);
        }

        public async Task ClearAsync()
        {
            using var _ = _lock.WriterLockAsync();
            _set.Clear();
        }

        public async Task<T[]> ToArrayAsync()
        {
            using var _ = _lock.ReaderLockAsync();
            return new List<T>(_set).ToArray();
        }

        public async Task<IEnumerable<T>> SnapshotAsync()
        {
            using var _ = _lock.ReaderLockAsync();
            return new List<T>(_set);
        }


        
    }
}
