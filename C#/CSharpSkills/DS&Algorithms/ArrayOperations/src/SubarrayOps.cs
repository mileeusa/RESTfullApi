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
        // Given an integer array nums, find a subarray that has the largest product, and
        // return the product.
        //
        // The test cases are generated so that the answer will fit in a 32-bit integer.
        //
        // Note that the product of an array with a single element is the value of that element.
        //
        // LeetCode 152: Maximum Product Subarray
        //
        // Time:  O(N)
        // Space: O(1)
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
