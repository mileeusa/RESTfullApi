using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DynamicProgrammingInActions.src
{
    public class LongestContinuousIncreasingStringOps
    {
        //
        // Given an integer array nums, return the length of the longest
        // continuous increasing subsequence. The subsequence must be
        // strictly increasing.
        //
        // A continuous increasing subsequence is defined by
        // a subarray (consecutive elements) where each element is
        // strictly greater than the previous one.
        // 
        // LeetCode 674: Longest Continuous Increasing Subsequence
        //
        // Time complexity:  O(n)
        // Space complexity: O(1)
        //
        // Difficulty: Easy
        //
        public static int FindLengthOfLCIS(int[] nums)
        {
            if (nums == null || nums.Length == 0) return 0;

            int curLen = 1;
            int maxLen = 1;

            for (int i = 1; i < nums.Length; i++)
            {
                if (nums[i] > nums[i - 1])
                {
                    curLen++;
                    maxLen = Math.Max(maxLen, curLen);
                }
                else
                {
                    curLen = 1;
                }
            }

            return maxLen;
        }        
    }
}
