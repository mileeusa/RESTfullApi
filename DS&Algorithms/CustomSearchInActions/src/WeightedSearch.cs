using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomSearchInActions.src
{
    public class WeightedSearch
    {
        public static List<(string Item, int Score)> Search(IEnumerable<string> items, string query)
        {
            if (string.IsNullOrWhiteSpace(query))
            {
                return [];
            }

            string normalizedQuery = query.Trim().ToLower();

            var weightedResult = items
                .Select(item =>
                {
                    var normalizedItem = item.ToLower();
                    int score = 0;

                    if (normalizedItem.Equals(normalizedQuery))
                        score += 100; // exact match
                    else if (normalizedItem.StartsWith(normalizedQuery))
                        score += 70;  // start with weight
                    else if (normalizedItem.Contains(normalizedQuery))
                        score += 40;  // partial match weight

                    return (Item: item, Score: score);
                })
                .Where(x => x.Score > 0)
                .OrderByDescending(x => x.Score)
                .ToList();

            return weightedResult;
        }

        public static void Search_Test()
        {
            var data = new List<string>
            {
                "Apple",
                "Pineapple",
                "Application",
                "Grape",
                "App Store",
                "Happy"
            };

            Console.WriteLine();
            var results = Search(data, "app");

            Console.WriteLine("Weighted Search Results:");
            foreach (var r in results)
                Console.WriteLine($"{r.Item,-15} Score: {r.Score}");
        }
    }
}
