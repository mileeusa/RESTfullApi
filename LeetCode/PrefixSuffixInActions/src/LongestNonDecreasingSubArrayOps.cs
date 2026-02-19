using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrefixSuffixInActions.src
{
    public class LongestNonDecreasingSubArrayOps
    {
        // 
        // LeetCode 3738. Longest Non-Decreasing Subarray After Replacing at Most One Element
        //
        //
        public static int LongestSubarrayAtMostOneReplacement(int[] nums)
        {
            if (nums == null || nums.Length == 0) return 0;

            if (nums.Length == 1) return 1;

            int n = nums.Length;

            int[] prefix = new int[n];
            int[] suffix = new int[n];

            // compute prefix
            prefix[0] = 1;
            for (int i = 1; i < n; i++)
                prefix[i] = (nums[i] >= nums[i - 1]) ? prefix[i - 1] + 1 : 1;

            // compute suffix
            suffix[n - 1] = 1;
            for (int i = n - 2; i >= 0; i--)
                suffix[i] = (nums[i] <= nums[i + 1]) ? suffix[i + 1] + 1 : 1;

            int ans = 0;
            // without replacement
            for (int i = 0; i < n; i++)
                ans = Math.Max(ans, prefix[i]);

            // we can increase by 1 if array is not fully non-decreasing
            if (ans != n)
                ans = ans + 1;

            // try replacing nums[i]
            for (int i = 1; i < n - 1; i++)
                if (nums[i - 1] <= nums[i + 1])
                    ans = Math.Max(ans, prefix[i - 1] + 1 + suffix[i + 1]);

            return ans;
        }
    }
}
