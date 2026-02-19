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
    public class LongestCommonSubsequenceOpsTests
    {
        [TestCase("abcde", "ace", 3)]
        public void LongestCommonSubsequence_Test(string s1, string s2, int expected)
        {
            var result = LongestCommonSubsequenceOps.LongestCommonSubsequence(s1, s2);

            Assert.That(result, Is.EqualTo(expected));
        }
    }
}
