using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DynamicProgrammingInActions.src
{
    public class DecodingWaysIIOps
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
            if (string.IsNullOrEmpty(s) || s.Length == 0) return 0;

            long dp0 = 1; // empty string
            long dp1 = Ways1(s[0]);

            for (int i = 1; i < s.Length; i++)
            {
                long current = (Ways1(s[i]) * dp1 + Ways2(s[i - 1], s[i]) * dp0) % 1000000007;
                dp0 = dp1;
                dp1 = current;
            }

            return (int)dp1;
        }

        private static int Ways1(char c)
        {
            if (c == '*') return 9;

            return (c == '0') ? 0 : 1;
        }

        private static int Ways2(char c1, char c2)
        {
            // case1: both are wildcards
            if (c1 == '*' && c2 == '*') return 15;

            // case2: the first is wildcard
            if (c1 == '*')
            {
                if (c2 >= '0' && c2 <= '6') return 2;
                return 1;
            }

            // case3: the second is wildcard
            if (c2 == '*')
            {
                if (c1 == '1') return 9;
                if (c1 == '2') return 6;
                return 0;
            }

            // case4: both are digits
            int twoDigits = (c1 - '0') * 10 + (c2 - '0');

            if (twoDigits >= 10 && twoDigits <= 26) return 1;
            
            return 0;
        }
    }
}
