using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QueueInActions.src
{
    public class ExpiringQueue<T>
    {
        private readonly Queue<QueueItem> _queue = [];
        private readonly object _lock = new object();

        class QueueItem
        {
            public DateTime ExpirationTime { get; set; }
            public T Value { get; set; }

            public QueueItem(T value, TimeSpan? ttl)
            {
                Value = value;
                ExpirationTime = ttl.HasValue
                    ? DateTime.UtcNow.Add(ttl.Value)
                    : DateTime.MaxValue; // never expires
            }

            public bool IsExpired => DateTime.UtcNow >= ExpirationTime;
        }

        public void Enqueue(T item, TimeSpan? ttl = null)
        {
            lock (_lock)
            {
                _queue.Enqueue(new QueueItem(item, ttl));
            }
        }

        public bool TryDequeue(out T value)
        {
            lock (_lock)
            {
                CleanExpiredItems();

                if(_queue.Count == 0)
                {
                    value = default!;
                    return false;
                }

                value = _queue.Dequeue().Value;
                return true;
            }
        }

        public bool TryPeek(out T value)
        {
            lock (_lock)
            {
                CleanExpiredItems();
                if (_queue.Count == 0)
                {
                    value = default!;
                    return false;
                }

                value = _queue.Peek().Value;
                return true;
            }
        }
        public int Count
        {
            get
            {
                lock (_lock)
                {
                    CleanExpiredItems();
                    return _queue.Count;
                }
            }
        }

        private void CleanExpiredItems()
        {
            while (_queue.Count > 0 && _queue.Peek().IsExpired)
            {
                _queue.Dequeue();
            }
        }
    }
}
