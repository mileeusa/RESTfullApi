using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArrayInActions.src
{
    public class TrapRainWaterOps
    {
        //
        // You are given an integer array height of length n. There are n vertical lines drawn
        // such that the two endpoints of the ith line are (i, 0) and (i, height[i]).
        //
        // Find two lines that together with the x-axis form a container, such that the
        // container contains the most water.
        //
        // Return the maximum amount of water a container can store.
        //
        // LeetCode: 11
        //
        // Use two pointers, keep moving either left and/or right to calculate
        // the max volume of water
        //
        // Time:  O(N)
        // Space: O(1)
        //
        // Interview Point: The two-pointer approach achieves the optimal linear-time solution
        // by using the height constraint intelligently.
        //
        public static int MaxWaterArea(int[] height)
        {
            if (height == null || height.Length < 2) return 0;

            int n = height.Length;

            int left = 0;
            int right = n - 1;

            int maxWater = 0;

            while (left < right)
            {
                int width = right - left;
                int h = Math.Min(height[left], height[right]);

                maxWater = Math.Max(maxWater, width * h);

                if (height[left] < height[right])
                {
                    left++;
                }
                else
                {
                    right--;
                }
            }

            return maxWater;
        }

        //
        // Given n non-negative integers representing an elevation map where the width
        // of each bar is 1, compute how much water it can trap after raining.
        //
        // LeetCode: 42
        //
        // Time:  O(N)
        // Space: O(1)
        //
        // Difficulty: Hard
        //
        public static int TrapRainWater(int[] height)
        {
            if (height == null || height.Length == 0)
                return 0;

            int left = 0;
            int right = height.Length - 1;

            int leftMax = 0;
            int rightMax = 0;

            int trappedWater = 0;

            while (left < right)
            {
                if (height[left] < height[right])
                {
                    leftMax = Math.Max(leftMax, height[left]);
                    trappedWater += leftMax - height[left];
                    left++;
                }
                else
                {
                    rightMax = Math.Max(rightMax, height[right]);
                    trappedWater += rightMax - height[right];
                    right--;
                }
            }

            return trappedWater;
        }

        //
        // Calculate how much rain water can be trapped
        //
        // Time:  O(N)
        // Space: O(1)
        //
        // Difficulty: Medium
        //
        public static int Trap(int[] height)
        {
            if (height == null || height.Length == 0)
                return 0;

            int n = height.Length;
            int maxIdx = 0;

            // calculate the highest bar's index
            for (int i = 0; i < n; i++)
            {
                if (height[maxIdx] < height[i])
                {
                    maxIdx = i;
                }
            }

            int trappedWater = 0;
            int max = height[0];
            for (int i = 1; i <= maxIdx; i++)
            {
                trappedWater += Math.Max(0, max - height[i]);

                if (height[i] > max)
                {
                    max = height[i];
                }
            }

            max = height[n - 1];
            for (int i = n - 2; i >= maxIdx; i--)
            {
                trappedWater += Math.Max(0, max - height[i]);
                if (height[i] > max)
                {
                    max = height[i];
                }
            }

            return trappedWater;
        }

        public static int TrapRainWater_DP(int[] height)
        {
            int n = height.Length;
            if (n < 3) return 0;

            var maxLeft  = new int[n]; // maxLeft[i]  - the tallest bar to the left of or at i
            var maxRight = new int[n]; // maxRight[i] - the tallest bar to the right of or at i

            // build left prefix max array
            maxLeft[0] = height[0];
            for (int i = 1; i < n; i++)
            {
                maxLeft[i] = Math.Max(maxLeft[i - 1], height[i]);
            }

            // build right prefix max array
            maxRight[n - 1] = height[n - 1];
            for (int i = n - 2; i >= 0; i--)
            {
                maxRight[i] = Math.Max(maxRight[i + 1], height[i]);
            }

            int trappedWater = 0;
            for (int i = 0; i < n; i++)
            {
                trappedWater += Math.Min(maxLeft[i], maxRight[i]) - height[i];
            }

            return trappedWater;
        }
    }
}
