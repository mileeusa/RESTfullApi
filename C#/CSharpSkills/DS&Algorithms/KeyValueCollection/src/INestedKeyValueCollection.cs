using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterfaceInActions.src
{
    public interface INestedKeyValueCollection<TKey, TSubkey, TValue>
    {
        void Add(TKey key, TSubkey subkey, TValue value);
        bool TryGetValue(TKey key, TSubkey subkey, out TValue value);
        IEnumerable<TSubkey> GetSubKeys(TKey key);
        IEnumerable<TValue> GetValues(TKey key);
        bool Remove(TKey key, TSubkey subkey);
        bool Remove(TKey key);
        bool ContainsKey(TKey key);
        bool ContainsKey(TKey key, TSubkey subKey);
        int Count { get; }
        void Clear();
    }
}
