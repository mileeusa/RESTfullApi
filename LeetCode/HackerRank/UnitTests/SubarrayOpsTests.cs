using HackerRank.src;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HackerRank.UnitTests
{
    [TestFixture]
    public class SubarrayOpsTests
    {
        [TestCase(new int[] { 2, 2, 2 }, 6)]
        [TestCase(new int[] { 1, 2, 4 }, 3)]
        [TestCase(new int[] { 1, 3, 2 }, 6)]
        [TestCase(new int[] { 7, 2, 4 }, 6)]
        [TestCase(new int[] { 1, 7, 2, 4 }, 7)]
        [TestCase(new int[] { 1073741823, 0 }, 3)]
        public void CountCompromisedSubarrays_Test(int[] nums, int expected)
        {
            var result = SubarrayOps.CountCompromisedSubarrays(nums);

            Assert.That(result, Is.EqualTo(expected));

        }

        [TestCase(new int[] { 2, 2, 2 }, 6)]
        public void CountCompromisedSubarrays_TLE_Test(int[] nums, int expected)
        {
            var result = SubarrayOps.CountCompromisedSubarrays_TLE(nums);

            Assert.That(result, Is.EqualTo(expected));
        }
    }
}
