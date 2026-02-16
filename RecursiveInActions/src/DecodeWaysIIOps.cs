using Microsoft.VisualStudio.TestPlatform.CommunicationUtilities;
using NUnit.Framework.Internal;
using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Globalization;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace RecursiveInActions.src
{
    public class DecodeWaysIIOps
    {
        //
        // A message containing letters from A-Z can be encoded into numbers using the following mapping:
        //
        //   'A' -> "1"
        //   'B' -> "2"
        //   ...
        //   'Z' -> "26"
        //
        // To decode an encoded message, all the digits must be grouped then mapped back into letters
        // using the reverse of the mapping above(there may be multiple ways). For example, "11106"
        // can be mapped into:
        //
        //   "AAJF" with the grouping (1 1 10 6)
        //   "KJF" with the grouping  (11 10 6)
        //
        // Note that the grouping(1 11 06) is invalid because "06" cannot be mapped into 'F' since "6"
        // is different from "06".
        //
        // In addition to the mapping above, an encoded message may contain the '*' character, which
        // can represent any digit from '1' to '9' ('0' is excluded). For example, the encoded
        // message "1*" may represent any of the encoded messages "11", "12", "13", "14", "15",
        // "16", "17", "18", or "19". Decoding "1*" is equivalent to decoding any of the encoded
        // messages it can represent.
        //
        // Given a string s consisting of digits and '*' characters, return the number of ways to decode it.
        //
        // Since the answer may be very large, return it modulo 109 + 7.
        //
        // Example 1:
        //   Input: s = "*"
        //   Output: 9
        //   Explanation: The encoded message can represent any of the encoded messages "1", "2", "3", "4",
        //   "5", "6", "7", "8", or "9". Each of these can be decoded to the strings "A", "B", "C", "D",
        //   "E", "F", "G", "H", and "I" respectively.
        //
        //   Hence, there are a total of 9 ways to decode "*".
        //
        // LeetCode 639. Decode Ways II
        //
        public static int NumDecodingsII(string s)
        {
            var memo = new Dictionary<int, long>();
            return (int)dfs(s, 0, memo);
        }

        private static long dfs(string s, int index, Dictionary<int, long> memo)
        {
            const long MOD = 1_000_000_007;

            int len = s.Length;

            if (memo.TryGetValue(index, out var val))
            {
                return val;
            }

            if (index == len) 
                return 1;

            if (s[index] == '0') 
                return 0;

            long ans = 0;

            // single digit
            if (s[index] == '*')
                ans += 9 * dfs(s, index + 1, memo);
            else
                ans += dfs(s, index + 1, memo);

            // two digits
            if (index < len - 1)
            {
                if (s[index] == '*' && s[index + 1] == '*')
                {
                    ans += 15 * dfs(s, index + 2, memo);
                }
                else if (s[index] == '*')
                {
                    if (s[index] <= 6)
                    {
                        ans += 2 * dfs(s, index + 2, memo);
                    }
                    else
                    {
                        ans += dfs(s, index + 2, memo);
                    }
                }
                else if (s[index + 1] == '*')
                {
                    if (s[index] == '1')
                        ans += 9 * dfs(s, index + 2, memo);
                    else
                        ans += 6* dfs(s, index + 2, memo);
                }
                else
                {
                    int twoDigit = (s[index] - '0') * 10 + (s[index + 1] - '0');
                    if (twoDigit <= 26)
                    {
                        ans += dfs(s, index + 2, memo);
                    }
                }
            }

            ans = ans % MOD;

            memo[index] = ans;

            return ans;
        }
    }
}
