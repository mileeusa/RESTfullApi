using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace UrlInActions.src
{
    public class UrlParsingOps
    {
        private readonly static SemaphoreSlim semaphore = new(3); // Limit to 5 concurrent requests

        public static async Task ProcessUrlWithLimitAsync(string url)
        {
            await semaphore.WaitAsync();

            try
            {
                await ProcessUrlRequestAsync(url);
            }
            finally
            {
                semaphore.Release();
            } 

        }

        public static async Task ProcessUrlRequestAsync(string url)
        {
            try
            {
                var uri = new Uri(url);
                Console.WriteLine($"Scheme: {uri.Scheme}");
                Console.WriteLine($"Host: {uri.Host}");
                Console.WriteLine($"Port: {uri.Port}");
                Console.WriteLine($"Path: {uri.AbsolutePath}");
                Console.WriteLine($"Query: {uri.Query}");

                using var httpClient = new HttpClient();
                httpClient.Timeout = TimeSpan.FromSeconds(10);
                string content = await httpClient.GetStringAsync(uri);

                Console.WriteLine($"Content Length for {url}: {content.Length}");

                // !!!DON'T need this call, since we have already had 'await' above. It's redundant
                // In fact, it slightly adds overhead because it creates another await continuation unnecessarily.
                await Task.CompletedTask;
            }
            catch (Exception ex )
            {
                Console.WriteLine($"Error processing URL: {ex.Message}");
            }
        }
    }
}
