using NUnit.Framework;
using SlidingWindowInAction.src;
using System;
using System.Collections.Generic;
using System.Text;

namespace SlidingWindowInAction.UnitTests
{
    [TestFixture] 
    public class SubArrayOpsTests
    {
        [TestCase ("abc", "ahbgdc", true)]
        [TestCase ("axc", "ahbgdc", false)]
        public void SubsequenceOps_Test(string s, string t, bool expected)
        {
            var result = SubArrayeOps.IsSubsequence(s, t);

            Assert.That(result, Is.EqualTo(expected));
        }

        [TestCase(new int[] { 1, 2, 3, 1, 2 }, 4)]
        [TestCase(new int[] { 2, 2, 2, 2, 2 }, 5)]
        public void LongestSubarray_Test(int[] nums, int expected)
        {
            var result = SubArrayeOps.LongestSubarray(nums);

            Assert.That(result, Is.EqualTo(expected));
        }
    }
}
