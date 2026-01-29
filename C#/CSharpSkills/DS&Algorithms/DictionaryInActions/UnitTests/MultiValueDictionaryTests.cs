using NUnit.Framework;
using System.Collections;
using DictionaryInActions.src;

namespace DictionaryInActions.UnitTests
{
    [TestFixture]
    public class MultiValueDictionaryTests
    {
        [TestCase]
        public void IEnumerable_GetEnumerator_Returns_All_KeyValuePairs()
        {
            var dict = new MultiValueDictionary<string, string>()
            {
                { "a", "1" },
                { "a", "2" },
                { "b", "3" }
            };

            // Call the non-generic IEnumerable.GetEnumerator()
            IEnumerable nonGeneric = (IEnumerable)dict;
            var enumerator = nonGeneric.GetEnumerator();

            var items = new List<KeyValuePair<string, string>>();
            while (enumerator.MoveNext())
            {
                // non-generic enumerator returns object
                var current = (KeyValuePair<string, string>)enumerator.Current!;
                items.Add(current);
            }

            Assert.That(true, Is.EqualTo(items.Count == 3));
            Assert.That(items, Has.Some.Matches<KeyValuePair<string, string>>(kv => kv.Key == "a" && kv.Value == "1"));
            Assert.That(items, Has.Some.Matches<KeyValuePair<string, string>>(kv => kv.Key == "a" && kv.Value == "2"));
            Assert.That(items, Has.Some.Matches<KeyValuePair<string, string>>(kv => kv.Key == "b" && kv.Value == "3"));
        }

        [Test]
        public void MultiValueDictionaryExtension_Test()
        {
            var dictA = new MultiValueDictionary<string, int>();
            dictA.Add("A", 1);
            dictA.Add("A", 2);
            dictA.Add("B", 3);

            var dictB = new MultiValueDictionary<string, int>();
            dictB.Add("A", 2);
            dictB.Add("A", 4);
            dictB.Add("C", 5);

            var union = dictA.Union(dictB);
            var intersect = dictA.Intersect(dictB);
            var except = dictA.Except(dictB);
            var sym = dictA.SymmetricExcept(dictB);

            // assert
            PrintDict<string, int>(union, "Union");
            PrintDict<string, int>(intersect, "Intersection");
            PrintDict<string, int>(except, "Exception");
            PrintDict<string, int>(sym, "SymmetricExcept");
        }

        private void PrintDict<TKey, TValue>(IMultiValueDictionary<TKey, TValue> dict, string message) where TKey : notnull
        {
            Console.WriteLine($"\n--- {message} ---");
            foreach (var (k, v) in dict)
            {
                Console.WriteLine($"Key: {k}, Value: {v}");
            }
        }
    }
}
