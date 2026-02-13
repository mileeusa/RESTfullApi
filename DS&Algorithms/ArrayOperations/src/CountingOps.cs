using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace ArrayInActions.src
{
    public class CountingOps
    {
        //
        // Give a very good methos to count the number of ones in a 32 bit number. (caution: looping
        // through testing each bit is not a solution)
        //
        public static int CountOnes(int n)
        {
            int count = 0;
            while (n > 0)
            {
                n &= (n - 1); // clear the lowest set bit
                count++;
            }

            return count;
        }

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
                    if (k <= 0)
                        return i - 10000;
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

            foreach (var n in nums)
            {
                map[n] = map.GetValueOrDefault(n) + 1;

                if (map[n] > nums.Length / 2)
                {
                    return n;
                }
            }

            return -1;
        }

        //
        // You are given a positive integer n.
        //
        // For every integer x from 1 to n, we write down the integer obtained by
        // removing all zeros from the decimal representation of x.
        //
        // Return an integer denoting the number of distinct integers written down.
        //
        // Example 1:
        //   Input: n = 10
        //   Output: 9
        //   Explanation: the integers we wrote down are 1, 2, 3, 4, 5, 6, 7, 8, 9, 1.
        //                There are 9 distinct integers(1, 2, 3, 4, 5, 6, 7, 8, 9).
        //
        // Example 2:
        //   Input: n = 352
        //   Output: 290
        //   Explanation:
        //     1-digit numbers: 9
        //     2-digit numbers: 81
        //     ans = 90
        //
        //   Now for 352:
        //     At '3': digits 1–2 → +2 * 81
        //     At '5': digits 1–4 → +4 * 9
        //     At '2': digit 1 → +1
        //     Add valid n → +1
        //     Total = 290
        //
        // LeetCode 3747. Count Distinct Integers After Removing Zeros
        //
        public static long countDistinct(long n)
        {
            string s = n.ToString();
            int len = s.Length;

            long result = 0;
            long power = 9;

            for (int i = 1; i < len; i++)
            {
                result += power;
                power *= 9;
            }

            bool isValid = true;

            for (int i = 0; i < len; i++)
            {
                int digit = s[i] - '0';
                if (digit == 0)
                {
                    isValid = false;
                    break;
                }
                int remaining = len - i - 1;
                long combinations = 1;
                for (int j = 0; j < remaining; j++)
                {
                    combinations *= 9;
                }
                result += (long)(digit - 1) * combinations;
            }

            if (isValid)
            {
                result++;
            }

            return result;
        }
    }
}
