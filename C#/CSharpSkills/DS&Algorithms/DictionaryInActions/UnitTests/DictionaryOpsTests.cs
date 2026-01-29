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
    public class DictionaryOpsTests
    {
        [Test]
        public void LongestWord_Test()
        {
            string[] words = new string[] { "w", "wo", "wor", "worl", "world" };
            string result = DictionaryOps.LongestWord(words);
            Console.WriteLine();
            Console.WriteLine("Test_LongestWord");
            Console.WriteLine($"Longest word from dictionary [{string.Join(", ", words)}] is: {result}");
            Console.WriteLine();
        }
    }
}
