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
        // Time complexity: O(N);
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
        // Time complexity:  O(nlog[(max-min)/10^-5])
        // Space complexity: O(1)
        //
        // Dificult: Hard
        //
        public static double FindMaxAverageII(int[] nums, int k)
        {
            if (nums == null || nums.Length < k || k == 0) return 0;

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
                if (Check(nums, k, mid))
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


        //
        // Check(...) - check if there is a subarray of length >= k with average >= mid
        //
        private static bool Check(int[] nums, int k, double mid)
        {
            double sum = 0;
            double prev = 0;
            double min = 0;

            for (int i = 0; i < k; i++)
                sum += nums[i] - mid;

            if (sum >= 0) return true;

            for (int i = k; i < nums.Length; i++)
            {
                sum += nums[i] - mid;
                prev += nums[i - k] - mid;
                min = Math.Min(min, prev);

                if (sum >= min) return true;
            }

            return false;
        }
    }
}
