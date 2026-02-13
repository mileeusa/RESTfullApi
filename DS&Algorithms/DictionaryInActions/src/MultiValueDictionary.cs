using System.Collections;

namespace DictionaryInActions.src
{
    public interface IMultiValueDictionary<TKey, TValue> : IEnumerable<KeyValuePair<TKey, TValue>>
    {
        void Add(TKey key, TValue value);
        IEnumerable<TValue> Get(TKey key);
        bool Remove(TKey key, TValue value);
        bool RemoveKey(TKey key);
        void Clear();
        List<KeyValuePair<TKey, TValue>> Flatten();
    }

    public class MultiValueDictionary<TKey, TValue> : IMultiValueDictionary<TKey, TValue> where TKey : notnull
    {
        private readonly Dictionary<TKey, HashSet<TValue>> m_dict = [];

        public void Add(TKey key, TValue value)
        {
            if (m_dict.TryGetValue(key, out var set))
            {
                if (!set.Contains(value))
                {
                    set.Add(value);
                    m_dict[key] = set;
                }
            }
            else
            { 
                set = new HashSet<TValue>();
                set.Add(value);
                m_dict[key] = set;
            }
        }

        public IEnumerable<TValue> Get(TKey key)
        {
            if (!m_dict.TryGetValue(key, out var value))
            {
                return Enumerable.Empty<TValue>();
            }

            return value;               
        }

        public bool Remove(TKey key, TValue value)
        {
            if (m_dict.TryGetValue(key, out var set) && set.Contains(value))
            {
                set.Remove(value);
                if (set.Count == 0)
                {
                    m_dict.Remove(key);
                }
                else
                {
                    m_dict[key] = set;
                }

                return true;
            }

            return false;
        }

        public bool RemoveKey(TKey key)
        {
            return m_dict.Remove(key);
        }

        public void Clear()
        {
            //foreach (var item in m_dic)
            //{
            //    m_dic.Remove(item.Key);
            //}
            m_dict.Clear();
        }

        public List<KeyValuePair<TKey, TValue>> Flatten()
        {
            List<KeyValuePair<TKey, TValue>> lists = [];

            foreach (var item in m_dict)
            {
                var set = item.Value;
                foreach (var value in set)
                {
                    lists.Add(new KeyValuePair<TKey, TValue>(item.Key, value));
                }
            }

            return lists;
        }

        /// 
        /// this is simpler but need to build the list in memory first
        /// 
        //public IEnumerator<KeyValuePair<TKey, TValue>> GetEnumerator() => Flatten().GetEnumerator();

        //public IEnumerator<KeyValuePair<TKey, TValue>> GetEnumerator()
        //{
        //    foreach(var kv in Flatten())
        //    {
        //        // Using yield return avoids creating a separate collection in memory
        //        yield return kv;
        //    }
        //}

        public IEnumerator<KeyValuePair<TKey, TValue>> GetEnumerator()
        {
            foreach (var kv in m_dict)
            {
                TKey key = kv.Key;
                var values = kv.Value;

                foreach (var item in values)
                {
                    yield return new KeyValuePair<TKey, TValue>(key, item);
                }
            }
        }


        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
