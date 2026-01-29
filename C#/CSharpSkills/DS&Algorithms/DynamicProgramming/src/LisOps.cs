using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DynamicProgrammingInActions.src
{
    public class LisOps
    {
        // LeetCode 300: Longest Increasing Subsequence
        //
        // dp[i] = length of the LIS ending at index i
        // 
        // Time:  O(n^2)
        // Space: O(n)
        //
        // Difficulty: Medium
        //
        public static int LengthOfLIS_DP(int[] nums)
        {
            if (nums == null || nums.Length == 0) return 0;

            int n = nums.Length;
            int[] dp = new int[n];
            Array.Fill(dp, 1);

            int maxLen = 1;
            for (int right = 1; right < n; right++)
            {
                for (int left = 0; left < right; left++)
                {
                    if (nums[right] > nums[left])
                    {
                        dp[right] = Math.Max(dp[right], dp[left] + 1);
                    }
                }
                maxLen = Math.Max(maxLen, dp[right]);
            }
            return maxLen;
        }

        //
        // LeetCode 300: Longest Increasing Subsequence
        //
        // Time:  O(n log n)
        // Space: O(n)
        //
        public static int LengthOfLIS_BinarySearch(int[] nums)
        {
            if (nums == null || nums.Length == 0) return 0;

            /// tails[i] = minimum ending value of an increasing subsequence of length i + 1
            var tails = new List<int>();

            foreach (var num in nums)
            {
                int left = 0, right = tails.Count;
                while (left < right)
                {
                    int mid = left + (right - left) / 2;
                    if (tails[mid] < num)
                    {
                        left = mid + 1;
                    }
                    else
                    {
                        right = mid;
                    }
                }

                if (left == tails.Count)
                {
                    tails.Add(num);
                }
                else
                {
                    tails[left] = num;
                }
            }

            return tails.Count;
        }
    }
}
