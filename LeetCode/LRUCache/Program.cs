// See https://aka.ms/new-console-template for more information
using LRUCacheInActions.src;

var cache = new ThreadSafeLRUCache<int, string>(3);

cache.Put(1, "One");
cache.Put(2, "Two");
cache.Put(3, "Three");
cache.DisplayCache(); // 3->2->1

cache.Get(2);         // Access 2
cache.DisplayCache(); // 2->3->1

cache.Put(4, "Four"); // Evict 1
cache.DisplayCache(); // 4->2->3