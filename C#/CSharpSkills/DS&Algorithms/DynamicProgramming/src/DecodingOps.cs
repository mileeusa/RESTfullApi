using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DynamicProgrammingInActions.src
{
    public class DecodingOps
    {
        //
        // a secret message encoded as a string pf numbers. The message is decoded via
        // the following mapping:
        // "1" -> 'A'
        // "2" -> 'B'
        // ...
        // ...
        // "26" -> 'Z'
        //
        // Given a string s containing only digits, return the number of ways to
        // decode it. If entire string cannot be decoded in a valid way,
        // return 0.
        // 
        public static int NumDecodings_DP(string s)
        {
            if (string.IsNullOrEmpty(s) || s[0] == '0')
                return 0;

            int n = s.Length;
            int[] dp = new int[n + 1];

            dp[0] = 1; // empty string
            dp[1] = 1; // already ensured s[0] != '0'

            for (int i = 2; i <= n; i++)
            {
                // One-digit decode (last char)
                if (s[i - 1] != '0')
                {
                    dp[i] += dp[i - 1];
                }

                // Two-digit decode (last two chars)
                int twoDigit = int.Parse(s.Substring(i - 2, 2));

                if (twoDigit >= 10 && twoDigit <= 26)
                {
                    dp[i] += dp[i - 2];
                }
            }

            return dp[n];
        }
    }
}
