using FluentAssertions;
using Newtonsoft.Json.Linq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArrayInActions.src
{
    public class AverageOps
    {
        //
        // You are given an integer array nums consisting of n elements, and an integer k.
        //
        // Find a contiguous subarray whose length is equal to k that has the maximum
        // average value and return this value.
        //
        // Any answer with a calculation error less than 1e-5 will be accepted.
        //
        // LeetCode 643. Maximum Average Subarray I
        //
        // Time: O(N);
        // Space O(1)
        //
        // Dificult: Easy
        //
        public static double FindMaxAverageI(int[] nums, int k)
        {
            if (nums == null || nums.Length <= k || k == 0) return 0;

            int maxWindow = 0;
            for (int i = 0; i < k; i++)
            {
                maxWindow += nums[i];
            }

            int maxSum = maxWindow;

            for (int i = k; i < nums.Length; i++)
            {
                maxWindow += nums[i] - nums[i - k];
                maxSum = Math.Max(maxSum, maxWindow);
            }

            return (double)maxSum / k;
        }

        //
        // You are given an integer array nums consisting of n elements, and an integer k.
        //
        // Find a contiguous subarray whose length is greater than or equal to k
        // that has the maximum average value and return this value.
        //
        // Any answer with a calculation error less than 1e-5 will be accepted.
        //
        // LeetCode: 644. Maximum Average Subarray II
        //
        // Time:
        // Space:
        //
        // Dificult: Head
        //
        public static double FindMaxAverageII(int[] nums, int k)
        {
            if (nums == null || nums.Length < k || k == 0)  return 0;

            double right = nums[0];
            double left = nums[0];

            foreach (var num in nums)
            {
                if (right < num) right = num;
                if (left > num) left = num;
            }

            while (right - left > 1e-5)
            {
                double mid = (left + right) / 2;
                if (CanFind(nums, k, mid))
                {
                    left = mid;
                }
                else
                {
                    right = mid;
                }
            }

            return left;
        }

        private static bool CanFind(int[] nums, int k, double mid)
        {
            int n = nums.Length;
            var prefix = new double[n + 1];

            for (int i = 0; i < n; i++)
            {
                prefix[i + 1] = prefix[i] + (nums[i] - mid);
            }

            double minPrefix = 0;
            for (int i = k; i < n; i++)
            {
                minPrefix = Math.Min(minPrefix, prefix[i-k]);

                if (prefix[i] >= minPrefix)
                    return true;
            }

            return false;
        }
    }
}
