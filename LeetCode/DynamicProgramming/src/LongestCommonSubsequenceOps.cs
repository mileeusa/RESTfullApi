using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace DynamicProgrammingInActions.src
{
    public class LongestCommonSubsequenceOps
    {
        //
        // Given two strings text1 and text2, return the length of their longest common subsequence.
        // If there is no common subsequence, return 0.
        //
        // A subsequence of a string is a new string generated from the original string with some
        // characters(can be none) deleted without changing the relative order of the remaining
        // characters.
        //
        // For example, "ace" is a subsequence of "abcde".
        //
        // A common subsequence of two strings is a subsequence that is common to both strings.
        //
        // LeetCode 1143. Longest Common Subsequence
        //
        // Time complexity: O(M*N)
        // Space complexity: O(M*N)
        //
        public static int LongestCommonSubsequence(string text1, string text2)
        {
            if (string.IsNullOrEmpty(text1) ||
                string.IsNullOrEmpty(text2) ||
                text1.Length == 0 ||
                text2.Length == 0) return 0;

            int m = text1.Length;
            int n = text2.Length;

            int[,] dp = new int[m+1, n+1];

            for (int i = 1; i <= m; i++)
            {
                for (int j = 1; j <= n; j++)
                {
                    if (text1[i-1] == text2[j-1])
                        dp[i, j] = dp[i - 1, j - 1] + 1;
                    else
                        dp[i, j] = Math.Max(dp[i - 1, j], dp[i, j - 1]);

                }
            }

            return dp[m, n];
        }
    }
}
