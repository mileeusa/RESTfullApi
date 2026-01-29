using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace StringInActions.src
{
    public class AnagramOps
    {
        public static bool AreAnagrams(string s1, string s2)
        {
            if (s1.Length != s2.Length)
            {
                return false;
            }

            // we need the custom comparer for CHAR here
            var charCount = new Dictionary<char, int>(new CaseInsensitiveCharComparer());

            foreach (char c in s1)
            {
                if (charCount.ContainsKey(c))
                {
                    charCount[c]++;
                }
                else
                {
                    charCount[c] = 1;
                }
            }

            foreach (char c in s2)
            {
                if (!charCount.ContainsKey(c))
                {
                    return false;
                }
                charCount[c]--;
                if (charCount[c] < 0)
                {
                    return false;
                }
            }

            return charCount.All(x => x.Value == 0);
        }

        public static bool AreAnagrams2(string s1, string s2)
        {
            if (string.IsNullOrEmpty(s1) || string.IsNullOrEmpty(s2) || s1.Length != s2.Length)
            {
                return false;
            }

            int[] count = new int[26];

            foreach (char c in s1.ToLower()) 
                count[c - 'a']++;

            foreach (char c in s2.ToLower()) 
                count[c - 'a']--;

            return count.All(x => x == 0);
        }

        //
        // LeetCode 438. Find All Anagrams in a String
        //
        public IList<int> FindAnagrams(string s, string p)
        {
            var result = new List<int>();

            // TBD
            if (s.Length < p.Length) return result;

            int[] freq = new int[26];

            // build frequency map for p
            foreach (char c in p)
                freq[c - 'a']++;

            int left = 0, right = 0;
            int count = p.Length;

            while (right < s.Length)
            {
                // include right char
                if (freq[s[right] - 'a']-- > 0)
                    count--;

                right++;

                // when window size equals p length
                if (count == 0)
                    result.Add(left);

                // shrink window
                if (right - left == p.Length)
                {
                    if (freq[s[left] - 'a']++ >= 0)
                        count++;
                    left++;
                }
            }

            return result;
        }
    }
}
