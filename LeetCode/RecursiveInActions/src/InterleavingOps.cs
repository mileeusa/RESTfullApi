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
        public static bool IsInterleave(string s1, string s2, string s3)
        {
            int m = s1.Length;
            int n = s2.Length;

            if (m + n != s3.Length)
                return false;
            
            int[,] memo = new int[m, n];

            for (int i = 0; i < m; i++)
                for (int j = 0; j < n; j++)
                    memo[i, j] = -1;

            return IsInterleave(s1, 0, s2, 0, s3, 0, memo);
        }

        public static bool IsInterleave(string s1, int idx1, string s2, int idx2, string s3,
                                 int idx3, int[,] memo)
        {
            if (idx1 == s1.Length)
                return s2.Substring(idx2).Equals(s3.Substring(idx3));

            if (idx2 == s2.Length)
                return s1.Substring(idx1).Equals(s3.Substring(idx3));

            if (memo[idx1, idx2] >= 0)
                return memo[idx1, idx2] == 1 ? true : false;

            bool ans = false;
            if (s3[idx3] == s1[idx1] && IsInterleave(s1, idx1 + 1, s2, idx2, s3, idx3 + 1, memo) ||
                s3[idx3] == s2[idx2] && IsInterleave(s1, idx1, s2, idx2 + 1, s3, idx3 + 1, memo))
            {
                ans = true;
            }

            memo[idx1, idx2] = ans ? 1 : 0;
            return ans;
        }
    }
}
