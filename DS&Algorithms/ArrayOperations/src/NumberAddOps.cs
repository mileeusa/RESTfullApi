using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace ArrayInActions.src
{
    public class NumberAddOps
    {
        //
        // Given a list of non-negative integers nums, arrange them such that they form the
        // largest number and return it.
        //
        // Since the result may be very large, so you need to return a string instead of
        // an integer.
        //
        // Example 1:
        //   Input: nums = [10, 2]
        //   Output: "210"
        //
        // Example 2:
        //   Input: nums = [3, 30, 34, 5, 9]
        //   Output: "9534330"
        //
        // LeetCode 179. Largest Number
        //
        // Time complexity:  O(nlogn)
        // Space complexity: O(n+S)
        //
        public string LargestNumber(int[] nums)
        {
            var s = new string[nums.Length];
            for (int i = 0; i < nums.Length; i++)
                s[i] = nums[i].ToString();

            Array.Sort(s, (a, b) => (b + a).CompareTo(a + b));

            var sb = new StringBuilder();
            foreach (var st in s)
            {
                sb.Append(st);
            }

            var result = sb.ToString();

            if (result[0] == '0')
                return "0";

            return result;
        }

        public static List<int> PlusOne(List<int> digits)
        {
            int n = digits.Count;

            // traverse the array from the last digit to the first
            for (int i = n - 1; i >= 0; i--)
            {
                // if the current digit is less than 9, simply increment it and return
                if (digits[i] < 9)
                {
                    digits[i]++;
                    return digits;
                }

                // if the current digit is 9, set it to 0 and continue to the next digit
                digits[i] = 0;
            }

            // if all digits were 9, we need to add a new leading 1
            digits.Insert(0, 1);

            return digits;
        } 
    }
}
