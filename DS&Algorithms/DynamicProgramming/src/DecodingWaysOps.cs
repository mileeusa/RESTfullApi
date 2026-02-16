namespace DynamicProgrammingInActions.src
{
    public class DecodingWaysOps
    {
        //
        // You have intercepted a secret message encoded as a string of numbers. The message is
        // decoded via the following mapping:
        //
        // "1" -> 'A'
        // "2" -> 'B'
        // ...
        // ...
        // "26" -> 'Z'
        //
        // Given a string s containing only digits, return the number of ways to decode it. If
        // entire string cannot be decoded in a valid way, return 0.
        // 
        // Example 1:
        //   Input: s = "12"
        //   Output: 2
        //   Explanation: "12" could be decoded as "AB" (1 2) or "L" (12).
        //
        // Example 2:
        //   Input: s = "226"
        //   Output: 3
        //   Explanation: "226" could be decoded as "BZ" (2 26), "VF" (22 6), or "BBF" (2 2 6).
        //
        // Example 3:
        //   Input: s = "06"
        //   Output: 0
        //   Explanation: "06" cannot be mapped to "F" because of the leading zero ("6" is different
        //   from "06"). In this case, the string is not a valid encoding, so return 0.
        //
        // LeetCode 91. Decode Ways
        //
        // As we move ahead character by character of the given string, we look back only two steps.
        // For calculating dp[i] we need to know dp[i-1] and dp[i-2] only. Thus, we can easily
        // cut down our O(N) space requirement to O(1) by using only two variables to store
        // the last two results
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
                int lastTwoDigit = int.Parse(s.Substring(i - 2, 2));

                if (lastTwoDigit >= 10 && lastTwoDigit <= 26)
                {
                    dp[i] += dp[i - 2];
                }
            }

            return dp[n];
        }

        public static int NumDecodings_Iterative(string s)
        {
            if (string.IsNullOrEmpty(s) || s[0] == '0')
                return 0;

            int n = s.Length;

            int twoBack = 1; // dp[i-2]
            int oneBack = 1; // dp[i-1]

            for (int i = 1; i < n; i++)
            {
                int current = 0;

                // One-digit decode
                if (s[i] != '0')
                {
                    current = oneBack;
                }

                // Two-digit decode (last two chars)
                int lastTwoDigit = (s[i-1] - '0') * 10 + (s[i]-'0');

                if (lastTwoDigit >= 10 && lastTwoDigit <= 26)
                {
                    current += twoBack;
                }

                twoBack = oneBack;
                oneBack = current;
            }

            return oneBack;
        }
    }
}
