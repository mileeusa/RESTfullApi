using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecursiveInActions.src
{
    public class RobberyOps
    {
        //
        // You are a professional robber planning to rob houses along a street. Each house
        // has a certain amount of money stashed, the only constraint stopping you from
        // robbing each of them is that adjacent houses have security systems
        // connected and it will automatically contact the police if two adjacent
        // houses were broken into on the same night.
        //
        // Given an integer array nums representing the amount of money of each house,
        // return the maximum amount of money you can rob tonight without alerting the police.
        //
        // LeetCode 198. House Robber
        //
        public static int Rob(int[] nums)
        {
            if (nums.Length == 1) return nums[0];
            var memo = new int[nums.Length];
            Array.Fill(memo, -1);

            return RobFrom(0, nums, memo);
        }

        private static int RobFrom(int index, int[] nums, int[] memo)
        {
            if (index >= nums.Length) return 0;

            if (memo[index] > -1) return memo[index];

            int ans = Math.Max(
                RobFrom(index + 1, nums, memo), // skip current house and consider next one
                RobFrom(index + 2, nums, memo) + nums[index] // rob current house and skip the next one
                );

            memo[index] = ans;
            return ans;
        }
    }
}
