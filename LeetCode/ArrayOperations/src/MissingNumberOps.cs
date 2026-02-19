using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArrayInActions.src
{
    public class MissingNumberOps
    {
        //
        // You are given an unsorted array of integers nums. Your task is to find the smallest positive integer
        // that does not appear in the array.
        //
        // Clear problem description:
        //   You are given an unsorted integer array, from which you can infer the value range is [1, n]
        //   inclusively, where n is the length of the array, find the very first one not in that range.
        //
        // Constraints:
        //  - Your solution must run in O(n) time.
        //  - You can only use O(1) extra space (modify the array in-place).
        //
        // LeetCode 41: First Missing Positive
        //
        // Time complexity:  O(n)
        // Space complexity: O(1)
        //
        // Difficulty: Hard
        //
        public static int FirstMissingPositive(int[] nums)
        {
            int n = nums.Length;

            for (int i = 0; i < n; i++)
            {
                while (nums[i] > 0 && nums[i] <= n && nums[nums[i] - 1] != nums[i])
                {
                    // swap
                    (nums[nums[i] - 1], nums[i]) = (nums[i], nums[nums[i] - 1]);
                }
            }

            for (int i = 0; i < n; i++)
            {
                if (nums[i] != i + 1)
                {
                    return i + 1;
                }
            }

            return n + 1;
        }
    }
}
