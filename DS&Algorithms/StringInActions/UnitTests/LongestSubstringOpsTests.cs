using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StringInActions.UnitTests
{
    [TestFixture]
    public class LongestSubstringOpsTests
    {
        [Test]
        public void StrStr_Test()
        {
            // arrange
            string haystack = "ababababaca";
            string needle = "ababaca";

            // act
            int result = LongestSubstringOps.StrStr(haystack, needle);

            // assert
            Assert.That(result, Is.EqualTo(4));
        }

        [Test]
        public void StrStr_KMP_Test()
        {
            // arrange
            string haystack = "ababababaca";
            string needle = "ababaca";

            // act
            int result = LongestSubstringOps.StrStr_KMP(haystack, needle);

            // assert
            Assert.That(result, Is.EqualTo(4));
        }

        [Test]
        public void LengthOfLongestSubstring_1_Test()
        {
            // arrange
            string s = "abcabcbb";

            // act
            int result = LongestSubstringOps.LengthOfLongestSubstring(s);

            // assert
            Assert.That(result, Is.EqualTo(3));
        }

        [Test]
        public void FindLongestSubstring_Test()
        {
            // arrange
            string s = "abcabcbb";

            // act
            string ans = LongestSubstringOps.FindTheLongestSubstring(s);

            // assert
            Assert.That(ans, Is.EqualTo("abc"));
        }

        [Test]
        public void LengthOfLongestSubstring_2_Test()
        {
            // arrange
            string haystack = "hello";

            // act
            int result = LongestSubstringOps.LengthOfLongestSubstring_HashSet(haystack);

            // assert
            Assert.That(result, Is.EqualTo(3));
        }

        [Test]
        public void LongestSubstringWithKRepeat_Test1()
        {
            string haystack = "hello";
            int k = 2;
            int result = LongestSubstringOps.LongestSubstringWithKRepeat(haystack, k);
            Assert.That(result, Is.EqualTo(2));
        }

        [Test]
        public void LongestSubstringWithKRepeat_Test2()
        {
            string haystack = "aaabbcc";
            int k = 2;
            int result = LongestSubstringOps.LongestSubstringWithKRepeat(haystack, k);
            Assert.That(result, Is.EqualTo(7));
        }

        [TestCase("eceba", 3)]
        [TestCase("ccaabbb", 5)]
        public void LengthOfLongestSubstringTwoDistinct_Test(string s, int exptected)
        {
            // arrange

            var maxLen = LongestSubstringOps.LengthOfLongestSubstringTwoDistinct(s);

            Assert.That(maxLen, Is.EqualTo(exptected));

        }

        [TestCase("eleetminicoworoep", 13)]
        [TestCase("leetcodeisgreat", 5)]
        [TestCase("bcbcbc", 6)]
        public void FindTheLongestSubstringWithEvenVowelCount_Test(string s, int expected)
        {
            // act
            int result = LongestSubstringOps.FindTheLongestSubstringWithEvenVowelCount(s);

            // assert
            Assert.That(result, Is.EqualTo(expected));
        }
    }
}
