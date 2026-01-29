using System.Collections;

namespace CollectionInActions.src
{
    public class MyCollection<T> : ICollection<T>
    {
        private readonly HashSet<T> _set = [];

        public int Count => _set.Count;

        public bool IsReadOnly => false;

        public void Add(T item)
        {
            _set.Add(item);
        }

        public bool Remove(T item)
        {
            return _set.Remove(item);
        }

        public bool Contains(T item)
        {
            return _set.Contains(item);
        }

        public void CopyTo(T[] array, int index)
        {
            _set.CopyTo(array, index);
        }

        public void Clear()
        {
            _set.Clear();
        }


        // ICollection<T> itself inherits from both of these: IEnumerable<T>, IEnumerable
        // so we must implement both GetEnumerator methods

        // required by IEnumerable<T>
        public IEnumerator<T> GetEnumerator()
        {
            return _set.GetEnumerator();
        }

        // required by IEnumerable
        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }
}
