using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StringInActions.src
{
    public class LongestCommonPrefixOps
    {
        //
        // Write a function to find the longest common prefix string amongst an array of strings.
        //
        // If there is no common prefix, return an empty string "".
        //
        // LeetCode 14. Longest Common Prefix
        //
        public static string LongestCommonPrefix(string[] strs)
        {
            if (strs == null || strs.Length == 0)
            {
                return "";
            }

            string shortest = strs
                .Where(x => !string.IsNullOrWhiteSpace(x))
                .OrderBy(x => x.Length)
                .First();

            for (int i = 0; i < shortest.Length; i++)
            {
                char c = shortest[i];

                foreach (var s in strs)
                {
                    if (s[i] != c)
                    {
                        return shortest.Substring(0, i);
                    }
                }
            }

            return shortest;
        }

        //
        // Time complexity:  O(S) -- S: sum of all characters in all strings
        // Space complexity: O(1)
        //
        public static string LongestCommonPrefix_VerticalScan(string[] strs)
        {
            if (strs == null || strs.Length == 0)
            {
                return "";
            }

            for (int i = 0; i < strs[0].Length; i++)
            {
                char c = strs[0][i];

                for (int j = 1; j < strs.Length; j++)
                {
                    if (i == strs[j].Length || strs[j][i] != c)
                    {
                        return strs[0].Substring(0, i);
                    }
                }
            }

            return strs[0];
        }
    }
}
