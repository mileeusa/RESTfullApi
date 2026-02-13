using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArrayInActions.src
{
    public class EquilibriumIndex
    {
        // To find the all the equilibrium/pivot Index(es), also called a Balance Index.
        //
        // An equilibrium index is an index i such that:
        //
        //  sum(nums[0..i - 1]) == sum(nums[i + 1..n - 1]) <= leftSum + nums[i] + leftSum = total
        // 
        // LeetCode: 724. Find Pivot Index
        //
        // Difificulty: Easy
        //  
        public static List<int> FindEquilibriumIndex(int[] nums)
        {
            List<int> indices = [];

            if (nums == null || nums.Length == 0) return indices;

            int total = 0;
            foreach (var num in nums)
            {
                total += num;
            }

            int leftSum = 0;
            for (int i = 0; i < nums.Length; i++)
            {
                if (leftSum == total - leftSum - nums[i])
                {
                    indices.Add(i);
                }

                leftSum += nums[i];
            }

            return indices;
        }
    }
}
