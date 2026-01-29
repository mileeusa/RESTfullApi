namespace LRUCacheInActions.src
{
    public class ThreadSafeLRUCache<TKey, TValue>
    {
        private readonly int _capacity;
        private readonly Dictionary<TKey, LinkedListNode<CacheItem>> _cacheMap;
        private readonly LinkedList<CacheItem> _lruList;
        private readonly object _lock = new object(); // lock object

        public ThreadSafeLRUCache(int capacity)
        {
            if (capacity <= 0) throw new ArgumentException("Capacity must be greater than 0");

            this._capacity = capacity;
            _cacheMap = new Dictionary<TKey, LinkedListNode<CacheItem>>();
            _lruList = new LinkedList<CacheItem>();
        }

        public TValue Get(TKey key)
        {
            lock (_lock)
            {
                if (_cacheMap.TryGetValue(key, out var node))
                {
                    // Move the accessed node to the front
                    _lruList.Remove(node);
                    _lruList.AddFirst(node);
                    return node.Value.Value;
                }

                throw new KeyNotFoundException($"Key '{key}' not found in cache.");
            }
        }

        public void Put(TKey key, TValue value)
        {
            lock (_lock)
            {
                if (_cacheMap.TryGetValue(key, out var node))
                {
                    // Update value and move to front
                    node.Value.Value = value;
                    _lruList.Remove(node);
                    _lruList.AddFirst(node);
                }
                else
                {
                    if (_cacheMap.Count >= _capacity)
                    {
                        // Remove least recently used (tail)
                        var lruNode = _lruList.Last;
                        if (lruNode != null)
                        {
                            _cacheMap.Remove(lruNode.Value.Key);
                            _lruList.RemoveLast();
                        }
                    }

                    var newNode = new LinkedListNode<CacheItem>(new CacheItem(key, value));
                    _lruList.AddFirst(newNode);
                    _cacheMap[key] = newNode;
                }
            }
        }

        public void DisplayCache()
        {
            lock (_lock)
            {
                Console.WriteLine("Cache state (Most -> Least recently used):");
                foreach (var item in _lruList)
                {
                    Console.Write($"[{item.Key}:{item.Value}] ");
                }
                Console.WriteLine();
            }
        }

        private class CacheItem
        {
            public TKey Key { get; }
            public TValue Value { get; set; }

            public CacheItem(TKey key, TValue value)
            {
                Key = key;
                Value = value;
            }
        }
    }
}
