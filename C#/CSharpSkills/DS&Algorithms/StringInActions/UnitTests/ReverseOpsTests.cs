using NUnit.Framework;
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
            string reversed = ReverseOps.ReverseString(s);
            Console.WriteLine();
            Console.WriteLine($"Original: {s}, Reversed: {reversed}"); // Output: "olleh"
        }

        [Test]
        public void ReverseString2_Test()
        {
            string s = "world";
            string reversed = ReverseOps.ReverseString2(s);
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
    }
}
