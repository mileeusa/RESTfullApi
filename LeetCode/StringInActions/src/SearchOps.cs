using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StringInActions.src
{
    public class SearchOps
    {
        public static int MaxVowels(string s, int k)
        {
            int max = 0;
            int count = 0;
            var isVowels = new bool[128];

            foreach (var c in "aeiouAEIOU")
            {
                isVowels[c] = true;
            }

            for (int i = 0; i < s.Length; i++)
            {
                if (isVowels[s[i]]) count++;

                if (i >= k && isVowels[s[i - k]]) 
                    count--; // remove leftmost char

                if (i >= k - 1) 
                    max = Math.Max(max, count);
            }

            return max;
        }

        //
        // Given an array of strings nums containing n unique binary strings
        // each of length n, return a binary string of length n that does
        // not appear in nums. If there are multiple answers, you may
        // return any of them.
        //
        // Example 1:
        //     Input: nums = ["01", "10"]
        //     Output: "11"
        //     Explanation: "11" does not appear in nums. "00" would also be correct.
        //
        // LeetCode 1980. Find Unique Binary String
        //
        public string FindDifferentBinaryString(string[] nums)
        {
            string ans = "";
            for (int i = 0; i < nums.Length; i++)
            {
                var curr = nums[i][i];
                ans += (curr == '0') ? "1" : "0";
            }

            return ans;
        }

        //
        // LeetCode: 79: Word Search
        //
        public static bool Exist(char[][] board, string word)
        {
            // TBD
            return true;
        }
    }
}
