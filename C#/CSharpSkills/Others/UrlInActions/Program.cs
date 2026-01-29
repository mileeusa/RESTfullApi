using UrlInActions.src;

namespace UrlInActions
{
    public class Program
    {
        private static async Task Main(string[] args)
        {
            var urls = new List<string>()
        {
            "https://www.cnn.com",
            "https://www.bbc.com",
            "https://www.nytimes.com",
            "https://www.theguardian.com"
        };

            var tasks = new List<Task>();
            foreach (var url in urls)
            {
                tasks.Add(UrlParsingOps.ProcessUrlWithLimitAsync(url));
            }

            await Task.WhenAll(tasks);

            Console.WriteLine("All URLs processed");
        }
    }
}