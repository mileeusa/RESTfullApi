using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DynamicProgrammingInActions.src
{
    public class RobHouseOps
    {
        /// Given a list of integers, write a function that returns the largest sum of non-adjacent numbers. 
        /// Numbers can be 0 or negative. For example, [2, 4, 6, 2, 5] should return 13, since we pick 
        /// 2, 6, and 5. [5, 1, 1, 5] should return 10, since we pick 5 and 5.
        /// 
        /// Follow-up: Can you do this in O(N) time and constant space?
    
        ///
        /// You are a professional robber planning to rob houses along a street. Each house
        /// has a certain amount of money stashed, the only constraint stopping you from
        /// robbing each of them is that adjacent houses have security systems
        /// connected and it will automatically contact the police if two adjacent
        /// houses were broken into on the same night.
        ///
        /// Given an integer array nums representing the amount of money of each house,
        /// return the maximum amount of money you can rob tonight without alerting the police.
        ///
        /// LeetCode 198. House Robber
        ///
        public static int Rob(int[] nums)
        {
            if (nums.Length == 1) return nums[0];

            var dp = new int[nums.Length];
            dp[0] = nums[0];
            dp[1] = Math.Max(nums[0], nums[1]);

            for (int i = 2; i < nums.Length; i++)
            {
                dp[i] = Math.Max(dp[i - 1], dp[i - 2] + nums[i]);
            }

            return dp[^1];
        }        
    }
}
