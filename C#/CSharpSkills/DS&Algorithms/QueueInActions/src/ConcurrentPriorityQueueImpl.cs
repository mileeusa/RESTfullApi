using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QueueInActions.src
{
    public class ConcurrentPriorityQueueImpl<T> where T : IComparable<T>
    {
        private readonly PriorityQueue<T, T>[] queues;
        private readonly object[] locks;
        private readonly int concurrencyLevel;
        private readonly IComparer<T> comparer = Comparer<T>.Default;

        public ConcurrentPriorityQueueImpl(int concurrencyLevel = 4, IComparer<T> comparer = null)
        {
            ArgumentOutOfRangeException.ThrowIfNegative(concurrencyLevel);

            this.concurrencyLevel = concurrencyLevel;

            if (comparer != null)
            {
                this.comparer = comparer;
            }

            queues = new PriorityQueue<T, T>[concurrencyLevel];
            locks = new object[concurrencyLevel];

            for (int i = 0; i < concurrencyLevel; i++)
            {
                queues[i] = new PriorityQueue<T, T>();
                locks[i] = new object();
            }
        }

        public int Count
        {
            get
            {
                int total = 0;

                for (int i = 0; i < concurrencyLevel; i++)
                {
                    lock (locks[i])
                    {
                        total += queues[i].Count;
                    }
                }

                return total;
            }
        }

        public bool IsEmpty => Count == 0;

        public void Enqueue(T item)
        {
            int i = Random.Shared.Next(concurrencyLevel);

            lock (locks[i])
            {
                queues[i].Enqueue(item, item);
            }
        }

        public T Dequeue()
        {
            int a = Random.Shared.Next(concurrencyLevel);
            int b = Random.Shared.Next(concurrencyLevel);


            if (a == b)
            {
                lock (locks[a])
                {
                    if (queues[a].Count == 0)
                    {
                        throw new InvalidOperationException("The priority queue is empty!");
                    }

                    return queues[a].Dequeue();
                }
            }

            //
            // locks are always acquired in sorted order to avoid deadlock
            //
            int first = Math.Min(a, b);
            int second = Math.Max(a, b);

            lock (locks[first])
                lock (locks[second])
                {
                    bool firstEmpty = queues[first].Count == 0;
                    bool secondEmpty = queues[second].Count == 0;

                    if (firstEmpty && secondEmpty)
                        throw new InvalidOperationException("The priority queue is empty.");

                    int chosen;

                    if (firstEmpty)
                    {
                        chosen = second;
                    }
                    else if (secondEmpty)
                    {
                        chosen = first;
                    }
                    else
                    {
                        var peek1 = queues[first].Peek();
                        var peek2 = queues[second].Peek();
                        // Pick the smaller root using comparer
                        chosen = comparer.Compare(peek2, peek1) < 0
                            ? second
                            : first;
                    }

                    return queues[chosen].Dequeue();

                }
        }

        //
        // Non-throwing Dequeue: returns false if queue is empty
        //
        public bool TryDequeue(out T item)
        {
            try
            {
                item = Dequeue();
                return true;
            }
            catch (InvalidOperationException)
            {
                item = default!;
                return false;
            }
        }

        public bool TryPeek(out T item)
        {
            item = default!;
            bool found = false;

            for (int i = 0; i < concurrencyLevel; i++)
            {
                lock (locks[i])
                {
                    if (queues[i].Count == 0)
                        continue;

                    T candidate = queues[i].Peek();

                    if (!found || comparer.Compare(candidate, item) < 0)
                    {
                        item = candidate;
                        found = true;
                    }
                }
            }

            return found;
        }


        //public T Peek()
        //{
        //    if (IsEmpty)
        //    {
        //        throw new InvalidOperationException("The priority queue is empty");
        //    }

        //    return heap[0];
        //}        
    }
}
