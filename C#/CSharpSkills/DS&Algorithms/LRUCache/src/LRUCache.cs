namespace LRUCacheInActions.src
{
    /// <summary>
    /// Represents a fixed-capacity cache that stores key-value pairs and evicts the least recently used items when the
    /// capacity is exceeded.
    /// 
    /// </summary>
    /// <remarks>The LRUCache uses a least recently used (LRU) eviction policy: when the cache reaches its
    /// capacity, the item that has not been accessed for the longest time is removed to make space for new entries.
    /// Accessing or updating an item marks it as most recently used. This class is not thread-safe; external
    /// synchronization is required if used concurrently from multiple threads.</remarks>
    /// 
    /// Key points:
    /// 
    ///   1. Dictionary: Provides O(1) key lookup.
    ///   2. Doubly-linked list: Maintains order of usage(front = most recent, tail = least recent).
    ///   3. O(1) Operations: Both Get and Put are O(1) time complexity.
    ///   4. Eviction Policy: Automatically removes the least recently used item when capacity is exceeded.
    ///   
    /// <typeparam name="TKey">The type of keys in the cache.</typeparam>
    /// <typeparam name="TValue">The type of values stored in the cache.</typeparam>
    /// 
    public class LRUCache
    {
        private readonly int capacity;
        private readonly Dictionary<int, LinkedListNode<CacheItem>> _cacheMap;
        private readonly LinkedList<CacheItem> _lruList;

        public LRUCache(int capacity)
        {
            if (capacity <= 0) throw new ArgumentException("Capacity must be greater than 0");

            this.capacity = capacity;
            _cacheMap = new Dictionary<int, LinkedListNode<CacheItem>>(capacity);
            _lruList = new LinkedList<CacheItem>();
        }

        public int Get(int key)
        {
            if (_cacheMap.TryGetValue(key, out var node))
            {
                // Move the accessed node to the front (most recently used)
                _lruList.Remove(node);
                _lruList.AddFirst(node);
                return node.Value.Value;
            }

            return -1;
        }

        public void Put(int key, int value)
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
                if (_cacheMap.Count >= capacity)
                {
                    // Remove least recently used (tail)
                    var lruNode = _lruList.Last;
                    if (lruNode != null)
                    {
                        _cacheMap.Remove(lruNode.Value.Key);
                        _lruList.RemoveLast();
                    }
                }

                // Add new item to the front
                var newNode = new LinkedListNode<CacheItem>(new CacheItem(key, value));
                _lruList.AddFirst(newNode);
                _cacheMap[key] = newNode;
            }
        }

        public void DisplayCache()
        {
            Console.WriteLine("Cache state (Most -> Least recently used):");
            foreach (var item in _lruList)
            {
                Console.Write($"[{item.Key}:{item.Value}] ");
            }
            Console.WriteLine();
        }

        internal class CacheItem
        {
            public int Key { get; }
            public int Value { get; set; }

            public CacheItem(int key, int value)
            {
                Key = key;
                Value = value;
            }
        }
    }
}
