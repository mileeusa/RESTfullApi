using NUnit.Framework;
using QueueInActions.src;
using System.Collections.Concurrent;

namespace QueueInActions.UnitTests
{
    [TestFixture]
    public class ConcurrentPriorityQueueImplTests
    {
        [Test]
        public void ConcurrentPQ_ProducesAndConsumes_AllItemsProcessed()
        {
            const int producers = 4;
            const int consumers = 4;
            const int itemsPerProducer = 5000;

            var pq = new ConcurrentPriorityQueueImpl<int>(concurrencyLevel: 4);

            var produced = new ConcurrentBag<int>();
            var consumed = new ConcurrentBag<int>();

            // Start producers
            var producerTasks = Enumerable.Range(0, producers).Select(_ => Task.Run(() =>
            {
                for (int i = 0; i < itemsPerProducer; i++)
                {
                    int value = Random.Shared.Next(1_000_000);
                    produced.Add(value);
                    pq.Enqueue(value);
                }
            })).ToArray();

            // Start consumers
            var consumerTasks = Enumerable.Range(0, consumers).Select(_ => Task.Run(() =>
            {
                while (true)
                {
                    if (pq.TryDequeue(out int item))
                    {
                        consumed.Add(item);
                    }
                    else if (producerTasks.All(t => t.IsCompleted) && pq.IsEmpty)
                    {
                        break; // exit consumer
                    }
                    else
                    {
                        Thread.Yield();
                    }
                }
            })).ToArray();

            Task.WaitAll(producerTasks);
            Task.WaitAll(consumerTasks);

            Assert.That(produced.Count, Is.EqualTo(consumed.Count));
            Assert.That(pq.IsEmpty, Is.EqualTo(true));
        }

        [Test]
        public void ConcurrentPQ_LocalOrderingHolds()
        {
            var pq = new ConcurrentPriorityQueueImpl<int>(8);

            for (int i = 0; i < 50000; i++)
                pq.Enqueue(Random.Shared.Next(1_000_000));

            int prev = int.MinValue;

            while (pq.TryDequeue(out int cur))
            {
                Assert.That(cur >= prev, Is.EqualTo(true));
                prev = cur;
            }
        }
    }
}
