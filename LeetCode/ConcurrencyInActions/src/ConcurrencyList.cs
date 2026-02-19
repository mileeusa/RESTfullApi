
using System;
using System.Collections.Generic;
using System.Threading;

namespace ConcurrencyInActions.src
{
    public class ConcurrentList<T>
    {
        private readonly List<T> _items = new List<T>();
        private readonly ReaderWriterLockSlim _lock = new();

        // Add an item safely
        public void Add(T item)
        {
            _lock.EnterWriteLock();
            try
            {
                _items.Add(item);
                Console.WriteLine($"[{Thread.CurrentThread.ManagedThreadId}] Added: {item}");
            }
            finally
            {
                _lock.ExitWriteLock();
            }
        }

        // Remove an item safely
        public bool Remove(T item)
        {
            _lock.EnterWriteLock();
            try
            {
                bool removed = _items.Remove(item);
                if (removed)
                    Console.WriteLine($"[{Thread.CurrentThread.ManagedThreadId}] Removed: {item}");
                return removed;
            }
            finally
            {
                _lock.ExitWriteLock();
            }
        }

        // Get a copy safely (to avoid external modification)
        public List<T> GetSnapshot()
        {
            _lock.EnterReadLock();
            try
            {
                return [.. _items];
            }
            finally
            {
                _lock.ExitReadLock();
            }
        }

        public int Count
        {
            get
            {
                _lock.EnterReadLock();
                try
                {
                    return _items.Count;
                }
                finally
                {
                    _lock.ExitReadLock();
                }
            }
        }
    }
}

//class Program
//{
//    static void Main()
//    {
//        var list = new ConcurrentList<int>();
//        var threads = new List<Thread>();

//        // Start multiple threads to add items concurrently
//        for (int i = 0; i < 5; i++)
//        {
//            int threadId = i;
//            var t = new Thread(() =>
//            {
//                for (int j = 0; j < 5; j++)
//                {
//                    list.Add(threadId * 10 + j);
//                    Thread.Sleep(50);
//                }
//            });
//            threads.Add(t);
//            t.Start();
//        }

//        // A reader thread to periodically display list contents
//        var reader = new Thread(() =>
//        {
//            for (int k = 0; k < 10; k++)
//            {
//                var snapshot = list.GetSnapshot();
//                Console.WriteLine($"Snapshot (Count={snapshot.Count}): [{string.Join(", ", snapshot)}]");
//                Thread.Sleep(100);
//            }
//        });

//        reader.Start();

//        // Wait for all writer threads to finish
//        foreach (var t in threads)
//            t.Join();

//        reader.Join();

//        Console.WriteLine($"Final Count = {list.Count}");
//    }
//}

