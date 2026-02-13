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
    public class MaxOpsTests
    {
        [Test]
        public void LargestAltitude_Test()
        {
            // arrange
            int[] gain = new int[] { -5, 1, 5, 0, -7 };
            Console.WriteLine();
            Console.WriteLine("MaxOps.LargestAltitude_Test:");

            // act
            int result = MaxOps.LargestAltitude(gain);

            // assert
            Console.WriteLine("Largest Altitude: {0}", result);
            Assert.That(result, Is.EqualTo(1));
        }

        [TestCase(new int[] { 1, 1, 1, 0, 0, 0, 1, 1, 1, 1, 0 }, 2, 6)]
        [TestCase(new int[] { 0, 0, 1, 1, 0, 0, 1, 1, 1, 0, 1, 1, 0, 0, 0, 1, 1, 1, 1 }, 3, 10)]
        public void LongestOne_Test(int[] nums, int k, int expectedOnes)
        {
            // arrange
            Console.WriteLine();
            Console.WriteLine("MaxOps.LongestOne:");

            // act
            int result = MaxOps.LongestOnes(nums, k);

            // assert
            Console.WriteLine("Longest One: {0}", result);
            Assert.That(result, Is.EqualTo(expectedOnes));
        }

        [TestCase(new int[] { 1, 2, 3 }, 2, 4)]
        [TestCase(new int[] { 1, 1, 1, 1 }, 2, 1)]
        [TestCase(new int[] { 2, 3, 4, 5 }, 1, 5)]
        public void MaximumHappinessSum_Test(int[] arr, int k, int expectedSum)
        {
            // 
            // act
            long result = MaxOps.MaximumHappinessSum(arr, k);

            // assert
            Assert.That(result, Is.EqualTo((long)expectedSum));

        }        
    }
}
