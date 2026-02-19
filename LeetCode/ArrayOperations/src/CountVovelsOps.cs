using FluentAssertions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace ArrayInActions.src
{
    public class CountVovelsOps
    {
        public static int CountVowelsSubstring(string s)
        {
            var set = new HashSet<char>() {};
            int count = 0;

            for (int i = 0; i < s.Length; i++)
            {
                set.Clear();
                if (IsVowel(s[i]))
                {
                    set.Add(s[i]);

                    int j = i + 1;
                    while (j < s.Length && IsVowel(s[j]))
                    {
                        set.Add(s[j]);

                        if (set.Count == 5)
                            count++;
                        j++;
                    }
                }
            }

            return count;
        }

        // Given a 0-indexed string s, permute s to get a new string t such that:
        //
        //   - All consonants remain in their original places.More formally, if there is an
        //     index i with 0 <= i < s.length such that s[i] is a consonant, then t[i] = s[i].
        //
        //   - The vowels must be sorted in the nondecreasing order of their ASCII values.
        //     More formally, for pairs of indices i, j with 0 <= i<j<s.length such that
        //     s[i] and s[j] are vowels, then t[i] must not have a higher ASCII value than t[j].
        //
        // Return the resulting string.
        //
        // The vowels are 'a', 'e', 'i', 'o', and 'u', and they can appear in lowercase or
        // uppercase.Consonants comprise all letters that are not vowels.
        //
        // LeetCode 2785. Sort Vowels in a String
        //
        // Hit: using counting sort for the vowels
        public static string SortVowels(string s)
        {
            var freq = new Dictionary<char, int>();
            foreach (char ch in s) { 
                if (IsVowel(ch))
                    freq[ch] = freq.GetValueOrDefault(ch, 0) + 1;
            }

            var sortedVowels = "AEIOUaeiou";
            var sb = new StringBuilder();
            int j = 0;

            for (int i =0; i < s.Length; i++)
            {
                char ch = s[i];
                if (IsVowel(ch))
                {
                    while (!freq.ContainsKey(sortedVowels[j]) || freq[sortedVowels[j]] == 0)
                        j++;

                    sb.Append(sortedVowels[j]);
                    freq[sortedVowels[j]]--;
                }
                else
                    sb.Append(ch);
            }

            return sb.ToString();
        }

        private static bool IsVowel(char ch)
        {
            return "AEIOUaeiou".Contains(ch);
        }
    }
}
