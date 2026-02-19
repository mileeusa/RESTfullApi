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
    public class LongestNonDecreasingSubArrayOpsTests
    {
        [TestCase(new int[] { 8, -8 }, 2)]
        [TestCase(new int[] { 2, 2, 2, 2, 2 }, 5)]
        [TestCase(new int[] { 1, 2, 3, 1, 2 }, 4)]
        public void LongestSubarray_Test(int[] nums, int expected)
        {
            var result = LongestNonDecreasingSubArrayOps.LongestSubarray(nums);

            Assert.That(result, Is.EqualTo(expected));
        }
    }
}
