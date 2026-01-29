using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Linq.Expressions;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace ArrayInActions.src
{
    public class SearchOps
    {

        // Given an integer array nums, return true if there exists a triple of indices (i, j, k)
        // such that i < j < k and nums[i] < nums[j] < nums[k]. If no such indices exists,
        // return false.

        // LeetCode 75:
        //    334. Increasing Triplet Subsequence
        //
        // Time:  O(n)
        // Space: O(1)
        //
        public static bool IncreasingTriplet(int[] nums)
        {
            int first = int.MaxValue;
            int second = int.MaxValue;

            foreach (var n in nums)
            {
                if (n <= first)
                {
                    first = n;
                }
                else if (n <= second)
                {
                    second = n;
                }
                else
                {
                    return true;
                }
            }
            return false;
        }

        public static int[] FindIncreasingTriplet(int[] nums)
        {
            int first = int.MaxValue;
            int second = int.MaxValue;

            int firstVal = 0;
            int secondVal = 0;

            foreach (var n in nums)
            {
                if (n <= first)
                {
                    first = n;
                    firstVal = n;
                }
                else if (n <= second)
                {
                    second = n;
                    secondVal = n;
                }
                else
                {
                    return new[] { firstVal, secondVal, n };
                }
            }
            return null;
        }

        //
        // Given a non-empty array of integers nums, every element appears twice
        // except for one. Find that single one.
        //
        // You must implement a solution with a linear runtime complexity and
        // use only constant extra space.
        //
        // LeetCode 75:
        //    136. Single Number
        //
        public static int SingleNumber(int[] nums)
        {
            int num = 0;
            foreach (var n in nums)
            {
                num ^= n;
            }

            return num;
        }

        // 
        // Suppose an array of length n sorted in ascending order is rotated between 1 and
        // n times. For example, the array nums = [0,1,2,4,5,6,7] might become:
        //
        //   [4, 5, 6, 7, 0, 1, 2] if it was rotated 4 times.
        //   [0, 1, 2, 4, 5, 6, 7] if it was rotated 7 times.
        //
        // Notice that rotating an array[a[0], a[1], a[2], ..., a[n - 1]] 1 time results in
        // the array[a[n - 1], a[0], a[1], a[2], ..., a[n - 2]].
        //
        // Given the sorted rotated array nums of unique elements, return the minimum
        // element of this array.
        //
        // You must write an algorithm that runs in O(log n) time.
        //
        // LeetCode 153: Find Minimum in Rotated Sorted Array
        //
        // Difficulty: Medium
        //
        public static int FindMinInRotatedSortedArray(int[] nums)
        {
            if (nums == null || nums.Length == 0) return int.MinValue;

            int n = nums.Length;

            if (n == 1) return nums[0];

            int left = 0;
            int right = n - 1;

            if (nums[left] < nums[right]) 
                return nums[left];

            while (left <= right)
            {
                int mid = left + (right - left) / 2;

                // check left/right of mid
                if (nums[mid] > nums[mid + 1])
                    return nums[mid + 1];

                if (nums[mid - 1] < nums[mid])
                    return nums[mid];

                // divide
                if (nums[mid] > nums[0])
                    left = mid + 1;
                else
                    right = mid - 1;
            }

            return int.MinValue;
        }

        //
        // return the index of the target found in the rotated sorted array
        // 
        // Time: O(log n)
        // Space: O(1)
        // 
        public static int SearchInRotatedSortedArray(int[] numbers, int target)
        {
            if (numbers == null || numbers.Length == 0)
            {
                return -1;
            }

            int left = 0;
            int right = numbers.Length - 1;

            while (left <= right)
            {
                int mid = left + (right - left) / 2;

                if (numbers[mid] == target)
                {
                    return mid;
                }

                if (numbers[left] <= numbers[mid]) // left is sorted
                {
                    if (target >= numbers[left] && target < numbers[mid])
                    {
                        right = mid - 1;
                    }
                    else
                    {
                        left = mid + 1;
                    }
                }
                else // right is sorted
                {
                    if (target > numbers[mid] && target <= numbers[right])
                    {
                        left = mid + 1;
                    }
                    else
                    {
                        right = mid - 1;
                    }
                }
            }

            return -1;
        }

        //
        // The median of an array is the middle value when the array is sorted. If the
        // number of elements is odd, the median is the middle element. If even, it
        // is the average of the two middle elements.
        //
        // this algorithm is similar to merge sort, but we just have few pointers 
        // to walk through both arrays to find the median
        // 
        // Time:  O(M+N)
        // Space: O(1)
        //
        // Difficulty: Hard
        //
        public static double FindMedianSortedArrays(int[] a1, int[] a2)
        {
            if (a1 == null)
            {
                throw new ArgumentNullException(nameof(a1), "Input array a1 cannot be null.");
            }
            if (a2 == null)
            {
                throw new ArgumentNullException(nameof(a2), "Input array a2 cannot be null.");
            }

            int total = a1.Length + a2.Length;
            int mid2 = total / 2;

            // two pointers to point to current index in both arrays, respectively
            int p1 = 0;
            int p2 = 0;

            // remember the current and previous elements while merging
            int current = 0;
            int previous = 0;

            for (int i = 0; i <= mid2; i++)
            {
                previous = current;

                if (p1 < a1.Length && (a1[p1] < a2[p2] || p2 >= a2.Length))
                {
                    current = a1[p1++];
                }
                else
                {
                    current = a2[p2++];
                }
            }

            if (total % 2 == 1)
                return current;

            return (current + previous) / 2.0;
        }

        // Key ideas:
        //
        // We partition both arrays such that:
        //   - All elements on the left side of both partitions are ≤ all elements on the right side.
        //
        // We only binary search on the smaller array (a1 here).
        //
        // At each step, we check:
        //   - a1_leftMax <= a2_rightMin
        //   - a2_leftMax <= a1_rightMin
        //
        //   If both are true, we’ve found the correct partition.
        //
        public static double FindMedianSortedArraysInBinarySearch(int[] a1, int[] a2)
        {
            int m = a1.Length;
            int n = a2.Length;
            int total = m + n;

            if(total % 2 == 1)
            {
                return FindKthElement(a1, 0, a2, 0, total / 2 + 1);
            }
            else
            {
                return (FindKthElement(a1, 0, a2, 0, total / 2) +
                        FindKthElement(a1, 0, a2, 0, total / 2 + 1)) / 2.0;
            }

        }

        /// <summary>
        /// Find the k-th smallest element in the union of two sorted arrays using
        /// binary search, without partitioning.
        /// 
        /// Complexity: O(log(m,n))
        /// 
        /// </summary>
        /// <param name="a"></param>
        /// <param name="startA"></param>
        /// <param name="b"></param>
        /// <param name="startB"></param>
        /// <param name="k"></param>
        /// <returns></returns>
        public static double FindKthElement(int[] a, int startA, int[] b, int startB, int k)
        {
            if (startA >= a.Length) return b[startB + k - 1];

            if (startB >= b.Length) return a[startA + k - 1];

            if (k == 1) return Math.Min(a[startA], b[startB]);

            int midA = int.MaxValue;
            int midB = int.MaxValue;

            if (startA + k / 2 - 1 < a.Length)
            {
                midA = a[startA + k / 2 - 1];
            }

            if (startB + k / 2 - 1 < b.Length)
            {
                midB = b[startB + k / 2 - 1];
            }

            if (midA < midB)
            {
                return FindKthElement(a, startA + k / 2, b, startB, k - k / 2);
            }
            else
            {
                return FindKthElement(a, startA, b, startB + k / 2, k - k / 2);
            }
        }

        //
        // Return the kth Largest Element in a Stream
        //
        // LeetCode 75:
        //    215. Kth Largest Element in an Array
        //
        // Quickselect is a partial QuickSort:
        //   Partition the array
        //   Only recurse into the side that contains the kth largest element
        //
        public static int FindKthLargest(int[] nums, int k)
        {
            int n = nums.Length;

            int target = n - k;
            int left = 0;
            int right = n - 1;

            while (true)
            {
                int pivotIndex = RandomizedPartition(nums, left, right);

                if (pivotIndex == target)
                {
                    return nums[pivotIndex];
                }
                else if (pivotIndex < target)
                {
                    left = pivotIndex + 1;
                }
                else
                {
                    right = pivotIndex - 1;
                }
            }
        }

        // Here partition is the core idea behind QuickSort/QuickSelect:
        //
        //   - Choose a pivot (here we choose the rightmost element)
        //   - Rearrange the array so that all elements ≤ pivot are on the left,
        //     and all elements > pivot are on the right
        //   - Return the final index of the pivot
        //
        private static int RandomizedPartition(int[] nums, int left, int right)
        {
            int pivotIndex = new Random().Next(left, right + 1);
            Swap(nums, pivotIndex, right); // Move pivot to end

            int pivot = nums[right]; // choose pivot
            int storeIndex = left;   // boundary for smaller values

            for (int i = left; i < right; i++)
            {
                if (nums[i] <= pivot)
                {
                    Swap(nums, storeIndex, i);
                    storeIndex++;
                }
            }

            Swap(nums, storeIndex, right); // Move pivot to its final place

            return storeIndex;
        }

        private static void Swap(int[] nums, int i, int j)
        {
            (nums[i], nums[j]) = (nums[j], nums[i]);
        }

        //
        // Given two 0-indexed integer arrays nums1 and nums2, return a list answer of size 2 where:
        //   answer[0] is a list of all distinct integers in nums1 which are not present in nums2.
        //   answer[1] is a list of all distinct integers in nums2 which are not present in nums1.
        //
        //   Note that the integers in the lists may be returned in any order.
        //
        // LeetCode 75:
        //     2215 - Find the Difference of Two Arrays
        //
        // Time:  O(m + n)
        // Space: O(m + n)
        //
        public static IList<IList<int>> FindDifference(int[] nums1, int[] nums2)
        {
            var set1 = new HashSet<int>(nums1);
            var set2 = new HashSet<int>(nums2);

            var list1 = new List<int>();
            foreach (var num in set1)
            {
                if (!set2.Contains(num))
                {
                    list1.Add(num);
                }
            }

            var list2 = new List<int>();
            foreach (var num in set2)
            {
                if (!set1.Contains(num))
                {
                    list2.Add(num);
                }
            }

            return [list1, list2];
        }

        public static IList<IList<int>> FindDifference_LINQ(int[] nums1, int[] nums2)
        {
            var set1 = new HashSet<int>(nums1);
            var set2 = new HashSet<int>(nums2);

            var list1 = nums1.Where(c => !set2.Contains(c)).ToList();
            var list2 = nums2.Where(c => !set1.Contains(c)).ToList();

            return [list1, list2];
        }
    }
}