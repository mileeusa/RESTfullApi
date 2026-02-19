using ArrayInActions.src;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArrayInActions.UnitTests
{
    [TestFixture]
    public class SumOfSubarrayOpsTests
    {
        [TestCase(new int[] {3, 4, 7}, 7, 2)]
        [TestCase(new int[] {1, 1, 1}, 2, 2)]
        [TestCase(new int[] {100, 1, 2, 3, 4 }, 6, 1)]
        public void SubarraySum_Test(int[] nums, int target, int expected)
        {
            var result = SumOfSubarrayOps.SubarraySum(nums, target);

            Assert.That(result, Is.EqualTo(expected));
        }

        [TestCase(new int[] { 23, 2, 4, 6, 7 }, 6, true)]
        [TestCase(new int[] { 2, 4, 3 }, 6, true)]
        public void CheckSubarraySum_Test(int[] nums, int k, bool expected)
        {
            var result = SumOfSubarrayOps.CheckSubarraySum(nums, k);

            Assert.That(result, Is.EqualTo(expected));
        }

        [TestCase(new int[] { 4, 5, 0, -2, -3, 1 }, 5, 7)]
        public void SubarraysDivByK_Test(int[] nums, int k, int expected)
        {
            var result = SumOfSubarrayOps.SubarraysDivByK(nums, k);

            Assert.That(result, Is.EqualTo(expected));
        }

        [TestCase(new int[] { 1, 2 }, 1, 3)]
        [TestCase(new int[] { -1, -2, -3, -4, -5 }, 4, -10)]
        [TestCase(new int[] { -5, 1, 2, -3, 4 }, 2, 4)]
        public void MaxSubarraySum_Test(int[] nums, int k, int expected)
        {
            var result = SumOfSubarrayOps.MaxSubarraySum(nums, k);

            Assert.That(result, Is.EqualTo(expected));
        }
    }
}
