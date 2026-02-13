using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArrayInActions.src
{
    public class ProductOps
    {
        //
        // LeetCode 238. Product of Array Except Self
        //
        // Given an integer array nums, return an array answer such that answer[i] is equal
        // to the product of all the elements of nums except nums[i].
        // The product of any prefix or suffix of nums is guaranteed to fit in a 32-bit integer.
        // You must write an algorithm that runs in O(n) time and without using the division operation.
        //
        // Example 1:
        //   Input: nums = [1,2,3,4
        //
        //   Output: [24,12,8,6]
        //
        // Time complexity: O(N)
        // Space complexity: O(1) (excluding the output array)
        //
        // Difficulty: Medium
        //
        // product_except_self[i] = (product of elements to the LEFT of i) × (product of elements to the RIGHT of i)
        //
        public static int[] ProductExceptSelf(int[] nums)
        {
            var ans = new int[nums.Length];

            // build prefix products (left -> right)
            int prod = 1;
            for (int i = 0; i < nums.Length; i++)
            {
                ans[i] = prod;
                prod *= nums[i];
            }

            // multiply by suffix products (right -> left)
            prod = 1;
            for (int i = nums.Length - 1; i >= 0; i--)
            {
                ans[i] *= prod;
                prod   *= nums[i];                
            }

            return ans;
        }
    }
}
