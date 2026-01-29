using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Xml;
using static Microsoft.ApplicationInsights.MetricDimensionNames.TelemetryContext;

namespace StringInActions.src
{
    public class RemoveOps
    {
        // You are given a string s, which contains stars *.
        //
        // In one operation, you can:
        //   -- Choose a star in s.
        //   -- Remove the closest non-star character to its left, as well as remove the star itself.
        //
        // Return the string after all stars have been removed.

        // Note:
        //   The input will be generated such that the operation is always possible.
        //   It can be shown that the resulting string will always be unique.
        //
        // LeetCode 75:
        //     #2390 - Removing Stars From a String
        //
        public static string RemoveStars(string s)
        {
            var arr = new char[s.Length];
            int top = 0;

            foreach (var c in s)
            {
                if (c != '*')
                {
                    arr[top++] = c;
                }
                else if (top > 0)
                {
                    top--;
                }
            }

            return new string(arr, 0, top);
        }

        public static string RemoveStars_Stack(string s)
        {
            var stack = new Stack<char>();

            foreach (var c in s)
            {
                if (c != '*')
                {
                    stack.Push(c);
                }
                else if (stack.Count > 0)
                {
                    stack.Pop();
                }
            }

            if (stack.Count == 0)
            {
                return "";
            }

            var arr = new char[stack.Count];
            int i = stack.Count - 1;
            while (stack.Count > 0)
            {
                arr[i--] = stack.Pop();
            }

            return new string(arr);
        }

        public static string RemoveChars(string s, char target)
        {
            if (string.IsNullOrEmpty(s))
            {
                return s;
            }
            StringBuilder sb = new StringBuilder();
            foreach (char c in s)
            {
                if (c != target)
                {
                    sb.Append(c);
                }
            }
            return sb.ToString();
        }

        //
        // Given string num representing a non-negative integer num, and an integer k,
        // return the smallest possible integer after removing k digits from num.
        //
        // Example 1:
        //   Input: num = "1432219", k = 3
        //   Output: "1219"
        //   Explanation: Remove the three digits 4, 3, and 2 to form the new number 1219 which is the smallest.
        //
        // LeetCode 402. Remove K Digits
        //
        // in-place implementation
        //
        public static string removeKdigits(string num, int k)
        {
            int n = num.Length;
            if (k >= n) return "0";

            char[] arr = num.ToCharArray();
            int top = -1;

            for (int i = 0; i < n; i++)
            {
                char c = arr[i];

                while (top >= 0 && k > 0 && arr[top] > c)
                {
                    top--;
                    k--;
                }

                arr[++top] = c;
            }

            top -= k;

            // skip leading zero
            int start = 0;
            while (start < top && arr[start] == '0')
                start++;

            if (start > top) return "0";

            return new string(arr, start, top - start + 1);
        }

        public static string RemoveDuplicates(string s)
        {
            HashSet<char> seen = new HashSet<char>(s);

            StringBuilder sb = new StringBuilder();

            foreach (char c in seen)
            {
                sb.Append(c);
            }

            return sb.ToString();
        }

        //
        // Given two string s1 and s2. Delete from s2 all those characters that occur in s1
        // also and finally create a clean s2 with the relevant characters deleted
        //
        public static string RemoveChars(string s2, string s1)
        {
            if (string.IsNullOrEmpty(s2) || string.IsNullOrEmpty(s1))
            {
                return s2;
            }

            var set = new HashSet<char>(s1);

            var src = s2.ToArray<char>();

            int j = 0;
            for (int i = 0; i < s2.Length; i++)
            {
                char c = src[i];

                if (!set.Contains(c))
                {
                    src[j++] = c;
                }
            }

            return new string(src.Take(j).ToArray());
        }

        // case insentitive
        public static string RemoveChars_SB(string s2, string s1)
        {
            if (string.IsNullOrEmpty(s2) || string.IsNullOrEmpty(s1))
            {
                return s2;
            }
            var set = new HashSet<char>(s1.ToLowerInvariant()); // charsToDelete.Select(c => char.ToLowerInvariant(c)));
            var result = new StringBuilder(s2.Length);

            foreach (var c in s2)
            {
                if (!set.Contains(char.ToLowerInvariant(c)))
                {
                    result.Append(c);
                }
            }

            return result.ToString();
        }

        // case insentitive
        public static string RemoveChars_LINQ(string s2, string s1)
        {
            var set = new HashSet<char>(s1.ToLowerInvariant());

            return new string(s2.Where(c => !set.Contains(char.ToLowerInvariant(c))).Select(x => x).ToArray());
        }
    }
}
