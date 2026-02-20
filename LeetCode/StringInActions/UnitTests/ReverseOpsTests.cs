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
    public class ReverseOpsTests
    {
        [Test]
        public void ReverseString_Test()
        {
            string s = "hello";
            string reversed = ReverseOps.ReverseString2(s);
            Console.WriteLine();
            Console.WriteLine($"Original: {s}, Reversed: {reversed}"); // Output: "olleh"
        }

        [Test]
        public void ReverseString2_Test()
        {
            string s = "world";
            string reversed = ReverseOps.ReverseString(s);
            Console.WriteLine();
            Console.WriteLine($"Original: {s}, Reversed: {reversed}"); // Output: "dlrow"
        }

        [Test]
        public static void ReverseWords_Test()
        {
            string s = "  hello world  ";
            string reversed = ReverseOps.ReverseWords(s);
            Console.WriteLine();
            Console.WriteLine($"Original: \"{s}\", Reversed: \"{reversed}\""); // Output: "world hello"
            s = "a good   example";
            reversed = ReverseOps.ReverseWords(s);
            Console.WriteLine($"Original: \"{s}\", Reversed: \"{reversed}\""); // Output: "example good a"
        }

        [Test]
        public void ReverseWordsII_Test()
        {
            char[] s = ['t', 'h', 'e', ' ', 's', 'k', 'y', ' ', 'i', 's', ' ', 'b', 'l', 'u', 'e'];
            char[] t = ['b', 'l', 'u', 'e', ' ', 'i', 's', ' ', 's', 'k', 'y', ' ', 't', 'h', 'e'];

            var result = ReverseOps.ReverseWordsII(s);

            // assert
            Assert.That(result, Is.EqualTo(t));
        }

        [Test]
        public void ReverseEachWord_Test()
        {
            char[] s = ['t', 'h', 'e', ' ', 's', 'k', 'y', ' ', 'i', 's', ' ', 'b', 'l', 'u', 'e'];
            char[] t = ['e', 'h', 't', ' ', 'y', 'k', 's', ' ', 's', 'i', ' ', 'e', 'u', 'l', 'b'];

            ReverseOps.ReverseEachWord(s);

            // assert
            Assert.That(s, Is.EqualTo(t));
        }

        [TestCase("IceCreAm", "AceCreIm")]
        public void ReverseVowels_Test(string s, string expected)
        {
            var result = ReverseOps.ReverseVowels(s);

            Assert.That(result, Is.EqualTo(expected));
        }

        [TestCase("IceCreAm", "AceCreIm")]
        public void ReverseVowels_TwoPointers_Test(string s, string expected)
        {
            var result = ReverseOps.ReverseVowels_TwoPointers(s);

            Assert.That(result, Is.EqualTo(expected));
        }

        [TestCase("cat and mice", "cat dna mice")]
        public void ReverseWordsWithSameVowelCount_Test(string s, string expected)
        {
            var result = ReverseOps.ReverseWordsWithSameVowelCount(s);

            Assert.That(result, Is.EqualTo(expected));
        }
    }
}
