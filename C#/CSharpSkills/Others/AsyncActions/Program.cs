namespace AsyncActions
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            IAsyncEnumerable<int> asyncResults = IAsyncEnumerableImpl.GenerateNumbersAsync(10);
            await foreach (var number in asyncResults)
            {
                Console.WriteLine($"Received number: {number}");
            }

            Console.WriteLine("Processing incoming requests ...");
            var processor = IAsyncEnumberableLINQImpl.ProcessIncomingRequestsAsync();
            await foreach (var processed in processor)
            {
                Console.WriteLine($"Processed number: {processed}");
            }

            Console.WriteLine("Processing incoming requests with timeout ...");
            var processorWithTimeout = IAsyncEnumberableLINQImpl.ProcessIncomingRequestsWithCancellationAsync(500);
            await foreach (var processed in processorWithTimeout)
            {
                Console.WriteLine($"Processed number with timeout: {processed}");
            }
        }
    }
}