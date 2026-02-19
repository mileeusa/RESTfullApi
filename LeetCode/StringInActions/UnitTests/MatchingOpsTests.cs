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
    public class MatchingOpsTests
    {
        [TestCase("abcd", "*b*d", true)]
        [TestCase("abcd", "ab?d", true)]
        [TestCase("abcd", "ab?*", true)]
        [TestCase("abcd", "ab??", true)]
        [TestCase("abcd", "ab*",  true)]
        [TestCase("abcd", "ab?",  false)]
        public void IsWildMatched_Test(string s, string p, bool expected)
        {
            var isMatched = WildcardMatchingOps.IsWildMatched(s, p);

            Console.WriteLine($"string \"{s}\" matches the pattern \"{p}\": {isMatched}.");

            // assert
            Assert.That(isMatched, Is.EqualTo(expected));
        }
    }
}
