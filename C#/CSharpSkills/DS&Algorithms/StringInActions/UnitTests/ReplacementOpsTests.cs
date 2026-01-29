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
    public class ReplacementOpsTests
    {
        [TestCase("ABAB", 2, 4)]
        [TestCase("AABABBA", 1, 4)]
        [TestCase("AAAA", 0, 4)]
        public void CharacterReplacement_Test(string s, int k, int expected)
        {
            // arrange

            // act
            int result = ReplacementOps.CharacterReplacement(s, k);

            // assert
            Assert.That(result, Is.EqualTo(expected));
        }

        [TestCase("abcd", new int[] { 0, 2 }, new string[] { "a", "cd" }, new string[] { "eee", "ffff" }, "eeebffff")]
        [TestCase("abcd", new int[] { 0, 2 }, new string[] { "ab", "ec" }, new string[] { "eee", "ffff" }, "eeecd")]
        [TestCase("abcd", new int[] { 0, 0 }, new string[] { "a", "b" }, new string[] { "b", "c" }, "bbcd")]
        public void FindReplaceString_Test(string s, int[] indices, string[] sources, string[] targets, string expected)
        {
            // arrange

            // act
            var res = ReplacementOps.FindReplaceString(s, indices, sources, targets);

            Assert.That(res, Is.EqualTo(expected));
        }
    }
}
