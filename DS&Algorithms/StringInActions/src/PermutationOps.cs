using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace StringInActions
{
    public class PermutationOps
    {
        //
        // LeetCode 31. Next Permutation
        //
        // Time complexity:  O(N)
        // Space complexity: O(N)
        //
        // Difficulty: medium
        //
        public static string NextPermutation(string str)
        {
            if (str == null || str.Length <= 1)
                return str;

            var chars = str.ToCharArray();

            int n = str.Length;
            int pivot = n - 1;

            while (pivot > 0 && chars[pivot - 1] >= chars[pivot])
                pivot--;

            if (pivot != 0)
            {
                int i = n - 1;
                while (chars[i] <= chars[pivot - 1])
                    i--;

                (chars[i], chars[pivot - 1]) = (chars[pivot - 1], chars[i]);
            }

            Array.Reverse(chars, pivot, n - pivot);

            return new string(chars);
        }

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
        // Given a string s, return all the palindromic permutations (without duplicates) of it.
        //
        // You may return the answer in any order.If s has no palindromic permutation,
        // return an empty list.
        //
        // LeetCode 267. Palindrome Permutation II
        //
        // Time complexity:  O(N/2 + 1)!)
        // Space complexity: O(N)
        //
        // Difficulty: Medium
        //
        public static IList<string> GeneratePalindromes(string s)
        {
            var freq = new int[128];
            var half = new char[s.Length / 2];

            if (!CanPermutePalindrome(s, freq)) 
                return new List<string>();

            char ch = (char)0;
            int k = 0;
            for (int i = 0; i < freq.Length; i++)
            {
                if (freq[i] % 2 == 1)
                    ch = (char)i;

                for (int j = 0; j < freq[i] / 2; j++)
                    half[k++] = (char)i;
            }

            var set = new HashSet<string>();

            PermutePalindromes(half, 0, ch, set);

            return set.ToList();
        }

        public static bool CanPermutePalindrome(string s, int[] map)
        {
            int count = 0;
            foreach(var c in s)
            {
                map[c]++;

                if (map[c] % 2 == 0)
                    count--;
                else
                    count++;
            }

            return count <= 1;
        }

        public static void swap(char[] s, int i, int j)
        {
            (s[i], s[j]) = (s[j], s[i]);
        }

        // 
        // check if the elements being swapped are equal. If so, the permutations generated even
        // after swapping the two will be duplicates(redundant). Thus, we need not proceed
        // further in such a case.
        //
        public static void PermutePalindromes(char[] s, int len, char ch, HashSet<string> result)
        {
            if (len == s.Length)
            {
                result.Add(new string(s) + (ch == 0 ? "" : ch) + new string(s.Reverse().ToArray()));
            }
            else
            {
                for (int i = len; i < s.Length; i++)
                {
                    if (s[len] != s[i] || i == len)
                    {
                        swap(s, len, i);
                        PermutePalindromes(s, len + 1, ch, result);
                        swap(s, len, i);
                    }
                }
            }
        }
    }
}
