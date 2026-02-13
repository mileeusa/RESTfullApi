using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterfaceInActions.src
{
    public class NestedKeyValueCollection<TKey, TSubkey, TValue> : INestedKeyValueCollection<TKey, TSubkey, TValue>
        where TKey : notnull
        where TSubkey : notnull
    {
        private readonly Dictionary<TKey, Dictionary<TSubkey, TValue>> _data;

        public NestedKeyValueCollection()
        {
            _data = new Dictionary<TKey, Dictionary<TSubkey, TValue>>();
        }

        public int Count => _data.Count;

        public void Add(TKey key, TSubkey subKey, TValue value)
        {
            if (!_data.ContainsKey(key))
            {
                _data[key] = [];
            }
            _data[key][subKey] = value;
        }

        public bool TryGetValue(TKey key, TSubkey subkey, out TValue value)
        {
            value = default!;
            if (_data.TryGetValue(key, out var subDict) && subDict.TryGetValue(subkey, out value))
            {
                return true;
            }
            return false;
        }

        public IEnumerable<TSubkey> GetSubKeys(TKey key)
        {
            if (_data.TryGetValue(key, out var subDict))
            {
                return subDict.Keys;
            }
            return Enumerable.Empty<TSubkey>();
        }

        public IEnumerable<TValue> GetValues(TKey key)
        {
            if (_data.TryGetValue(key, out var subDict))
            {
                return subDict.Values;
            }

            return Enumerable.Empty<TValue>();
        }

        public bool Remove(TKey key, TSubkey subkey)
        {
            if (_data.TryGetValue(key, out var subDict))
            {
                bool removed = subDict.Remove(subkey);
                if (subDict.Count == 0)
                {
                    _data.Remove(key);
                }

                return removed;
            }

            return false;
        }

        public bool Remove(TKey key) => _data.Remove(key);

        public bool ContainsKey(TKey key)
        {
            return _data.ContainsKey(key);
        }

        public bool ContainsKey(TKey key, TSubkey subKey)
            => _data.TryGetValue(key, out var subDict)
            && subDict.ContainsKey(subKey);

        public void Clear() => _data.Clear();
    }
}
