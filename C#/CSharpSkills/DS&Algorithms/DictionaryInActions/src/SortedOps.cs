using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DictionaryInActions.src
{
    public class SortedOps
    {
        //
        // In an alien language, surprisingly, they also use English lowercase letters, but
        // possibly in a different order.The order of the alphabet is some permutation of lowercase letters.
        //
        // Given a sequence of words written in the alien language, and the order of the alphabet,
        // return true if and only if the given words are sorted lexicographically in this alien language.
        //
        // LeetCode: 953. Verifying an Alien Dictionary
        //
        // Difficulty: Easy
        //
        public bool IsAlienSorted(string[] words, string order)
        {
            Dictionary<char, int> orderMap = [];
            // set up the mapping from character to its index in the alien order
            int k = 0;
            foreach (char c in order)
            {
                orderMap[c] = k++;
            }

            for (int i = 0; i < words.Length - 1; i++)
            {
                if (!IsSorted(words[i], words[i + 1], orderMap)) 
                    return false;
            }
            return true;
        }

        private static bool IsSorted(string a, string b, Dictionary<char, int> orderMap)
        {
            int minLength = Math.Min(a.Length, b.Length);

            int i = 0;
            while (i < minLength && a[i] == b[i])
                i++;

            if (i == a.Length)
                return true;

            if (i == b.Length)
                return false;

            return orderMap[a[i]] < orderMap[b[i]];
        }

        public static void Test_IsAlienSorted()
        {
            SortedOps ops = new();
            //string[] words = new string[] { "word","world","row" };
            //string order = "worldabcefghijkmnpqstuvxyz";
            string[] words = new string[] { "hello", "leetcode" };
            string order = "hlabcdefgijkmnopqrstuvwxyz";
            bool result = ops.IsAlienSorted(words, order);
            Console.WriteLine();
            Console.WriteLine("SortedOps.Test_IsAlienSorted:");
            Console.WriteLine($"Words: [{string.Join(", ", words)}], Order: {order} => IsAlienSorted: {result}");
        }
    }
}
