using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecursiveInActions.src
{
    public class DecodeWaysOps
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
        // LeetCode 91. Decode Ways
        //
        public static int NumDecodings(string s)
        {
            var memo = new Dictionary<int, int>();

            return RecursiveWithMemo(s, 0, memo);
        }

        private static int RecursiveWithMemo(string s, int index, Dictionary<int, int> memo)
        {
            if (memo.TryGetValue(index, out var val))
                return val;

            if (index == s.Length) // It means successfully decoded entire string!!!!
                return 1;

            if (s[index] == '0') 
                return 0;

            int ans = RecursiveWithMemo(s, index + 1, memo);

            if (index < s.Length - 1)
            {
                int twoDigit = (s[index] - '0') * 10 + (s[index + 1] - '0');
                if (twoDigit <= 26)
                {
                    ans += RecursiveWithMemo(s, index + 2, memo);
                }
            }

            memo[index] = ans;

            return ans;
        }
    }
}
