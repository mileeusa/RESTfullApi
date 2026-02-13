using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DynamicProgrammingInActions.src
{
    public class SubarrayOps
    {
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
                    min_sum = sum;

                if (sum - min_sum > max_sum)
                    max_sum = sum - min_sum;
            }

            return max_sum;
        }
    }
}
