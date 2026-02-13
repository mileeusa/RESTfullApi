using Microsoft.Testing.Platform.OutputDevice;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace StringInActions.src
{
    public class DistanceOps
    {
        //
        // Given two strings word1 and word2, return the minimum number of
        // operations required to convert word1 to word2.
        //
        // You have the following three operations permitted on a word:
        //   Insert a character
        //   Delete a character
        //   Replace a character
        //
        // LeetCode 72. Edit Distance
        //
        // This is the recursive implementation with top-to-bottom memorization
        //
        // Time complexity:  O(M * N)
        // Space complexity: O(M * N)
        //
        public static int MinDistance(string w1, string w2)
        {
            int m = w1.Length;
            int n = w2.Length;

            int[,] memo = new int[m + 1, n + 1];
            for (int i = 0; i <= m; i++)
            {
                for (int j = 0; j <= n; j++)
                {
                    memo[i, j] = -1;
                }
            }

            return MinDistanceRecursive(w1, w2, m, n, memo);
        }

        private static int MinDistanceRecursive(string w1, string w2, int i, int j, int[,] memo)
        {
            if (i == 0) return j;
            if (j == 0) return i;

            if (memo[i, j] != -1)
            {
                return memo[i, j];
            }
            
            if (w1[i - 1] == w2[j - 1])
            {
                memo[i, j] = MinDistanceRecursive(w1, w2, i - 1, j - 1, memo);
            }
            else
            {
                int distInsertion = MinDistanceRecursive(w1, w2, i,     j - 1, memo);
                int distDeletion  = MinDistanceRecursive(w1, w2, i - 1, j,     memo);
                int distReplace   = MinDistanceRecursive(w1, w2, i - 1, j - 1, memo);

                memo[i, j] = Math.Min(distInsertion, Math.Min(distDeletion, distReplace)) + 1;
            }

            return memo[i, j];
        }

        // Given two strings s and t, return true if they are exactly one edit distance apart.
        //
        // An edit is:
        //   Insert one character
        //   Delete one character
        //   Replace one character
        //
        // LeetCode 161. One Edit Distance
        //
        public static bool IsOneEditDistance(string s, string t)
        {
            if (string.IsNullOrEmpty(s) || string.IsNullOrEmpty(t) || s.Length == 0 || t.Length == 0) return false;

            int m = s.Length;
            int n = t.Length;

            if (Math.Abs(m - n) > 1) 
                return false;

            if (s.Length > t.Length)
                return IsOneEditDistance(t, s);

            //
            // m == n | m + 1 == n
            //
            int i = 0;
            while (i < m)
            {
                if (s[i] != t[i])
                {
                    if (m == n)
                        return s.Substring(i+1) == t.Substring(i+1);
                    else
                        return s.Substring(i) == t.Substring(i+1);
                }

                i++;
            }

            return n == m + 1;
        }
    }
}
