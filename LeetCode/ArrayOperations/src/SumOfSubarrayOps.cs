using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace ArrayInActions.src
{
    public class SumOfSubarrayOps
    {
        //
        // Given an array of integers and an integer k, you need to find the total number of continuous
        // subarrays whose sum equals to k.
        //
        // The Logic: If the difference between the current prefix sum and k has been seen before, it
        // means a subarray with sum k exists between those two points.
        //
        // The Core Logic:
        //   "The Gap"Think of the total sum from the beginning as a running total. If the sum
        //   from the start to index j is A. If the sum from the start to an earlier index i
        //   is B.The sum of the elements between i and j is exactly A - B.
        //
        //   So, if we are looking for a subarray that sums to K, we are looking for a mathematical gap where:
        //
        //     CurrentSum - PreviousSum = K
        //
        //   Which is the same as:
        //     PreviousSum = CurrentSum - K
        //
        // Time complexity: O(N)
        // Space complexity: O(1)
        //
        public static int SubarraySum(int[] nums, int k)
        {
            int count = 0;
            int currSum = 0;

            // prefix sum -> frequency
            var prefixSum = new Dictionary<int, int>();

            prefixSum[0] = 1; // we handle the case where the subarray starting from the very beginning!!!

            foreach (int num in nums)
            {
                currSum += num;
                if (prefixSum.TryGetValue(currSum - k, out var val))
                    count += val;

                prefixSum[currSum] = prefixSum.GetValueOrDefault(currSum, 0) + 1;
            }

            return count;
        }

        //
        // You are given an array of positive integers and a target value. Find the length of
        // the longest subarray where the sum of its elements is less than or equal to k.
        //
        // Note: If the array contains negative numbers, the sliding window technique fails,
        //       and you must use a prefix sum approach with a monotonic queue.
        //
        // Time complexity: O(N) - the most reliable for arrays with non-negative integers
        // Space complexity: O(1)
        //
        public int LongestSubarray(int[] nums, int k)
        {
            int left = 0;
            int maxLen = 0;
            int currentSum = 0;

            for (int right = 0; right < nums.Length; right++)
            {
                currentSum += nums[right];

                while (currentSum > k && left <= right)
                {
                    currentSum -= nums[left];
                    left++;
                }

                maxLen = Math.Max(maxLen, right - left + 1);
            }

            return maxLen;
        }

        //
        // Given an integer array nums and an integer k, return true if nums has a good subarray or false otherwise.
        // A good subarray is a subarray where:
        //   - its length is at least two, and
        //   - the sum of the elements of the subarray is a multiple of k.
        //
        // Note that:
        //   - A subarray is a contiguous part of the array.
        //   - An integer x is a multiple of k if there exists an integer n such that x = n * k. 0 is always a multiple of k.
        //
        // LeetCode 523. Continuous Subarray Sum
        //
        // Time complexity: O(N)
        // Space complexity: O(N)
        //
        public static bool CheckSubarraySum(int[] nums, int k)
        {
            var prefixSum = new Dictionary<int, int>(); // num -> index

            int prefixMod = 0;
            prefixSum[0] = -1;

            for (int i = 0; i < nums.Length; i++)
            {
                prefixMod = (prefixMod + nums[i] % k + k) % k;

                if (prefixSum.TryGetValue(prefixMod, out var idx) && i - idx >= 2)
                    return true;

                if (!prefixSum.ContainsKey(prefixMod))
                    prefixSum[prefixMod] = i;
            }

            return false;
        }

        //
        // Given an integer array nums and an integer k, return the number of non-empty subarrays
        // that have a sum divisible by k.
        // A subarray is a contiguous part of an array.
        //
        // LeetCode 974. Subarray Sums Divisible
        //
        public static int SubarraysDivByK(int[] nums, int k)
        {
            var prefixSum = new Dictionary<int, int>();
            prefixSum[0] = 1;

            int prefixMod = 0;
            int ans = 0;
            foreach (var num in nums)
            {
                prefixMod = (prefixMod + num % k + k) % k;

                if (prefixSum.TryGetValue(prefixMod, out var val))
                {
                    ans += val;
                    prefixSum[prefixMod]++;
                }
                else
                    prefixSum[prefixMod] = 1;
            }

            return ans;
        }

        //
        // You are given an array of integers nums and an integer k.
        // Return the maximum sum of a subarray of nums, such that the size of the subarray is divisible by k.
        //
        // LeetCode 3381. Maximum Subarray Sum With Length Divisible by K
        //
        //
        public static long MaxSubarraySum(int[] nums, int k)
        {
            var kSum = new long[k];
            Array.Fill(kSum, long.MaxValue / 2); 
            kSum[k - 1] = 0;

            long maxSum = long.MinValue;
            long prefixSum = 0;

            for (int i = 0; i < nums.Length; i++) {
                prefixSum += nums[i];
                int idx = i % k;
                maxSum = Math.Max(maxSum, prefixSum - kSum[idx]);
                kSum[idx] = Math.Min(prefixSum, kSum[idx]);
            }

            return maxSum;
        }
    }
}
