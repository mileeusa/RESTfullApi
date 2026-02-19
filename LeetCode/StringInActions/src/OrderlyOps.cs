using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Runtime.ConstrainedExecution;
using System.Text;
using System.Threading.Tasks;
using static Microsoft.ApplicationInsights.MetricDimensionNames.TelemetryContext;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace StringInActions.src
{
    public class OrderlyOps
    {
        //
        // You are given a string s and an integer k. You can choose one of the first k letters of s and append it at the end of the string.
        //
        // Return the lexicographically smallest string you could have after applying the mentioned step any number of moves.
        //
        // LeetCode 899. Orderly Queue
        //
        public static string OrderlyQueue(string s, int k)
        {
            if (k == 1)
            {
                // only rotations of s are possible, and the answer is the lexicographically smallest rotation.
                string best = s;
                for (int i = 1; i < s.Length; i++)
                {
                    string rotate = s.Substring(i) + s.Substring(0, i);
                    if (string.Compare(rotate, best, StringComparison.Ordinal) < 0)
                    {
                        best = rotate;
                    }
                }

                return best;
            }
            else
            {
                // If k > 1, any permutation of s is possible, and the answer is the letters of s written in lexicographic order.
                char[] arr = s.ToCharArray();
                Array.Sort(arr);
                return new string(arr);
            }
        }

        public static bool CloseStrings(string word1, string word2)
        {
            if (string.IsNullOrEmpty(word1) || string.IsNullOrEmpty(word2) || word1.Length != word2.Length)
                return false;

            var freq1 = new Dictionary<char, int>();
            var freq2 = new Dictionary<char, int>();

            foreach (var c in word1)
                freq1[c] = freq1.GetValueOrDefault(c) + 1;

            foreach (var c in word2)
                freq2[c] = freq2.GetValueOrDefault(c) + 1;

            // Condition 1: same character set
            if (!freq1.Keys.OrderBy(x => x).SequenceEqual(freq2.Keys.OrderBy(x => x)))
                return false;

            // Condition 2: same frequency multiset
            if (!freq1.Values.OrderBy(x => x).SequenceEqual(freq2.Values.OrderBy(x => x)))
                return false;

            return true;
        }

        //
        // Optimized version for lowercase letters only
        //
        // Interview-safe takeaway
        //   -- First check character presence only.
        //   -- Frequency equality is checked after sorting, not per character.
        //
        // After confirming both strings use the same set of characters, just sort the frequency
        // arrays and compare them. If the multisets of counts match, I can relabel characters
        // to make the strings identical.
        //
        public static bool CloseStrings_LowerCases(string word1, string word2)
        {
            if (string.IsNullOrEmpty(word1) || string.IsNullOrEmpty(word2) || word1.Length != word2.Length)
                return false;

            var freq1 = new int[26];
            var freq2 = new int[26];

            foreach (var c in word1)
                freq1[c - 'a']++;

            foreach (var c in word2)
                freq2[c - 'a']++;

            // same char set?
            for (int i = 0; i < 26; i++)
            {
                if ((freq1[i] > 0) != (freq2[i] > 0))
                {
                    return false;
                }
            }

            Array.Sort(freq1);
            Array.Sort(freq2);

            // same frequency set?     
            for (int i = 0; i < 26; i++)
            {
                if (freq1[i] != freq2[i])
                {
                    return false;
                }
            }

            return true;
        }
    }
}
