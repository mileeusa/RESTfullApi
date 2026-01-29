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
    public class LisOpsTests
    {
        [Test]
        public void LengthOfLIS_DP_Test()
        {
            // arrange
            int[] nums = new int[] { 10, 9, 2, 5, 3, 7, 101, 18 };

            // act
            int result = LisOps.LengthOfLIS_DP(nums);

            // assert
            Assert.That(result, Is.EqualTo(4));
        }

        [Test]
        public void LengthOfLIS_BinarySearch_Test()
        {
            // arrange
            int[] nums = new int[] { 10, 9, 2, 5, 3, 7, 101, 18 };

            // act
            int result = LisOps.LengthOfLIS_BinarySearch(nums);

            // assert
            Assert.That(result, Is.EqualTo(4));
        }
    }
}
