using System.Collections;

namespace CollectionInActions.src
{
    public class MyCollectionSync<T> : ICollection<T>
    {
        private readonly HashSet<T> _set = [];
        private readonly object _syncRoot = new ();

        public int Count
        {
            get
            {
                lock (_syncRoot)
                {
                    return _set.Count;
                }
            }
        }

        public bool IsReadOnly => false;

        public void Add(T item)
        {
            lock (_syncRoot)
            {
                _set.Add(item);
            }
        }

        public bool Remove(T item)
        {
            lock (_syncRoot)
            {
                return _set.Remove(item);
            }
        }

        public bool Contains(T item)
        {
            lock (_syncRoot)
            {
                return _set.Contains(item);
            }
        }

        public void CopyTo(T[] array, int index)
        {
            lock (_syncRoot)
            {
                _set.CopyTo(array, index);
            }
        }

        public void Clear()
        {
            lock (_syncRoot)
            {
                _set.Clear();
            }
        }


        // ICollection<T> itself inherits from both of these: IEnumerable<T>, IEnumerable
        // so we must implement both GetEnumerator methods

        // required by IEnumerable<T>
        public IEnumerator<T> GetEnumerator()
        {
            // Enumerator must operate on a snapshot to avoid race conditions
            lock (_syncRoot)
            {
                return new List<T>(_set).GetEnumerator();
            }
        }

        // required by IEnumerable
        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();

        // expose SyncRoot for external code want to perform multi-operation synchronization
        public object SyncRoot => _syncRoot;
    }
}
