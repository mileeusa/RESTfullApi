using NUnit.Framework;
using PrefixSuffixInActions.src;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrefixSuffixInActions.UnitTests
{
    [TestFixture]
    public class LongestNonDecreasingSubArrayOpsTests
    {
        [TestCase(new int[] { 1, 2, 3, 1, 2 }, 4)]
        [TestCase(new int[] { 2, 2, 2, 2, 2 }, 5)]
        public void LongestSubarrayAtMostOneReplacement_Test(int[] nums, int expected)
        {
            var result = LongestNonDecreasingSubArrayOps.LongestSubarrayAtMostOneReplacement(nums);

            Assert.That(result, Is.EqualTo(expected));
        }
    }
}
