using FluentAssertions;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace ArrayInActions.src
{
    public class MaxOps
    {
        //
        // There is a biker going on a road trip. The road trip consists
        // of n + 1 points at different altitudes. The biker starts
        // his trip on point 0 with altitude equal 0.
        //
        // You are given an integer array gain of length n where gain[i]
        // is the net gain in altitude between points i​​​​​​ and i + 1
        // for all(0 <= i<n). Return the highest altitude
        // of a point.

        // LeetCode 75:
        //     1732. Find the Highest Altitude
        //
        // Difficulty: Easy
        //
        // Time:  O(n)
        // Space: O(1)
        //
        public static int LargestAltitude(int[] gain)
        {
            int highest = 0;
            int current = 0;

            foreach (var g in gain)
            {
                current += g;
                highest = Math.Max(highest, current);
            }

            return highest;
        }

        //
        // Given an integer array nums, find the contiguous subarray (containing at least one number)
        // which has the largest sum and return its sum.
        //
        // LeetCode 53: Maximum Subarray
        //
        // Time:  O(n)
        // Space: O(1)
        //
        // Difficulty: Medium
        //
        // Kadane's Algorithm
        // 
        public static (int, int, int) MaxSubArray(int[] nums)
        {
            int maxSoFar = nums[0];
            int maxEndingHere = nums[0];
            int left = 0;
            int right = 0;
            for (int i = 1; i < nums.Length; i++)
            {
                //maxEndingHere = Math.Max(nums[i], maxEndingHere + nums[i]);
                //maxSoFar = Math.Max(maxSoFar, maxEndingHere);
                int sum = maxEndingHere + nums[i];
                if (sum > nums[i])
                {
                    maxEndingHere = sum;
                }
                else
                {
                    maxEndingHere = nums[i]; // reset
                    left = i;
                }

                if (maxSoFar < maxEndingHere)
                {
                    maxSoFar = maxEndingHere;
                    right = Math.Max(right, i);
                }
            }
            return (maxSoFar, left, right);
        }

        //
        // Given a binary array nums and an integer k, return the maximum number of consecutive 1's in the array
        // if you can flip at most k 0's.
        //
        // Idea:
        //   Maintain a window [left, right] that contains at most k zeros.
        //   Expand right to include new elements.
        //   Count zeros in the window.
        //   If zeros exceed k, move left forward until the window is valid again.
        //   Track the maximum window size.
        //
        // LeetCode 75:
        //    1004. Max Consecutive Ones III
        //
        // Time:  O(n)
        // Space: O(1)
        //
        // Difficulty: Medium
        //
        public static int LongestOnes(int[] nums, int k)
        {
            int left = 0;
            int maxLen = 0;
            int zeroCount = 0;
            for (int right = 0; right < nums.Length; right++)
            {
                if (nums[right] == 0)
                {
                    zeroCount++;
                }
                while (zeroCount > k)
                {
                    if (nums[left] == 0)
                    {
                        zeroCount--;
                    }
                    left++;
                }
                maxLen = Math.Max(maxLen, right - left + 1);
            }
            return maxLen;
        }

        // 
        // Given a binary array nums, return the maximum number of consecutive 1's in the array
        // if you can flip at most one 0.
        //
        // LeetCode 487: Max Consecutive Ones II
        //
        // Time:  O(n)
        // Space: O(1)
        //
        // Difficulty: Medium
        //
        public static int LongestOnes(int[] nums)
        {
            int maxCount = 0;
            int left = 0;
            int zeroCount = 0;

            for (int right = 0; right < nums.Length; right++)
            {
                if (nums[right] == 0)
                {
                    zeroCount++;
                }
                while (zeroCount > 1)
                {
                    if (nums[left] == 0)
                    {
                        zeroCount--;
                    }
                    left++;
                }
                maxCount = Math.Max(maxCount, right - left + 1);
            }
            return maxCount;
        }

        //
        // Given a binary array nums, return the length of the longest subarray
        // containing only 1's after deleting exactly one element from the array.
        //
        // LeetCode 1493: Longest Subarray of 1's After Deleting One Element
        //
        // Time:  O(n)
        // Space: O(1)
        //
        // Difficulty: Medium
        //
        public static int LongestOnesWithOneDeletion(int[] nums)
        {
            int maxCount = 0;
            int left = 0;
            int zeroCount = 0;

            for (int right = 0; right < nums.Length; right++)
            {
                if (nums[right] == 0)
                {
                    zeroCount++;
                }
                while (zeroCount > 1) // <== !!!
                {
                    if (nums[left] == 0)
                    {
                        zeroCount--;
                    }
                    left++;
                }
                maxCount = Math.Max(maxCount, right - left); // <== !!!
            }
            return maxCount;
        }

        // Alternative implementation using two pointers
        // to track the last zero index
        // 
        // Time:  O(n)
        // Space: O(1)
        //
        // Difficulty: Medium
        //
        public static int LongestOnesWithOneDeletion_TwoPointers(int[] nums)
        {
            int maxCount = 0;
            int left = 0;
            int lastZeroIndex = -1; // Index of the last zero encountered

            for (int right = 0; right < nums.Length; right++)
            {
                if (nums[right] == 0)
                {
                    left = lastZeroIndex + 1;
                    lastZeroIndex = right;
                }

                maxCount = Math.Max(maxCount, right - left);
            }

            return maxCount;
        }

        //
        // Given a binary array nums, return the maximum number of consecutive 1's in the array.
        //
        // LeetCode 485: Max Consecutive Ones
        //
        // Time:  O(n)
        // Space: O(1)
        //
        // Difficulty: Easy
        //
        public static int FindMaxConsecutiveOnes(int[] nums)
        {
            int maxCount = 0;
            int currentCount = 0;

            foreach (var num in nums)
            {
                if (num == 1)
                {
                    currentCount++;
                    maxCount = Math.Max(maxCount, currentCount);
                }
                else
                {
                    currentCount = 0;
                }
            }
            return maxCount;
        }

        // 
        // You are given an array happiness of length n, and a positive integer k.
        //
        // There are n children standing in a queue, where the ith child has
        // happiness value happiness[i]. You want to select k children from
        // these n children in k turns.
        //
        // In each turn, when you select a child, the happiness value of all the
        // children that have not been selected until now will decrease by 1.
        //
        // Note that the happiness value cannot become negative and gets
        // decremented only if it is positive.
        //
        // Return the maximum sum of the happiness values of the selected children
        // you can achieve by selecting k children.
        //
        // LeetCode 3075. Maximum Happiness of Selected Children
        //
        public static long MaximumHappinessSum(int[] happiness, int k)
        {
            // sort the happiness based on value in decreacending
            Array.Sort(happiness, (a, b) => b.CompareTo(a));
            long sum = 0;

            for (int i = 0; i < happiness.Length && i < k; i++)
            {
                int current = happiness[i] - i;
                if (current < 0) break;

                sum += current;
            }

            return sum;
        }
    }
}
