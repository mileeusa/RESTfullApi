using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace AsyncActions
{
    public static class IAsyncEnumberableLINQImpl
    {
        public static async IAsyncEnumerable<int> SlowRange()
        {
            for (int i = 0; i < 10; i++)
            {
                await Task.Delay(100); // Simulate asynchronous work
                yield return i;
            }
        }

        public static async IAsyncEnumerable<int> SlowRange([EnumeratorCancellation] CancellationToken token = default)
        {
            for (int i = 0; i < 10; i++)
            {
                await Task.Delay(100); // Simulate asynchronous work
                yield return i;
            }
        }

        public static async IAsyncEnumerable<int> ProcessIncomingRequestsAsync()
        {
            await foreach (var number in SlowRange())
            {
                await Task.Delay(100);
                if (number % 2 == 0) // filter even numbers
                {
                    //Console.WriteLine($"Processing even number: {number}");
                    yield return number;
                }
            }
        }

        public static async IAsyncEnumerable<int> ProcessIncomingRequestsWithCancellationAsync(int timeoutInMs)
        {
            using var cts = new CancellationTokenSource(timeoutInMs);
            CancellationToken token = cts.Token;

            await foreach (var number in SlowRange(token))
            {
                await Task.Delay(100);
                if (number % 2 == 0) // filter even numbers
                {
                    //Console.WriteLine($"Processing even number: {number}");
                    yield return number;
                }
            }
        }
    }
}
