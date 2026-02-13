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
    public class SearchOpsTests
    {
        [TestCase(new int[] { 1, 2, 3, 1}, 2)]
        [TestCase(new int[] { 1, 2, 1, 3, 5, 6, 4 }, 1)]
        public void FindPeakElement_Test(int[] nums, int expectedIdx)
        {
            var result = SearchOps.FindPeakElement(nums);

            Assert.That(result, Is.EqualTo(expectedIdx));
        }

        [TestCase(new int[] { 1, 2, 3, 1 }, 2)]
        [TestCase(new int[] { 1, 2, 1, 3, 5, 6, 4 }, 5)]
        public void FindPeakElement_BinarySearch_Test(int[] nums, int expectedIdx)
        {
            var result = SearchOps.FindPeakElement_BinarySearch(nums);

            Assert.That(result, Is.EqualTo(expectedIdx));
        }

        [TestCase(new int[] { 4, 4, 6, 7, 7, 2, 2 }, 6)]
        [TestCase(new int[] { -4, -4, 6, -7, -7, -2, -2 }, 6)]
        public void SingleNumber_Test(int[] nums, int target)
        {
            // act
            int n = SearchOps.SingleNumber(nums);

            // assert
            Assert.That(n, Is.EqualTo(target));
        }

        [TestCase(new int[] { 3, 4, 5, 1, 2}, 1)]
        [TestCase(new int[] { 4, 5, 6, 7, 0, 1, 2}, 0)]
        [TestCase(new int[] { 11, 13, 15, 17 }, 11)]
        public void FindMinInRotatedSortedArray_Test(int[] nums, int target)
        {
            // arrange

            // act
            var min = SearchOps.FindMinInRotatedSortedArray(nums);

            // assert
            Assert.That(min, Is.EqualTo(target));
        }

        [TestCase(new int[] { 4, 5, 6, 7, 0, 1, 2 }, 7, 3)]
        [TestCase(new int[] { 1, 0, 1, 1, 1 }, 1, 2)]
        public void SearchInRotatedSortedArray_Test(int[] rotatedArray, int target, int expectedIdx)
        {
            // arrange
            Console.WriteLine();
            Console.WriteLine($"SearchOps.SearchInRotatedSortedArray: {target}");
            Console.WriteLine(string.Join(", ", rotatedArray));

            // act
            var foundIndex = SearchOps.SearchInRotatedSortedArray(rotatedArray, target);

            // assert
            Console.WriteLine($"Found {target} at index: {foundIndex}");
            Assert.That(foundIndex, Is.EqualTo(expectedIdx));
        }

        [Test]
        public static void FindMedianSortedArrays_Test()
        {
            // arrange
            int[] numFirst = { 1, 2 };
            int[] numSecond = { 3, 4 };
            Console.WriteLine();
            Console.WriteLine("SearchOps.FindMedianSortedArrays [{0}], [{1}]", string.Join(" ", numFirst), string.Join(" ", numSecond));

            // act
            var result = SearchOps.FindMedianSortedArrays(numFirst, numSecond);
            Console.WriteLine($"=> {result}");

            // assert
            Assert.That(result, Is.EqualTo(2.5));
        }

        [Test]
        public static void FindMedianSortedArraysInBinarySearch_Test()
        {
            // arrange
            int[] numFirst = { 1, 2 };
            int[] numSecond = { 3, 4 };
            Console.WriteLine();
            Console.WriteLine("SearchOps.FindMedianSortedArraysInBinarySearch [{0}], [{1}]", string.Join(" ", numFirst), string.Join(" ", numSecond));

            // act
            var result = SearchOps.FindMedianSortedArraysInBinarySearch(numFirst, numSecond);

            // assert
            Console.WriteLine($"=> {result}");
            Assert.That(result, Is.EqualTo(2.5));
        }

        [Test]
        public void FindKthLargest_Test()
        {
            // arrange
            var nums = new int[] { 3, 2, 1, 5, 6, 4 };
            int k = 2;
            Console.WriteLine();
            Console.WriteLine($"SearchOps.FindKthLargest: k = {k}, nums = {string.Join(",", nums)}");
            
            // act
            var result = SearchOps.FindKthLargest(nums, k);
            
            // assert
            Console.WriteLine($"=> {result}");
            Assert.That(result, Is.EqualTo(5));
        }

        [Test]
        public void FindDifference_Test()
        {
            // arrange
            var nums1 = new int[] {1, 2, 3 };
            var nums2 = new int[] {2, 4, 6 };

            Console.WriteLine();
            Console.WriteLine($"SearchOps.FindDifference: s = {string.Join(",", nums1)}, t = {string.Join(", ", nums2)}");
            
            // act
            var result = SearchOps.FindDifference(nums1, nums2);
            
            // assert
            Console.WriteLine($"=> 1: {string.Join(", ", result[0])}");
            Console.WriteLine($"=> 2: {string.Join(", ", result[1])}");

            Assert.That(result.Count, Is.EqualTo(2));
        }

        [Test]
        public void FindDifference_LINQ_Test()
        {
            // arrange
            var nums1 = new int[] { 1, 2, 3 };
            var nums2 = new int[] { 2, 4, 6 };

            Console.WriteLine();
            Console.WriteLine($"SearchOps.FindDifference_LINQ: s = {string.Join(",", nums1)}, t = {string.Join(", ", nums2)}");

            // act
            var result = SearchOps.FindDifference_LINQ(nums1, nums2);

            // assert
            Console.WriteLine($"=> 1: {string.Join(", ", result[0])}");
            Console.WriteLine($"=> 2: {string.Join(", ", result[1])}");

            Assert.That(result.Count, Is.EqualTo(2));
        }
    }
}
