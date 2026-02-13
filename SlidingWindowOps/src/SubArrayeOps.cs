using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Text;

namespace SlidingWindowInAction.src
{
    public class SubArrayeOps
    {
        //
        //
        //
        public static bool IsSubsequence(string s, string t)
        {
            if (string.IsNullOrEmpty(s))
                return true;

            if (string.IsNullOrEmpty(t) || s.Length > t.Length)
                return false;

            int first = 0;
            for (int second = 0; second < t.Length && first < s.Length; second++)
            {
                if (s[first] == t[second])
                {
                    first++;
                }
            }

            return first == s.Length;

        }

        //
        // You are given an integer array nums.
        //
        // You are allowed to replace at most one element in the array with any
        // other integer value of your choice.
        //
        // Return the length of the longest non-decreasing subarray that
        // can be obtained after performing at most one replacement.
        //
        // An array is said to be non-decreasing if each element is greater than
        // or equal to its previous one (if it exists).
        //
        // LsstCode 3738. Longest Non-Decreasing Subarray After Replacing at Most One Element
        //
        //
        //
        public static int LongestSubarray(int[] nums)
        {
            if (nums == null || nums.Length == 0) return 0;

            int n = nums.Length;

            int left = 0;
            int maxLen = 1;
            int prevLen = 0;

            for (int right = 1; right <= n; right++)
            {
                if (right == n || nums[right - 1] > nums[right])
                {
                    int len = right - left;

                    maxLen = Math.Max(maxLen, len + 1);

                    if (left > 1 && nums[left - 2] <= nums[left])
                        maxLen = Math.Max(maxLen, len + prevLen);

                    if (left > 0 && left + 1 < right && nums[left - 1] <= nums[left + 1])
                        maxLen = Math.Max(maxLen, len + prevLen);

                    prevLen = len;
                    left = right;
                }
            }

            return Math.Min(maxLen, n);
        }
    }
}
