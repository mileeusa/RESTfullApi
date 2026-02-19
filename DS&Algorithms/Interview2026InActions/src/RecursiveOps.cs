using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interview2026InActions.src
{
    public class RecursiveOps
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
        // Given a string s containing only digits, return the number of ways to decode
        // it. If entire string cannot be decoded in a valid way, return 0.
        //
        // LeetCode 91. Decode Ways
        // 
        public static int NumDecodings(string s)
        {
            if (string.IsNullOrEmpty(s) || s[0] == '0')
                return 0;

            var memo = new int[s.Length + 1];
            Array.Fill(memo, -1);

            return RecursiveWithMemo(s, 0, memo);
        }

        private static int RecursiveWithMemo(string s, int index,int[] memo)
        {
            if (memo[index] != -1)
                return memo[index];

            if (index == s.Length)
                return 1;

            if (s[index] == '0')
                return 0;

            int ans = RecursiveWithMemo(s, index + 1, memo);

            if (index < s.Length - 1)
            {
                int twoDigits = (s[index] - '0') * 10 + (s[index + 1] - '0');
                if (twoDigits <= 26)
                {
                    ans += RecursiveWithMemo(s, index + 2, memo);
                }
            }

            memo[index] = ans;

            return ans;
        }
    }
}
