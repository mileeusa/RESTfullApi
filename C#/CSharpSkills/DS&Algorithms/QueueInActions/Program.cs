using QueueInActions.src;

namespace QueueInActions
{
    public class Program
    {
        private static void Main(string[] args)
        {
            var queue = new ExpiringQueue<string>();

            queue.Enqueue("A", TimeSpan.FromSeconds(2));
            queue.Enqueue("B", TimeSpan.FromSeconds(5));
            queue.Enqueue("C"); // no expiration

            Console.WriteLine("Initial count: " + queue.Count);

            System.Threading.Thread.Sleep(3000);

            if (queue.TryDequeue(out var item))
                Console.WriteLine($"Dequeued: {item}");
            else
                Console.WriteLine("No valid items available.");

            Console.WriteLine("Remaining count: " + queue.Count);
        }
    }
}