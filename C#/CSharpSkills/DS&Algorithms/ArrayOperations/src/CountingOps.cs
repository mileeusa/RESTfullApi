using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArrayInActions.src
{
    public class CountingOps
    {
        //
        // Given an integer array nums and an integer k, return the kth largest element in the array.
        //
        // Note that it is the kth largest element in the sorted order, not the kth distinct element.
        //
        // 1 <= k <= nums.length <= 10^5
        // -10^4 <= nums[i] <= 10^4
        //
        // LeetCode 75:
        //     215:Kth Largest Element in an Array
        //
        // Difficulty: Medium
        //
        public static int FindKthLargest(int[] nums, int k)
        {
            int[] count = new int[20001];

            foreach (var num in nums)
                count[num + 10000]++;

            for (int i = count.Length - 1; i >= 0; i--)
            {
                if (count[i] > 0)
                {
                    k -= count[i];
                    if (k <= 0) return i - 10000;
                }
            }

            return -1;
        }

        //
        //  Given an array nums with n objects colored red, white, or blue, sort
        //  them in-place so that objects of the same color are adjacent, with
        //  the colors in the order red, white, and blue.
        //
        //  Given an array with values {0,1,2}, sort in-place.
        //
        //  LeetCode 75: 
        //      75: Sort Colors
        //
        // Difificulty: Medium
        //
        public static void SortColors(int[] nums)
        {
            int[] count = new int[3];

            foreach (var num in nums)
                count[num]++;

            int index = 0;
            for (int color = 0; color < 3; color++)
            {
                for (int cnt = 0; cnt < count[color]; cnt++)
                {
                    nums[index++] = color;
                }
            }
        }

        // 
        // Return the majority element in the array
        // 
        // Note: The majority element is the element that appears more than ⌊n / 2⌋ times. You may assume 
        // that the majority element always exists in the array.
        // 
        // Difficulty: Easy
        //
        public static int MajorityElement(int[] numbers)
        {
            int majNumber = numbers[0];
            int counter = 0;

            for (int i = 0; i < numbers.Length; i++)
            {
                if (majNumber == numbers[i])
                {
                    counter++;
                }
                else
                {
                    counter--;

                    if (counter < 0)
                    {
                        majNumber = numbers[i];
                        counter = 0;
                    }
                }
            }
            return majNumber;
        }

        //
        // Find the element appearing more than n/2 times.
        //
        // Leetcode 169: Majority Element
        //
        // Difficulty: Easy
        //
        public static int MajorityElement_CountingTechnique(int[] nums)
        {
            var map = new Dictionary<int, int>();

            foreach(var n in nums)
            {
                map[n] = map.GetValueOrDefault(n) + 1;

                if (map[n] > nums.Length / 2)
                {
                    return n;                    
                }
            }

            return -1;
        }
    }
}
