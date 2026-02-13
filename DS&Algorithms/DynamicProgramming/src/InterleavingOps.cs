using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Text.Json.Serialization.Metadata;
using System.Threading.Tasks;

namespace StringInActions.src
{
    public class InterleavingOps
    {
        //
        // Given strings s1, s2, and s3, find whether s3 is formed by
        // an interleaving of s1 and s2.
        //
        // An interleaving of two strings s and t is a configuration
        // where s and t are divided into n and m substrings
        // respectively, such that:
        //
        // Input: s1 = "aabcc", s2 = "dbbca", s3 = "aadbbcbcac"
        // Output: true
        // Explanation: One way to obtain s3 is:
        //   -- Split s1 into s1 = "aa" + "bc" + "c", and s2 into s2 = "dbbc" + "a".
        //   -- Interleaving the two splits, we get "aa" + "dbbc" + "bc" + "a" + "c" = "aadbbcbcac".
        //   -- Since s3 can be obtained by interleaving s1 and s2, we return true.
        //
        // LeetCode 97. Interleaving String
        //
        // Time complexity:  O(M * N)
        // Space complexity: O(n);
        //
        // Dificulty: Medium
        //
        public static bool IsInterleave_DP(string s1, string s2, string s3)
        {
            int m = s1.Length;
            int n = s2.Length;

            if (s3.Length != (m + n))
                return false;

            bool[,] dp = new bool[m + 1, n + 1];
            dp[0, 0] = true;

            // first column
            for (int i = 1; i <= m; i++)
                dp[i, 0] = dp[i - 1, 0] && s1[i - 1] == s3[i - 1];

            // first row
            for (int j = 1; j <= n; j++)
                dp[0, j] = dp[0, j - 1] && s2[j - 1] == s3[j - 1];

            for (int i = 1; i <= m; i++)
            {
                for (int j = 1; j <= n; j++)
                {
                    char c = s3[i + j - 1];

                    dp[i, j] =
                        (dp[i - 1, j] && s1[i - 1] == c) ||
                        (dp[i, j - 1] && s2[j - 1] == c);
                }
            }

            return dp[m, n];
        }
    }
}
