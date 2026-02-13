using NUnit.Framework;
using StringInActions.src;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StringInActions.UnitTests
{
    [TestFixture]
    public class RemoveOpsTests
    {
        [Test]
        public void RemoveStars_Test()
        {
            string s = "ab*cd*ef*g";
            string result = RemoveOps.RemoveStars(s);

            Console.WriteLine();
            Console.WriteLine($"Original: {s}, after removing stars and preceding chars: {result}"); // Output: "aceg"

            // assert
            Assert.That(result, Is.EqualTo("aceg"));
        }

        [Test]
        public void RemoveStars_Stack_Test()
        {
            string s = "ab*cd*ef*g";
            string result = RemoveOps.RemoveStars_Stack(s);

            Console.WriteLine();
            Console.WriteLine($"Original: {s}, after removing stars and preceding chars: {result}"); // Output: "aceg"

            // assert
            Assert.That(result, Is.EqualTo("aceg"));
        }

        [Test]
        public static void RemoveDuplicates_Test()
        {
            string s = "programming";
            string result = RemoveOps.RemoveDuplicates(s);
            Console.WriteLine();
            Console.WriteLine($"Original: {s}, After removing duplicates: {result}"); // Output could be "progamin"

            // assert
            Assert.That(result, Is.EqualTo("progamin"));
        }

        [TestCase("abcde", "ade", "bc")]
        public void RemoveChars_Test(string s, string toDelete, string remaining)
        {
            var result = RemoveOps.RemoveChars(s, toDelete);

            Assert.That(result, Is.EqualTo(remaining));
        }

        [TestCase("ABCDE", "ade", "BC")]
        public void RemoveChars_SB_Test(string s, string toDelete, string remaining)
        {
            var result = RemoveOps.RemoveChars_SB(s, toDelete);

            Assert.That(result, Is.EqualTo(remaining));
        }

        [TestCase("1432219", 3, "1219")]
        public void removeKdigits_Test(string num, int k, string expected)
        {
            string res = RemoveOps.removeKdigits(num, k);

            Assert.That(res, Is.EqualTo(expected));
        }


        [TestCase("ABCDE", "ade", "BC")]
        public void RemoveChars_LINQ_Test(string s, string toDelete, string remaining)
        {
            var result = RemoveOps.RemoveChars_LINQ(s, toDelete);

            Assert.That(result, Is.EqualTo(remaining));
        }
    }
}
