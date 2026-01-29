using System.Collections;
using System.Collections.Concurrent;
using System.Linq.Expressions;

namespace CollectionInActions.src
{
    public class MyCollectionLockFree<T> : ICollection<T> where T : class
    {
        private readonly ConcurrentDictionary<T, byte> _dict = [];

        public int Count => _dict.Count;

        public bool IsReadOnly => false;

        public void Add(T item)
        {
            // TryAdd returns false if already exists, but ICollection<T>.Add ignores that
            _dict.TryAdd(item, 0);
        }

        public bool Remove(T item)
        {
            return _dict.TryRemove(item, out _);
        }

        public bool Contains(T item)
        {
            return _dict.ContainsKey(item);
        }

        public void CopyTo(T[] array, int index)
        {
            foreach (var (key, value) in _dict)
            {
                array[index++] = key;
            }
        }

        public void Clear()
        {
            _dict.Clear();
        }


        // ICollection<T> itself inherits from both of these: IEnumerable<T>, IEnumerable
        // so we must implement both GetEnumerator methods

        // required by IEnumerable<T>
        public IEnumerator<T> GetEnumerator()
        {
            foreach (var (key, value) in _dict)
            {
                yield return key;
            }
        }

        // required by IEnumerable
        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }
}
