using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArrayInActions.src
{
    public class MoveOps
    {
        // 
        // Move all zeroes in the array to the end while maintaining the relative order of non-zero elements.
        //
        // Example:
        //   Input: [0,1,0,3,12]
        //   Output: [1,3,12,0,0]
        //
        // Constraints:
        //   1. The operation must be done in-place without making a copy of the array.
        //   2. Minimize the total number of operations.
        //
        // Complexity Analysis:
        //   Time: O(n), where n is the number of elements in the array. We traverse the array twice.
        //   Space: O(1), since we are not using any extra space that grows with input size.
        //
        // Approach:
        //   1. First Pass: Iterate through the array and copy all non-zero elements to the front.
        //   2. Second Pass: Fill the remaining positions in the array with zeroes.
        //
        // Alternative Approach:
        //   Use a two-pointer technique to swap non-zero elements with zeroes in a single pass.
        //   This reduces the number of operations by eliminating the need for a second pass.
        //
        // Complexity Analysis for Alternative Approach:
        //   Time: O(n), where n is the number of elements in the array. We traverse the array once.
        //   Space: O(1), since we are not using any extra space that grows with input size.
        //
        // Difificulty: Easy
        //
        public static void MoveZeroes(int[] nums)
        {
            if (nums == null || nums.Length == 0) return;

            int index = 0;
            for (int i = 0; i < nums.Length; i++)
            {
                if (nums[i] != 0)
                {
                    nums[index++] = nums[i];
                }
            }

            for (int i = index; i < nums.Length; i++)
            {
                nums[i] = 0;
            }
        }

        public static void MoveZeroes_Two(int[] nums)
        {
            if (nums == null || nums.Length == 0) return;

            int left = 0;
            for (int i = 0; i < nums.Length; i++)
            {
                if (nums[i] != 0)
                {
                    (nums[left], nums[i]) = (nums[i], nums[left]);
                    left++;
                }
            }
        }
    }
}
