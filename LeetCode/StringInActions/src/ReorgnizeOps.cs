using Microsoft.VisualStudio.TestPlatform.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StringInActions.src
{
    public class ReorgnizeOps
    {
        //
        // Given a string s, rearrange the characters of s so that any two
        // adjacent characters are not the same.
        //
        // Return any possible rearrangement of s or return "" if not possible.
        //
        // Example 1:
        //   Input: s = "aab"
        //   Output: "aba"
        //
        // Example 2:
        //   Input: s = "aaab"
        //   Output: ""
        //
        // LeetCode 767. Reorganize String
        //
        public static string ReorganizeString(string s)
        {
            // occurrence frequency
            var freq = new int[26];
            foreach (char c in s)
            {
                freq[c - 'a']++;
            }

            // priority queue
            var pq = new PriorityQueue<char, int>(Comparer<int>.Create((x, y) => y - x));
            for (int i = 0; i < 26; i++)
            {
                if (freq[i] > 0)
                {
                    pq.Enqueue((char)(i + 'a'), freq[i]);
                }
            }

            var sb = new StringBuilder();
            while (pq.Count > 0)
            {
                var first = pq.Dequeue();
                if (sb.Length == 0 || sb[^1] != first) // sb[sb.Length - 1])
                {
                    sb.Append(first);
                    if (--freq[first - 'a'] > 0)
                    {
                        pq.Enqueue(first, freq[first - 'a']);
                    }
                }
                else // same char as previous one
                {
                    if (pq.Count == 0)
                        return "";

                    // try next best
                    var next = pq.Dequeue();
                    sb.Append(next);

                    if (--freq[next - 'a'] > 0)
                    {
                        pq.Enqueue(next, freq[next - 'a']);
                    }

                    pq.Enqueue(first, freq[first - 'a']);
                }
            }

            return (sb.Length == s.Length) ? sb.ToString() : "";
        }
    }
}
