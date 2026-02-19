using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DynamicProgrammingInActions.src
{
    public class LongestNonDecreasingSubsequenceOps
    {
        //
        // Given an integer array nums, return the length of the longest <<<strictly>>> increasing subsequence.
        //
        // LeetCode 300: Longest Increasing Subsequence
        //
        // dp[i] = length of the LIS ending at index i
        // 
        // Time complexity:  O(n^2)
        // Space complexity: O(n)
        //
        // Difficulty: Medium
        //
        public static int LengthOfLongestIncreasingSubsequence_DP(int[] nums)
        {
            if (nums == null || nums.Length == 0) return 0;

            int n = nums.Length;
            int[] dp = new int[n]; // hold the length of the longest increasing subsequence
            Array.Fill(dp, 1);

            for (int right = 1; right < n; right++)
            {
                for (int left = 0; left < right; left++)
                {
                    if (nums[right] > nums[left])
                    {
                        dp[right] = Math.Max(dp[right], dp[left] + 1);
                    }
                }
            }

            return dp[n-1];
        }

        //
        // LeetCode 300: Longest Increasing Subsequence
        //
        // One-liner intuition (interview gold):
        //   For every length k, I keep the smallest possible tail of an increasing
        //   subsequence of length k. Smaller tails maximize future extension,
        //   and binary search keeps it efficient
        //
        // Time complexity:  O(n log n)
        // Space complexity: O(n)
        //
        public static int LengthOfLongestIncreasingSubsequence_BinarySearch(int[] nums)
        {
            if (nums == null || nums.Length == 0) return 0;

            // tails[i] = the smallest possible tail value of an
            // increasing subsequence of length i + 1
            var tails = new int[nums.Length];
            int size = 0;

            foreach (var num in nums)
            {
                int index = LowerBound(tails, size, num);

                tails[index] = num;

                if (index == size)
                    size++;
            }

            return size;
        }

        // Returns the first index in [0, size) where arr[index] >= target
        private static int LowerBound(int[] arr, int size, int target)
        {
            int left = 0, right = size;

            while (left < right)
            {
                int mid = left + (right - left) / 2;
                if (arr[mid] < target)
                    left = mid + 1;
                else
                    right = mid;
            }

            return left;
        }
    }
}
