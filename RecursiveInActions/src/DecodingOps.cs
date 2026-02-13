using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecursiveInActions.src
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
        public static int NumDecodings_Recursive(string s)
        {
            var memo = new Dictionary<int, int>();

            return RecursiveWithMemo(s, 0, memo);
        }

        private static int RecursiveWithMemo(string s, int index, Dictionary<int, int> memo)
        {
            if (memo.ContainsKey(index))
                return memo[index];

            if (index == s.Length) return 1;

            if (s[index] == '0') return 0;

            if (index == s.Length - 1) return 1;

            int ans = RecursiveWithMemo(s, index + 1, memo);

            if (int.Parse(s.Substring(index, 2)) <= 26)
                ans += RecursiveWithMemo(s, index + 2, memo);

            memo[index] = ans;

            return ans;
        }
    }
}
