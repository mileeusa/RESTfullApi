using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StringInActions.src
{
    public class WordBreakOps
    {
        //
        // Given a set of words and a string, return true if the input can be segmented into
        // 1+ words that exist in wordList
        //
        // Time complexity:  O(N^2)
        // Space complexity: O(N)

        public static bool WordBreak(string s, IList<string> words)
        {
            var wordSet = new HashSet<string>(words);
            var dp = new bool[s.Length + 1];

            dp[0] = true; // empty string

            int maxLen = words.Max(w => w.Length);

            for (int i = 1; i <= s.Length; i++)
            {
                for (int j = Math.Max(0, i - maxLen); j < i; j++)
                {
                    if (dp[j] && wordSet.Contains(s.Substring(j, i - j)))
                    {
                        dp[i] = true;
                        break;
                    }
                }
            }

            return dp[s.Length];
        }

        //
        // Given a set of words and a string, return those word(s) in the word list if the input
        // can be segmented into.
        //
        public static List<string>? WordBreakList(string s, IList<string> words)
        {
            var wordSet = new HashSet<string>(words);
            int n = s.Length;

            var dp  = new bool[n + 1];
            var prev = new int[n + 1]; // prev[i] - index j where last word starts

            Array.Fill(prev, -1);
            dp[0] = true;

            for (int i = 1; i <= s.Length; i++)
            {
                for (int j = 0; j < i; j++)
                {
                    if (dp[j] && wordSet.Contains(s.Substring(j, i - j)))
                    {
                        dp[i] = true;
                        prev[i] = j;
                        break;
                    }
                }
            }

            if (!dp[n])
                return null;

            var result = new List<string>();
            int idx = n;

            while (idx > 0)
            {
                int j = prev[idx];
                result.Add(s.Substring(j, idx - j));
                idx = j;
            }

            result.Reverse();

            return result;
        }
    }
}
