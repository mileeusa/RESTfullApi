using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using static Microsoft.ApplicationInsights.MetricDimensionNames.TelemetryContext;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace ArrayInActions.src
{
    public class MinOps
    {
        //
        // You are given a binary array nums.
        //
        // You can do the following operation on the array any number of times(possibly zero):
        //   -- Choose any 3 consecutive elements from the array and flip all of them.
        //
        // Flipping an element means changing its value from 0 to 1, and from 1 to 0.
        //
        // Return the minimum number of operations required to make all elements in nums equal
        // to 1. If it is impossible, return -1.
        //
        // LeetCode 3191. Minimum Operations to Make Binary Array Elements Equal to One I
        //
        //
        public static int MinOperations(int[] nums)
        {
            if (nums == null) return -1;

            int flips = 0;
            int n = nums.Length;

            for (int i = 0; i < n - 2; i++)
            {
                if (nums[i] == 0)
                {
                    //for (int j = 0; j < 3; j++)
                    //{ 
                    //    nums[i+j] ^= 1; // flip
                    //}
                    nums[i] = 1;
                    nums[i + 1] = (nums[i + 1] == 0) ? 1 : 0;
                    nums[i + 2] = (nums[i + 2] == 0) ? 1 : 0;

                    flips++;
                }
            }

            // check the remaining element
            if (nums[n-2] == 0 || nums[n-1] == 0)
                return -1;

            return flips;
        }
    }
}
