using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StringInActions.src
{
    public class ReplacementOps
    {
        // 
        // LeetCode 424. Longest Repeating Character Replacement
        //
        // Given a string s that consists of only uppercase English letters, you can perform at most k operations on that string.
        // In one operation, you can choose any character of the string and change it to any other uppercase English character.
        // Find the length of the longest sub-string containing all repeating letters you can get after performing the above operations.
        //
        // Example 1:
        // Input: s = "ABAB", k = 2
        // Output: 4
        //
        // Explanation: Replace the two 'A's with two 'B's or vice versa.
        // Example 2:
        // Input: s = "AABABBA", k = 1
        // Output: 4
        //
        // Explanation: Replace the one 'A' in the middle with 'B' and form "AABBBBA".
        // The substring "BBBB" has the longest repeating letters, which is 4.
        //
        // Constraints:
        // 1 <= s.length <= 10^5
        // s consists of only uppercase English letters.
        // 0 <= k <= s.length
        //
        // Sliding Window approach
        // Time: O(N)
        // Space: O(1)
        //
        // Difificulty: Medium
        //
        public static int CharacterReplacement(string s, int k)
        {
            if (string.IsNullOrEmpty(s)) return 0;

            var freq = new int[26];
            int maxLen = 0;
            int left = 0;
            int maxFreq = 0;

            for (int right = 0; right < s.Length; right++)
            {
                int idx = s[right] - 'A';
                freq[idx]++;
                maxFreq = Math.Max(maxFreq, freq[idx]);

                while (right - left + 1 - maxFreq > k)
                {
                    freq[s[left] - 'A']--;
                    left++;
                }

                maxLen = Math.Max(maxLen, right - left + 1);
            }

            return maxLen;
        }

        //
        // Input: s = "abcd", indices = [0, 2], sources = ["a", "cd"], targets = ["eee", "ffff"]
        // Output: "eeebffff"
        //
        // Explanation:
        //   "a" occurs at index 0 in s, so we replace it with "eee".
        //   "cd" occurs at index 2 in s, so we replace it with "ffff".
        //
        // LeetCode 833. Find And Replace in String
        //
        //  
        public static string FindReplaceString(string s, int[] indices, string[] sources, string[] targets)
        {
            var list = new List<(int idx, string src, string dest)>();

            for (int i = 0; i < indices.Length; i++)
            {
                list.Add((indices[i], sources[i], targets[i]));
            }

            list.Sort((a, b) => a.idx.CompareTo(b.idx));

            var sb = new StringBuilder();
            int pos = 0;

            foreach (var (idx, src, dest) in list)
            {
                if (pos < idx)
                {
                    sb.Append(s.Substring(pos, idx - pos));
                    pos = idx;
                }

                if (pos != idx)
                    continue;

                if (pos + src.Length <= s.Length && s.Substring(pos, src.Length) == src)
                {
                    sb.Append(dest);
                    pos += src.Length;
                }
            }

            if (pos < s.Length)
            {
                sb.Append(s.Substring(pos));
            }

            return sb.ToString();
        }
    }
}
