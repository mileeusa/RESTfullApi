using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CollectionInActions.UnitTests
{
    class Country
    {
        public string ShortName { get; set; }
        public string Name { get; set; }
        public Country(string shortName, string name)
        {
            ShortName = shortName;
            Name = name;
        }
    }

    [TestFixture]
    public class CollectionInitializationOpsTests
    {
        [Test]
        public void ListInitializer_Test()
        {
            //List<int> numbers = new () { 1, 2, 3, 4, 5 };
            List<int> numbers = [1, 2, 3, 4, 5];
            Console.WriteLine();
            Console.WriteLine("CollectionOps.CollectionInitializer_Test:");
            Console.WriteLine($"Numbers: [{string.Join(", ", numbers)}]");
        }

        [Test]
        public void DictionaryInitializer_Test()
        {
            Dictionary<string, int> ages = new()
            {
                { "Alice", 30 },
                { "Bob", 25 },
                { "Charlie", 35 }
            };
            Console.WriteLine();
            Console.WriteLine("CollectionOps.DictionaryInitializer_Test:");
            foreach (var kvp in ages)
            {
                Console.WriteLine($"{kvp.Key}: {kvp.Value}");
            }
        }

        [Test]
        public void StackInitializer_Test()
        {
            //
            // you cannot use collection initializer with Stack<T> stack = new() { "First", "Second", "Third" };
            // since Stack doesn't have an Add method
            //
            Stack<string> stack = new();
            stack.Push("First");
            stack.Push("Second");
            stack.Push("Third");
            Console.WriteLine();
            Console.WriteLine("CollectionOps.StackInitializer_Test:");
            Console.WriteLine(string.Join(", ", stack.ToArray()));
        }

        [Test]
        public void AnonymousInitializer_Test()
        {
            var player = new
            {
                Name = "John",
                Score = 100,
                Level = 5
            };

            Console.WriteLine();
            Console.WriteLine("AnonymousInitializer_Test");
            Console.WriteLine($"Player Name: {player.Name}, Score: {player.Score}, Level: {player.Level}");

            var players = new[]
            {
                new { Name = "Alice", Score = 150, Level = 7 },
                new { Name = "Bob", Score = 120, Level = 6 },
                new { Name = "Charlie", Score = 130, Level = 8 }
            };

            foreach (var p in players)
            {
                Console.WriteLine($"Player Name: {p.Name}, Score: {p.Score}, Level: {p.Level}");
            }
        }

        [Test]
        public void ListToDictionary_Test()
        {
            var allCountries = new List<Country>
            {
                new ("AUS", "Australia"),
                new ("USA", "United States"),
                new ("CAN", "Canada")
            };

            //
            // Convert List to Dictionary to improve lookup performance from O(n) to O(1)
            //
            var AllCountriesByKey = allCountries.ToDictionary(country => country.ShortName, StringComparer.OrdinalIgnoreCase);
            Console.WriteLine();
            Console.WriteLine("ListToDictionary_Test");
            foreach (var kvp in AllCountriesByKey)
            {
                Console.WriteLine($"Key: {kvp.Key}, Value: {kvp.Value.Name}");
            }
        }

        // tuple return type example
        public static (int min, int max) FindMinMax(List<int> arr)
        {
            if (arr == null || arr.Count == 0)
            {
                throw new ArgumentException("The list cannot be null or empty.");
            }
            int min = arr[0];
            int max = arr[0];
            foreach (var n in arr)
            {
                if (n < min)
                {
                    min = n;
                }
                if (n > max)
                {
                    max = n;
                }
            }
            return (min, max);
        }
    }
}
