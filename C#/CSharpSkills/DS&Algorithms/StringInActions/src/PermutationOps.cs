using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StringInActions
{
    public class PermutationOps
    {
        public static void Permutation(string str, string prefix, List<string> p)
        {
            if (str.Length == 0)
            {
                p.Add(prefix);
            }
            else
            {
                for (int i = 0; i < str.Length; i++)
                {
                    string rem = str.Substring(0, i) + str.Substring(i + 1);
                    Permutation(rem, prefix + str[i], p);
                }
            }
        }

        //
        // Given two strings s1 and s2, return true if s2 contains a permutation of s1, or false otherwise.
        // In other words, return true if one of s1's permutations is the substring of s2.
        // 
        // Example 1:
        //   Input: s1 = "ab", s2 = "eidbaooo"
        //   Output: true
        //   Explanation: s2 contains one permutation of s1("ba").
        //
        // Example 2:
        //   Input: s1 = "ab", s2 = "eidboaoo"
        //   Output: false
        //
        // LeetCode 567. Permutation in String
        //
        // Difficulty: medium
        //
        public static bool CheckInclusion(string s1, string s2)
        {
            if (string.IsNullOrEmpty(s1) || string.IsNullOrEmpty(s2) || s1.Length > s2.Length)
                return false;

            int m = s1.Length;
            int n = s2.Length;

            var freq1 = new int[26];
            foreach (var c in s1)
                freq1[c - 'a']++;

            var freq2 = new int[26];

            for (int i = 0; i < n; i++)
            {
                freq2[s2[i] - 'a']++;
                if (i >= m)
                {
                    freq2[s2[i - m] - 'a']--;
                }

                if (i >= m - 1 && IsMatch(freq1, freq2))
                {
                    return true;
                }
            }

            return false;
        }

        private static bool IsMatch(int[] first, int[] second)
        {
            for (int i = 0; i < first.Length; i++)
            {
                if (first[i] != second[i])
                {
                    return false;
                }
            }

            return true;
        }

        public static bool CheckInclusion_SlidingWindow(string s1, string s2)
        {
            if (string.IsNullOrEmpty(s1) || string.IsNullOrEmpty(s2) || s1.Length > s2.Length)
                return false;

            int[] freq = new int[26];

            foreach (char c in s1)
                freq[c - 'a']++;

            int left = 0;
            int needed = s1.Length;

            for (int right = 0; right < s2.Length; right++)
            {
                int r = s2[right] - 'a';

                if (freq[r] > 0)
                    needed--;

                freq[r]--;

                if (right - left + 1 > s1.Length)
                {
                    int l = s2[left] - 'a';

                    if (freq[l] >= 0)
                        needed++;

                    freq[l]++;
                    left++;
                }

                if (needed == 0)
                    return true;
            }

            return false;
        }
    }
}
