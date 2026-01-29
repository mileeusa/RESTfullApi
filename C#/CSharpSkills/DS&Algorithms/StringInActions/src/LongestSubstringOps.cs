using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace StringInActions
{
    public class LongestSubstringOps
    {
        //
        // return the index of the first occurrence of needle in haystack, or -1 if needle is not part of haystack
        //
        // Time:  O((M-N+1) * N). The worst case is O(M*N)
        // Space: O(1)
        //
        public static int StrStr(string haystack, string needle)
        {
            if (string.IsNullOrEmpty(needle)) return 0;
            if (string.IsNullOrEmpty(haystack)) return -1;

            int m = haystack.Length;
            int n = needle.Length;

            for (int i = 0; i <= m - n; i++)
            {
                int j = 0;
                for (; j < n; j++)
                {
                    if (haystack[i + j] != needle[j])
                    {
                        break;
                    }
                }

                if (j == n)
                {
                    return i;
                }
            }

            return -1;
        }

        // KMP Algorithm
        //   KMP uses a prefix table to reuse previous matches, so on mismatch
        //   we jump the pattern pointer instead of restarting,
        //   achieving O(m + n).

        public static int StrStr_KMP(string haystack, string needle)
        {
            if (string.IsNullOrEmpty(needle)) return 0;
            if (string.IsNullOrEmpty(haystack)) return -1;

            int m = haystack.Length;
            int n = needle.Length;

            var lpt = BuildLongestMatchPrefixTable(needle);

            int i = 0; // index for haystack
            int j = 0; // index for needle

            while (i < m)
            {
                if (haystack[i] == needle[j])
                {
                    i++;
                    j++;
                    if (j == n)
                    {
                        return i - n; // found
                    }
                }
                else
                {
                    if (j > 0)
                    {
                        j = lpt[j - 1];
                    }
                    else
                    {
                        i++;
                    }
                }
            }

            return -1; // not found
        }

        private static int[] BuildLongestMatchPrefixTable(string pattern)
        {
            int n = pattern.Length;
            var prefixTable = new int[n];

            int len = 0; // length of the previous longest prefix suffix
            int i = 1;

            while (i < n)
            {
                if (pattern[i] == pattern[len])
                {
                    len++;
                    prefixTable[i] = len;
                    i++;
                }
                else
                {
                    if (len > 0)
                    {
                        len = prefixTable[len - 1];
                    }
                    else
                    {
                        prefixTable[i] = 0;
                        i++;
                    }
                }
            }

            return prefixTable;
        }

        //
        // Return the longest substring without repeating characters
        //
        // Idea:
        //   -- check if the current character has occurred within the current
        //      substring by comparing its index in charIndex with left.        
        //   -- If the character has occurred, we move the left pointer to the
        //      next position after the last occurrence of the character.
        //   -- update the index of the current character in charIndex.
        //
        // Time:  O(N), where N is the length of the string s.
        // Space: O(1), since the charIndex array has a fixed size of 128.
        //
        public static int LengthOfLongestSubstring_1(string s)
        {
            if (string.IsNullOrEmpty(s)) return 0;

            int[] charIndex = new int[128]; // store the indices of characters
            Array.Fill(charIndex, -1);

            int left = 0;
            int maxLen = 0;

            for (int i = 0; i < s.Length; i++)
            {
                char ch = s[i];
                if (charIndex[ch] >= left)
                {
                    left = charIndex[ch] + 1;
                }

                charIndex[ch] = i;
                maxLen = Math.Max(maxLen, i - left + 1);
            }

            return maxLen;
        }

        public static string FindLongestSubstring(string s)
        {
            if (string.IsNullOrEmpty(s)) return s;

            int[] charIndex = new int[128]; // store the indices of characters
            Array.Fill(charIndex, -1);

            int left = 0;
            int maxLen = 0;
            int startIndex = 0;

            for (int i = 0; i < s.Length; i++)
            {
                char ch = s[i];
                if (charIndex[ch] >= left)
                {
                    left = charIndex[ch] + 1;
                }

                charIndex[ch] = i;

                int currentLen = i - left + 1;
                if (currentLen > maxLen)
                {
                    maxLen = currentLen;
                    startIndex = left;
                }
            }

            return s.Substring(startIndex, maxLen);
        }

        // Use HashSet to record the duplicated characters
        public static int LengthOfLongestSubstring_2(string s)
        {
            var hashSet = new HashSet<char>();
            int left = 0;
            int maxLen = 0;

            for (int right = 0; right < s.Length; right++)
            {
                char ch = s[right];

                // if duplicate, shrink the windows from the left until no duplicate
                while (hashSet.Contains(ch))
                {
                    hashSet.Remove(s[left]);
                    left++;
                }

                hashSet.Add(s[right]);
                maxLen = Math.Max(maxLen, right - left + 1);
            }

            return maxLen;
        }

        // <summary>
        // Find the longest substring where every character appears at least k times.
        // 
        // For Example:
        //   bbaaacddcaabdbd, aaa => 3
        //  
        // From ChatGPT:
        // 
        //  The insight is:
        //    - A valid substring has some number of unique characters.
        //    - That number could be 1, 2, 3, … up to 26 (since lowercase English letters).
        //    - If we knew the exact number of unique characters, we could try to find the 
        //      longest substring that has exactly that many unique characters, and each of them 
        //      repeats at least k times.
        //      
        // So the algorithm loops over UniqueCharacters = 1..26, and for each value, uses a sliding window 
        // to find the best substring with exactly targetUnique unique chars.
        // 
        // </summary>
        // <param name="s"></param>
        // <param name="k"></param>
        // <returns></returns>
        // 
        // Time:  O(26 * N) = O(N), where N is the length of the string s.
        // Space: O(1), since the count array has a fixed size of 26.
        // 
        // <<< Complexity analysis >>>
        // You should say this verbatim if asked:
        //   We iterate over at most 26 possible unique character counts.
        //   For each, we run a linear sliding window with two pointers.
        //   So the time complexity is O(26·n) = O(n) and space complexity is O(26) = O(1).
        //
        public static int LongestSubstringWithKRepeat(string s, int k)
        {
            if (k <= 1) return s.Length;

            int maxLen = 0;

            for (int targetUnique = 1; targetUnique <= 26 && targetUnique * k <= s.Length; targetUnique++)
            {
                // count - track chars in the window with the unique characters
                int[] count = new int[26];

                int left = 0;
                int right = 0;
                int unique = 0;        // number of distinct characters (tracked with count[idx] == 0 → 1)
                int countAtLeastK = 0; // number of chars that sppear >= k times (tracked with count[idx] == k)

                while (right < s.Length)
                {
                    if (unique <= targetUnique)
                    {
                        int idx = s[right] - 'a';
                        if (count[idx] == 0)
                        {
                            unique++;
                        }

                        count[idx]++;

                        if (count[idx] == k)
                        {
                            countAtLeastK++;
                        }
                        right++;
                    }
                    else
                    {
                        int idx = s[left] - 'a';
                        if (count[idx] == k)
                        {
                            countAtLeastK--;
                        }
                        count[idx]--;

                        if (count[idx] == 0)
                        {
                            unique--;
                        }
                        left++;
                    }

                    // all ch distinct characters appear at least K times
                    if (unique == targetUnique && unique == countAtLeastK)
                    {
                        maxLen = Math.Max(maxLen, right - left);
                    }
                }
            }

            return maxLen;
        }

        public static int LengthOfLongestSubstringTwoDistinct(string s)
        {
            if (string.IsNullOrEmpty(s) || s.Length == 0) return 0;

            int left = 0; int right = 0;
            int maxLen = 0;

            var map = new Dictionary<char, int>();

            while (right < s.Length)
            {
                map[s[right]] = right;

                if (map.Count == 3)
                {
                    int smallestIndex = map.Values.Min();
                    map.Remove(s[smallestIndex]);
                    left = smallestIndex + 1;
                }

                maxLen = Math.Max(maxLen, right - left + 1);
                right++;
            }

            return maxLen;
        }
    }
}
