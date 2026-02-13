using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace DynamicProgrammingInActions.src
{
    public class PalindromeOps
    {
        // 
        // Given a string s, find the longest palindromic subsequence's length in s.
        //
        // A subsequence is a sequence that can be derived from another sequence
        // by deleting some or no elements without changing the order of the
        // remaining elements.
        //
        // LeetCode 516. Longest Palindromic Subsequence
        //
        // Time complexity:  O(N^2)
        // Space complexity: O(N^2)
        //
        public static int LongestPalindromeSubseq(string s)
        {
            var memo = new int[s.Length, s.Length];

            return Lps(s, 0, s.Length - 1, memo);
        }

        private static int Lps(string s, int i, int j, int[,] memo)
        {
            if (memo[i, j] != 0)
                return memo[i, j];

            if (i > j)
                return 0;

            if (i == j) return 1;

            if (s[i] == s[j])
            {
                memo[i, j] = Lps(s, i + 1, j - 1, memo) + 2;
            }
            else
            {
                memo[i, j] = Math.Max(Lps(s, i+1, j, memo), Lps(s, i, j - 1, memo));
            }

            return memo[i, j];
        }

        public static int LongestPalindromeSubseq_IterativeDP(string s)
        {
            int n = s.Length;
            var dp = new int[n, n];

            for (int i = n - 1; i >= 0; i--)
            {
                dp[i, i] = 1;
                for (int j = i + 1; j < n; j++)
                {
                    if (s[i] == s[j])
                        dp[i, j] = dp[i + 1, j - 1] + 2;
                    else
                    {
                        dp[i, j] = Math.Max(dp[i + 1, j], dp[i, j - 1]);
                    }
                }
            }

            return dp[0, n - 1];
        }
    }
}
