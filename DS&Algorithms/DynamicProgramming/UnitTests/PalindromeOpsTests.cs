using DynamicProgrammingInActions.src;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DynamicProgrammingInActions.UnitTests
{
    [TestFixture]
    public class PalindromeOpsTests
    {
        [TestCase("bbbab", 4)]
        [TestCase("cbbd", 2)]
        public void LongestPalindromeSubseq_Test(string s, int expected)
        {
            var result = PalindromeOps.LongestPalindromeSubseq(s);

            Assert.That(result, Is.EqualTo(expected));


        }

        [TestCase("bbbab", 4)]
        [TestCase("cbbd", 2)]
        public void LongestPalindromeSubseq_IterativeDP_Test(string s, int expected)
        {
            var result = PalindromeOps.LongestPalindromeSubseq_IterativeDP(s);

            Assert.That(result, Is.EqualTo(expected));
        }
    }
}
