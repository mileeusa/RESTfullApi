
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StringInActions
{
    public class PalindromeOps
    {
        public static bool IsPalindrome(string str)
        {
            if (string.IsNullOrWhiteSpace(str))
            {
                return true;
            }

            int left = 0;
            int right = str.Length - 1;

            while (left < right)
            {
                if (!char.IsLetterOrDigit(str[left]))
                {
                    left++;
                }
                else if (!char.IsLetterOrDigit(str[right]))
                {
                    right--;
                }
                else if (char.ToLower(str[left]) != char.ToLower(str[right]))
                {
                    return false;
                }
                else
                {
                    left++;
                    right--;
                }
            }

            return true;
        }


        //
        // Return the longest palindromic substring
        //
        // Technique:
        //   use the expand around center technique - for each character in the string, expand around it
        //   to find odd-length palindromes
        //   
        // Time: O(n^2)
        // Space: O(1)
        //
        public static string LongestPalindromicSubstring_Expansion(string s)
        {
            if (string.IsNullOrEmpty(s))
            {
                return "";
            }
            int start = 0, maxLen = 0;
            for (int i = 0; i < s.Length; i++)
            {
                ExpandAroundCenter(s, i, i, ref start, ref maxLen);     // Odd length palindromes
                ExpandAroundCenter(s, i, i + 1, ref start, ref maxLen); // Even length palindromes
            }
            return s.Substring(start, maxLen);
        }

        private static void ExpandAroundCenter(string s, int left, int right, ref int start, ref int maxLen)
        {
            while (left >= 0 && right < s.Length && s[left] == s[right])
            {
                left--;
                right++;
            }

            int len = right - left - 1;
            if (len > maxLen)
            {
                start = left + 1;
                maxLen = len;
            }
        }

        //
        // Manacher's Algorithm
        //
        // Mirror logic (one sentence):
        //   If the current index i is inside the right boundary of the known palindrome, its palindrome radius is at least
        //   the minimum of its mirror’s radius and the distance to the right boundary, because palindromes are symmetric around the center.
        //
        //
        // If asked “Why is it O(n)?”:
        //   Each character is expanded at most once beyond the current right boundary.
        //   All expansions together are linear.
        //
        // If asked “When would you not use this?”:
        //   When simplicity > performance.
        //   Expand-around-center is often preferred unless constraints demand O(n).
        //
        // Time:  O(n)
        // Space: O(n)
        //
        public static string LongestPalindromicSubstring_Manacher(string s)
        {
            if (string.IsNullOrEmpty(s))
                return s;

            // 1. Transform string so that odd and even palindromes are handled uniformly, i.e., "abba" -> "^#a#b#b#a#$"
            //    here the sentinels [ˈsentənəl] prevent out-of-bounds checks
            //
            //           ^ # a # b # b # a # $
            //    Index: 0 1 2 3 4 5 6 7 8 9 10
            //    P[i]:  0 0 1 0 1 4 1 0 1 0 0
            //
            char[] t = Transform(s);

            int n = t.Length;    // length of transformed string
            int[] dp = new int[n];// array to store the radius of palindromes centered at each character

            int center = 0;      // center of the current rightmost palindrome
            int right = 0;       // right boundary of the current rightmost palindrome
            int maxLen = 0;      // length of the longest palindrome found
            int centerIndex = 0; // center index of the longest palindrome found

            // 2. Iterate through the transformed string
            for (int i = 1; i < n - 1; i++)
            {
                // If you have a palindrome centered at C, and you're now checking a position i inside
                // that palindrome, then:
                //
                //   mirror = 2 * C - i
                //
                //   This “mirror index” on the left side already tells you a lot about the palindrome
                //   on the right side.
                //
                int mirror = 2 * center - i; // mirror index of i around center

                if (i < right)
                    dp[i] = Math.Min(right - i, dp[mirror]);

                // 3. Expand around center i
                while (t[i + 1 + dp[i]] == t[i - 1 - dp[i]])
                    dp[i]++;

                // 4. Update center and right boundary
                if (i + dp[i] > right)
                {
                    right = i + dp[i];
                    center = i;
                }

                // 5. Track longest palindrome
                if (dp[i] > maxLen)
                {
                    maxLen = dp[i];
                    centerIndex = i;
                }
            }

            // 6. Extract result
            int start = (centerIndex - maxLen) / 2;

            return s.Substring(start, maxLen);
        }

        private static char[] Transform(string s)
        {
            char[] t = new char[s.Length * 2 + 3];
            t[0] = '^';
            t[t.Length - 1] = '$';

            int index = 1;
            foreach (char c in s)
            {
                t[index++] = '#';
                t[index++] = c;
            }

            t[index] = '#';

            return t;
        }
    }
}
