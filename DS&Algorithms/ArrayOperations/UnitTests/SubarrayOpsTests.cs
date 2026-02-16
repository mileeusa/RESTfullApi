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
    public class SubarrayOpsTests
    {
        [TestCase(new int[] {2, 4, 7, 9})]
        public void GetAllSubarrays_Test(int[] arr)
        {
            var result = SubarrayOps.GetAllSubarrays(arr);

            foreach (var list in result)
            {
                Console.WriteLine(string.Join(",", list));
            }
        }

        [TestCase(new int[] { -2, 1, -3, 4, -1, 2, 1, -5, 4 }, 6, 3, 6)]
        public void ReturnMaxSubArray_Test(int[] nums, int expectedMax, int startIdx, int endIdx)
        {
            var (sum, start, end) = SubarrayOps.ReturnMaxSubArray(nums);

            Console.Write($"Sum: {sum}, start index: {start}, end index: {end}");

            Assert.That(sum, Is.EqualTo(expectedMax));
        }

        [TestCase(new int[] { -2, 1, -3, 4, -1, 2, 1, -5, 4 }, 6)]
        public void MaxSubArray_Test(int[] nums, int expectedMax)
        {
            var sum = SubarrayOps.MaxSubArray(nums);

            Console.Write($"Sum: {sum}");

            Assert.That(sum, Is.EqualTo(expectedMax));
        }

        [TestCase(new int[] { -2, 1, -3, 4, -1, 2, 1, -5, 4 }, 6)]
        public void MaxSubArray_DP_Test(int[] nums, int expectedMax)
        {
            var sum = SubarrayOps.MaxSubArray_DP(nums);

            Console.Write($"Sum: {sum}");

            Assert.That(sum, Is.EqualTo(expectedMax));
        }
        
        [TestCase(new int[] { 2, 3, -2, 4 }, 6)]
        [TestCase(new int[] { -2, 3, -4 },  24)]
        [TestCase(new int[] { -2, 3, -1 },   6)]
        public void MaxProduct_Test(int[] nums, int expected)
        {
            int maxProduct = SubarrayOps.MaxProduct(nums);

            // assert
            Assert.That(maxProduct, Is.EqualTo(expected));
        }
    }
}
