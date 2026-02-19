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
    public class LongestContinuousIncreasingStringOpsTests
    {
        [TestCase(new int[] { 3, 4, 9, 1 }, 3)]
        [TestCase(new int[] { 3, 9, 1, 2 }, 2)]
        [TestCase(new int[] { 2, 2, 2 }, 1)]
        [TestCase(new int[] { }, 0)]
        public void FindLengthOfLCIS_Test(int[] arr, int expected)
        {
            // arrange

            // act
            int result = LongestContinuousIncreasingStringOps.FindLengthOfLCIS(arr);

            // assert
            Assert.That(result, Is.EqualTo(expected)); 
        }
    }
}
