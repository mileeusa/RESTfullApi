using System.Collections;
using System.Linq.Expressions;

namespace CollectionInActions.src
{
    public class MyCollectionReaderWriterLockSlim<T> : ICollection<T>
    {
        private readonly HashSet<T> _set = [];
        private readonly ReaderWriterLockSlim _lock = new(LockRecursionPolicy.NoRecursion);

        public int Count
        {
            get
            {
                _lock.EnterReadLock();

                try
                {
                    return _set.Count;
                }
                finally
                {
                    _lock.ExitReadLock();
                }
            }
        }

        public bool IsReadOnly => false;

        public void Add(T item)
        {
            _lock.EnterWriteLock();

            try
            {
                _set.Add(item);
            }
            finally
            {
                _lock.ExitWriteLock();
            }
        }

        public bool Remove(T item)
        {
            _lock.EnterWriteLock();

            try
            {
                return _set.Remove(item);
            }
            finally
            {
                _lock.ExitWriteLock();
            }
        }

        public bool Contains(T item)
        {
            _lock.EnterReadLock();

            try
            {
                return _set.Contains(item);
            }
            finally
            {
                _lock.ExitReadLock();
            }
        }

        public void CopyTo(T[] array, int index)
        {
            _lock.EnterWriteLock();

            try
            {
                _set.CopyTo(array, index);
            }
            finally
            {
                _lock.ExitWriteLock();
            }
        }

        public void Clear()
        {
            _lock.EnterWriteLock();

            try
            {
                _set.Clear();
            }
            finally
            {
                _lock.ExitWriteLock();
            }
        }


        // ICollection<T> itself inherits from both of these: IEnumerable<T>, IEnumerable
        // so we must implement both GetEnumerator methods

        // required by IEnumerable<T>
        public IEnumerator<T> GetEnumerator()
        {
            // Enumerator must operate on a snapshot to avoid race conditions
            _lock.EnterReadLock();

            List<T> snapshot;

            try
            {
                snapshot = new List<T>(_set);
            }
            finally
            {
                _lock.ExitReadLock();
            }

            return snapshot.GetEnumerator();
        }

        // required by IEnumerable
        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();

        // expose SyncRoot for external code want to perform multi-operation synchronization
        public object SyncRoot => _lock;
    }
}
