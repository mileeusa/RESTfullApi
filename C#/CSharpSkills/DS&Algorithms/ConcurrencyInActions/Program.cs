// See https://aka.ms/new-console-template for more information
using ConcurrencyInActions.src;

namespace ConcurrencyInActions
{
    public class Program
    {
        private static void Main(string[] args)
        {
            var list = new ConcurrentList<int>();
            var threads = new List<Thread>();

            // Start multiple threads to add items concurrently
            for (int i = 0; i < 5; i++)
            {
                int threadId = i;
                var t = new Thread(() =>
                {
                    for (int j = 0; j < 5; j++)
                    {
                        list.Add(threadId * 10 + j);
                        Thread.Sleep(50);
                    }
                });
                threads.Add(t);
                t.Start();
            }

            // A reader thread to periodically display list contents
            var reader = new Thread(() =>
            {
                for (int k = 0; k < 10; k++)
                {
                    var snapshot = list.GetSnapshot();
                    Console.WriteLine($"Snapshot (Count={snapshot.Count}): [{string.Join(", ", snapshot)}]");
                    Thread.Sleep(100);
                }
            });

            reader.Start();

            // Wait for all writer threads to finish
            foreach (var t in threads)
                t.Join();

            reader.Join();

            Console.WriteLine($"Final Count = {list.Count}");
        }
    }
}