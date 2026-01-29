using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AsyncActions
{
    public static class IAsyncEnumerableImpl
    {
        public static async IAsyncEnumerable<int> GenerateNumbersAsync(int count)
        {
            for (int i = 0; i < count; i++)
            {
                await Task.Delay(100); // Simulate asynchronous work
                yield return i;
            }
        }

        public static async IAsyncEnumerable<string> FetchDataAsync(HttpClient client)
        {
            int offset = 0;
            const int limit = 10;

            while (true)
            {
                var response = await client.GetStringAsync($"https://api.example.com/data?offset={offset}&limit={limit}");
                string[] valuesPerPage = response.Split('\n');

                // produce the results based on the response
                foreach (var value in valuesPerPage)
                {
                    if (!string.IsNullOrWhiteSpace(value))
                    {
                        yield return value;
                    }
                }

                if (valuesPerPage.Length < limit)
                {
                    // No more data to fetch
                    break;
                }

                offset += limit;
            }
        }

        public static async IAsyncEnumerable<string> GetValuesAsync(HttpClient client)
        {
            await foreach (string value in FetchDataAsync(client))
            {
                Console.WriteLine($"Processing value: {value}");
                yield return value.ToUpper();
            }
        }
    }
}
