using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
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
        // Time:  O(M * N)
        // Space: O(n);
        //
        // Dificulty: Medium
        //
        public static bool IsInterleave(string s1, string s2, string s3)
        {
            if (s3.Length != (s1.Length + s2.Length)) 
                return false;

            bool[] dp = new bool[s2.Length + 1];

            for (int i = 0; i <= s1.Length; i++)
            {
                for (int j = 0; j <= s2.Length; j++)
                {
                    if (i == 0 && j == 0)
                    {
                        dp[j] = true;
                    }
                    else if (i == 0)
                    {
                        dp[j] = dp[j - 1] && s2[j] == s3[i + j - 1];
                    }
                    else if (j == 0)
                    {
                        dp[j] = dp[j] && s1[i - 1] == s3[i + j - 1];
                    }
                    else
                    {
                        dp[j] = (dp[j] && s1[i - 1] == s3[i + j - 1]) ||
                                (dp[j - 1] && s2[j - 1] == s3[i + j - 1]);
                    }
                }
            }


            return dp[s2.Length];
        }
    }
}
