using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LRUCacheInActions.src;
using NUnit.Framework;

namespace LRUCacheInActions.UnitTests
{
    [TestFixture] class LRUCacheTests
    {
        [Test]
        public void LRUCache_Test()
        {
            // arrange
            LRUCache lruCache = new LRUCache(2);

            // act
            lruCache.Put(1, 1);
            lruCache.Put(2, 2);
            int result1 = lruCache.Get(1);       // returns 1
            lruCache.Put(3, 3);                  // evicts key 2
            int result2 = lruCache.Get(2);       // returns -1 (not found)
            lruCache.Put(4, 4);                  // evicts key 1
            int result3 = lruCache.Get(1);       // returns -1 (not found)
            int result4 = lruCache.Get(3);       // returns 3
            int result5 = lruCache.Get(4);       // returns 4

            // assert
            Assert.That(result1, Is.EqualTo(1));
            Assert.That(result2, Is.EqualTo(-1));
            Assert.That(result3, Is.EqualTo(-1));
            Assert.That(result4, Is.EqualTo(3));
            Assert.That(result5, Is.EqualTo(4));
        }
    }
}
