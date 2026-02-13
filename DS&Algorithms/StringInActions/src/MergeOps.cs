using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StringInActions.src
{
    public class MergeOps
    {
        //
        // You are given two strings word1 and word2. Merge the strings by adding
        // letters in alternating order, starting with word1. If a string is
        // longer than the other, append the additional letters onto the
        // end of the merged string.
        //
        // LeetCode 75
        //   1768 - Merge Strings Alternately
        //
        public static string MergeAlternately(string word1, string word2)
        {
            if (string.IsNullOrEmpty(word1))  return word2;
            if (string.IsNullOrEmpty(word2))  return word1;

            var list = new List<char>(word1.Length + word2.Length);

            int i = 0, j = 0;

            while (i < word1.Length && j < word2.Length)
            {
                list.Add(word1[i++]);
                list.Add(word2[j++]);
            }

            while (i < word1.Length)
            {
                list.Add(word1[i++]);
            }

            while (j < word2.Length)
            {
                list.Add(word2[j++]);
            }

            return new string (list.ToArray());
        }

        public static string MergeInAlphabeta(string word1, string word2)
        {
            if (string.IsNullOrEmpty(word1))  return word2;
            if (string.IsNullOrEmpty(word2))  return word1;

            var list = new List<char>(word1.Length + word2.Length);

            int i = 0, j = 0;

            while (i < word1.Length && j < word2.Length)
            {
                var ch1 = word1[i];
                var ch2 = word2[j];

                if (ch1 < ch2)
                {
                    list.Add(ch1);
                    i++;

                }
                else
                {
                    list.Add(ch2);
                    j++;
                }
            }

            while (i < word1.Length)
            {
                list.Add(word1[i]);
                i++;
            }

            while (j < word2.Length)
            {
                list.Add(word2[j]);
                j++;
            }

            return new string (list.ToArray());
        }
    }
}
