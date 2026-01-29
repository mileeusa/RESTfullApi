using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StringInActions.UnitTests
{
    [TestFixture]
    public class PalindromeOpsTests
    {
        private static readonly string ts = 
            @"ababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababa";

        [Test]
        public static void IsPalindrome_Test()
        {
            var str = "\"A man, a plan, a canal: Panama\"";
            Console.WriteLine();
            Console.WriteLine($"Is {str} a palindrome? {PalindromeOps.IsPalindrome(str)}");
        }

        [Test]
        public static void LongestPalindromicSubstring_Expansion_Test1()
        {
            var str = "babad";
            Console.WriteLine();
            Console.WriteLine($"Longest palindromic substring in {str} is: {PalindromeOps.LongestPalindromicSubstring_Expansion(str)}");
        }

        [Test]
        public static void LongestPalindromicSubstring_Expansion_Test2()
        {
            var maxString = PalindromeOps.LongestPalindromicSubstring_Expansion(ts);

            Assert.That(maxString.Length, Is.EqualTo(ts.Length));
        }

        [Test]
        public static void LongestPalindromicSubstring_Manacher_Test1()
        {
            var str = "babad";
            Console.WriteLine();
            Console.WriteLine($"Longest palindromic substring in {str} is: {PalindromeOps.LongestPalindromicSubstring_Manacher(str)}");
        }

        [Test]
        public static void LongestPalindromicSubstring_Manacher_Test2()
        {
            var maxString = PalindromeOps.LongestPalindromicSubstring_Manacher(ts);

            Assert.That(maxString.Length, Is.EqualTo(ts.Length));
        }
    }
}
