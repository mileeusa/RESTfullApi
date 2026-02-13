using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StringInActions
{
    public class ReverseOps
    {
        // Reverse a string in place using two-pointer technique
        //
        // Time complexity:  O(n), where n is the length of the string
        // Space complexity: O(n), due to the char array used for manipulation
        //
        // Note: Strings are immutable in C#, so we use a char array for in-place swapping
        //
        public static string ReverseString(string s)
        {
            if (string.IsNullOrEmpty(s))
            {
                return s;
            }

            // use char array to swap characters in place, instead of string, because string is immutable in C#
            char[] arr = s.ToCharArray();

            int start = 0;
            int end = s.Length - 1;

            while (start < end)
            {
                (arr[start], arr[end]) = (arr[end], arr[start]);
                start++;
                end--;
            }

            return s;
        }

        public static string ReverseString2(string s)
        {
            if (string.IsNullOrEmpty(s))
            {
                return s;
            }
            char[] arr = s.ToCharArray();
            Array.Reverse(arr);
            return new string(arr);
        }
                
        //
        // Given an input string s, reverse the order of the words.
        //
        // A word is defined as a sequence of non-space characters.
        // The words in s will be separated by at least one space.
        //
        // Return a string of the words in reverse order concatenated by a single space.

        // Input: s = "the sky is blue"
        // Output: "blue is sky the"
        //
        // LeetCode 75:
        //    151 - Reverse words in a string
        //
        public static string ReverseWords(string s)
        {
            if (string.IsNullOrWhiteSpace(s))
            {
                return string.Empty;
            }

            string[] tokens = s.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

            var reversedTokens = tokens.Reverse();

            return string.Join(' ', reversedTokens);
        }

        //
        // Given a character array s, reverse the order of the words.
        //
        // A word is defined as a sequence of non-space characters.The words in s will be separated by a single space.
        //
        // Your code must solve the problem in-place, i.e.without allocating extra space.
        //
        // Example 1:
        //   Input: s = ["t", "h", "e", " ", "s", "k", "y", " ", "i", "s", " ", "b", "l", "u", "e"]
        //   Output: ["b", "l", "u", "e", " ", "i", "s", " ", "s", "k", "y", " ", "t", "h", "e"]
        //
        // Example 2:
        //   Input: s = ["a"]
        //   Output: ["a"]
        //
        // LeetCode 186. Reverse Words in a String II
        //
        // Time complexity:  O(N)
        // Space complexity: O(1)
        //
        public static string ReverseWordsII(char[] s)
        {
            // reverse all of them
            int left = 0;
            int right = s.Length - 1;

            while (left < right)
            {
                (s[left], s[right]) = (s[right], s[left]);
                left++;
                right--;
            }

            // reverse individual words
            left = 0;
            right = s.Length - 1;

            while (left < right)
            {
                int n = 0;
                while ((left + n ) < s.Length && s[left + n] != ' ')
                {
                    n++;
                }

                int l = left;
                int r = left + n - 1;
                while (l < r)
                {
                    (s[l], s[r]) = (s[r], s[l]);
                    l++;
                    r--;
                }

                left += n + 1;
            }

            return new string(s);
        }

        private static void Reverse(char[] s, int left, int right)
        {
            // TBD
        }

        private static void ReverseEachWord(char[] s)
        {
            // TBD
        }

        // 
        // LeetCode 3775. Reverse Words With Same Vowel Count
        //
        public static string ReverseWordsWithSameVowelCount(string s)
        {
            // TBD
            return string.Empty;
        }

        //
        // LeetCode 3561. Resulting String After Adjacent Removals
        //
        public static string ResultingString(string s)
        {
            // TBD
            return string.Empty;
        }

        // Given a string s, reverse only all the vowels in the string and return it.
        //
        // The vowels are 'a', 'e', 'i', 'o', and 'u', and they can appear in both
        // lower and upper cases, more than once.
        //
        // LeetCode 75
        //     345 - Reverse Vowels of a String
        //
        // Input: s = "IceCreAm"
        // Output: "AceCreIm"
        //
        // Explanation:
        //
        // The vowels in s are['I', 'e', 'e', 'A']. On reversing the vowels, s becomes "AceCreIm".
        //
        public static string ReverseVowels(string s)
        {
            var vowels = new List<char>();

            foreach (var c in s)
            {
                if (IsVowel(c))
                {
                    vowels.Add(c);
                }
            }

            var arr = new char[s.Length];

            int k = vowels.Count - 1;

            for (int i = 0; i < s.Length; i++)
            {
                if (IsVowel(s[i]))
                {
                    arr[i] = vowels[k];
                    k--;
                }
                else
                {
                    arr[i] = s[i];
                }
            }

            return new string(arr);
        }

        public static bool IsVowel(char c)
        {
            return "aeiouAEIOU".Contains(c);
        }

        //
        // If this were a LeetCode or senior interview, the expected “optimal”
        // solution uses two pointers and O(1) extra Space complexity:
        //
        public static string ReverseVowels_TwoPointers(string s)
        {
            var arr = s.ToCharArray();
            int left = 0;
            int right = arr.Length - 1;

            while (left < right)
            {
                while (left < right && !IsVowel(arr[left])) left++;
                while (left < right && !IsVowel(arr[right])) right--;

                if (left < right)
                {
                    (arr[left], arr[right]) = (arr[right], arr[left]);
                    left++;
                    right--;
                }
            }

            return new string(arr);
        }
    }
}
