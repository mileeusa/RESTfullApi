using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DynamicProgrammingInActions.src
{
    public class DistanceOps
    {
        //
        // Given two strings word1 and word2, return the minimum number of
        // operations required to convert word1 to word2.
        //
        // You have the following three operations permitted on a word:
        //   Insert a character
        //   Delete a character
        //   Replace a character
        //
        // LeetCode 72. Edit Distance
        //
        // This is bottom-to-top implemetation using dynamic programming
        //
        // Time complexity:  O(M * N)
        // Space complexity: O(M * N)
        //
        public static int MinDistance_DP(string w1, string w2)
        {
            int m = w1.Length;
            int n = w2.Length;

            int[,] dp = new int[m + 1, n + 1];

            // base cases
            for (int i = 0; i <= m; i++)
                dp[i, 0] = i;

            for (int j = 0; j <= n; j++)
                dp[0, j] = j;

            // fill the table
            for (int i = 1; i <= m; i++) 
                for (int j = 1; j <= n; j++)
                    if (w1[i-1] == w2[j-1])
                        dp[i, j] = dp[i - 1, j - 1];
                    else
                        dp[i, j] = Math.Min(dp[i, j - 1], Math.Min(dp[i - 1, j], dp[i - 1, j - 1])) + 1;

            return dp[m, n];
        }
    }
}
