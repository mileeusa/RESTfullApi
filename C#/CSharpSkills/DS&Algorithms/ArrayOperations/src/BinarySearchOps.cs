using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace ArrayInActions.src
{
    public class BinarySearchOps
    {
        //
        // Given an array nums, we call a number nums[i] binary searchable if all the numbers
        // to the left of nums[i] are smaller than or equal to nums[i] and all the
        // numbers to the right of nums[i] are greater than or equal to nums[i].
        //
        // Return the count of binary searchable numbers in nums.
        //
        // LeetCode 1966: Binary Searchable Numbers in an Unsorted Array
        //
        // Time:  O(N)
        // Space: O(N)
        //
        // Dificulty: Medium
        //
        public static int BinarySearchableNumbers(int[] nums)
        {
            int n = nums.Length;
            int[] prefixMax = new int[n];
            int[] suffixMin = new int[n];

            // scan prefix max
            prefixMax[0] = nums[0];
            for (int i = 1; i < n; i++)
            {
                prefixMax[i] = Math.Max(prefixMax[i-1], nums[i]);
            }

            // scan suffix min
            suffixMin[n - 1] = nums[n - 1];
            for (int i = n - 2; i >= 0; i--)
            {
                suffixMin[i] = Math.Min(suffixMin[i+1], nums[i]);
            }

            // count binary searchable numbers
            int count = 0;
            for (int i = 0; i < n; i++)
            {
                if (nums[i] >= prefixMax[i] && nums[i] <= suffixMin[i])
                {
                    count++;
                }
            }

            return count;
        }

        public static int BinarySearchableNumbers_Monotonic(int[] nums)
        {
            int n = nums.Length;
            if (n == 0) return 0;

            var list = new List<int>();
            int left = int.MinValue;

            foreach (int v in nums)
            {
                // Maintain monotonic increasing stack
                while (list.Count > 0 && list[list.Count - 1] > v)
                {
                    list.RemoveAt(list.Count - 1);
                }

                // Only push if greater than all elements on the left
                if (v > left)
                {
                    list.Add(v);
                }

                // Update left max
                left = Math.Max(left, v);
            }

            return list.Count;
        }
    }
}
