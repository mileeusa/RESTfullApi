using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace ArrayInActions.src
{
    public class SubarrayOps
    {
        //
        // Generate all the subarrays
        //
        // Example:
        //   input: [2, 4, 7]
        //   output:
        //          2
        //          2, 4
        //          2, 4, 7
        //          4
        //          4, 7
        //          7
        //
        // Time complexity: O(N^3)
        // Space complexity: O(1)
        //
        public static IList<IList<int>> GetAllSubarrays(int[] arr)
        {
            var ans = new List<IList<int>>();

            int n = arr.Length;

            for (int i = 0; i < n; i++)
            {
                for (int j = i; j < n; j++)
                {
                    var curr = new List<int>();
                    for (int k = i; k <= j; k++)
                    {
                        curr.Add(arr[k]);
                    }

                    ans.Add(curr);
                }
            }

            return ans;
        }

        public static IList<IList<int>> GetAllSubarraysII(int[] arr)
        {
            var ans = new List<IList<int>>();

            int n = arr.Length;

            for (int i = 0; i < n; i++)
            {
                var curr = new List<int>();

                for (int j = i; j < n; j++)
                {
                    curr.Add(arr[j]);
                }

                ans.Add(curr);
            }

            return ans;
        }

        //
        // Given an integer array nums, find the contiguous subarray (containing at least one number)
        // which has the largest sum and return its sum.
        //
        // LeetCode 53: Maximum Subarray
        //
        // Time complexity:  O(n)
        // Space complexity: O(1)
        //
        // Difficulty: Medium
        //
        // **** Kadane's Algorithm ****
        // 
        // Time complexity: O(N)
        // Space complexity: O(1)
        //
        public static int MaxSubArray(int[] nums)
        {
            int max = nums[0];
            int currMax = nums[0];

            for (int i = 1; i < nums.Length; i++)
            {
                currMax = Math.Max(nums[i], currMax + nums[i]);
                max = Math.Max(max, currMax);
            }
            return max;
        }

        //
        // find thr maximum sum over all subarrays of a given array of integer
        //
        public static int MaxSubArray_DP(int[] nums)
        {
            int min_sum = 0;
            int max_sum = 0;
            int sum = 0;

            for (int i = 0; i < nums.Length; i++)
            {
                sum += nums[i];

                if (sum < min_sum)
                {
                    min_sum = sum;
                }

                if (sum - min_sum > max_sum)
                {
                    max_sum = sum - min_sum;
                }
            }

            return max_sum;
        }

        public static (int, int, int) ReturnMaxSubArray(int[] nums)
        {
            int max = nums[0];
            int maxEndingHere = nums[0];

            int left = 0;
            int right = 0;

            for (int i = 1; i < nums.Length; i++)
            {
                int sum = maxEndingHere + nums[i];
                if (sum > nums[i])
                {
                    maxEndingHere = sum;
                }
                else
                {
                    maxEndingHere = nums[i]; // reset
                    left = i;
                }

                if (max < maxEndingHere)
                {
                    max = maxEndingHere;
                    right = Math.Max(right, i);
                }
            }
            return (max, left, right);
        }

        //
        // Given an integer array nums, find a subarray that has the largest product, and
        // return the product.
        //
        // The test cases are generated so that the answer will fit in a 32-bit integer.
        //
        // Note that the product of an array with a single element is the value of that element.
        //
        // LeetCode 152: Maximum Product Subarray
        //
        // Time complexity:  O(N)
        // Space complexity: O(1)
        //
        // The Twist: A very small negative number multiplied by another negative number
        //            becomes a very large positive number.
        //
        // The Trick: Keep track of both the maximum and minimum product up to the
        //            current position.
        //
        public static int MaxProduct(int[] nums)
        {
            int curMax = nums[0];
            int curMin = nums[0];

            int result = nums[0];

            for (int i = 1; i < nums.Length; i++)
            {
                int x = nums[i];

                if (x < 0) // if negative, swap
                {
                    (curMax, curMin) = (curMin, curMax);
                }

                curMax = Math.Max(x, curMax * x);
                curMin = Math.Min(x, curMin * x);

                result = Math.Max(result, curMax);
            }

            return result;
        }
    }
}
