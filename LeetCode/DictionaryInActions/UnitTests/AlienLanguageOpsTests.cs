using DictionaryInActions.src;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DictionaryInActions.UnitTests
{
    [TestFixture]
    public class AlienLanguageOpsTests
    {
        [Test]
        public void IsAlienSorted_Test()
        {
            //string[] words = new string[] { "word","world","row" };
            //string order = "worldabcefghijkmnpqstuvxyz";

            string[] words = new string[] { "hello", "leetcode" };
            string order = "hlabcdefgijkmnopqrstuvwxyz";

            bool result = AlienLanguageOps.IsAlienSorted(words, order);

            Console.WriteLine();
            Console.WriteLine("SortedOps.Test_IsAlienSorted:");
            Console.WriteLine($"Words: [{string.Join(", ", words)}], Order: {order} => IsAlienSorted: {result}");
        }
    }
}
