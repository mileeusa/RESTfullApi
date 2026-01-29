using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArrayInActions.src
{
    public class PairOps
    {
        //
        // Given an array of integers nums and an integer k, return the maximum number of operations
        // you can perform on the array such that the sum of the two elements in each operation is equal to k.
        //
        // Example:
        //   Input: nums = [1,2,3,4], k = 5
        //   Output: 2
        //   Explanation: Starting with nums = [1,2,3,4]:
        //     - Remove the elements 1 and 4, then nums = [2,3]
        //     - Remove the elements 2 and 3, then nums = []
        //     There are no more pairs that sum up to 5, so a total of 2 operations are performed.
        // Constraints:
        //   1. 1 <= nums.length <= 10^5
        //   2. 1 <= nums[i] <= 10^9
        //   3. 1 <= k <= 10^9
        //
        // Complexity Analysis:
        //   Time:  O(n log n) for the sorting approach
        //                     O(n) for the hashtable approach
        //   Space: O(1) for the sorting approach
        //                     O(n) for the hashtable approach
        //
        // Difficulty: Medium
        //
        public static int MaxOperations(int[] nums, int k)
        {
            if (nums == null || nums.Length == 1) return 0;

            Array.Sort(nums);
            int left = 0;
            int right = nums.Length - 1;

            int count = 0;

            while (left < right)
            {
                int sum = nums[left] + nums[right];

                if (sum == k)
                {
                    count++;
                    left++;
                    right--;
                }
                else if (sum < k)
                {
                    if (nums[left] < nums[right])
                    {
                        left++;
                    }
                    else
                    {
                        right--;
                    }
                }
                else
                {
                    if (nums[left] < nums[right])
                    {
                        right--;
                    }
                    else
                    {
                        left++;
                    }
                }
            }

            return count;
        }

        //
        // Alternative approach using Hashtable
        //
        // Time:  O(n)
        // Space: O(n)
        //
        public static int MaxOperations_Hashtable(int[] nums, int k)
        {
            if (nums == null || nums.Length == 1) return 0;

            var freq = new Dictionary<int, int>();
            int count = 0;

            foreach (var num in nums)
            {
                int target = k - num;

                if (freq.TryGetValue(target, out var f) && f > 0)
                {
                    count++;
                    freq[target] = f - 1;
                }
                else
                {
                    freq[num] = freq.GetValueOrDefault(num) + 1;
                }
            }

            return count;
        }
    }
}
