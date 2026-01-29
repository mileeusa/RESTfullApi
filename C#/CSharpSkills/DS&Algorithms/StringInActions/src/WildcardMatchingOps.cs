using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace StringInActions.src
{
    public class WildcardMatchingOps
    {
        //
        // Given an input string (s) and a pattern (p), implement wildcard pattern
        // matching with support for '?' and '*' where:
        //   '?' Matches any single character.
        //   '*' Matches any sequence of characters (including the empty sequence).
        //
        // The matching should cover the entire input string (not partial).
        //
        // LeetCode 44. Wildcard Matching
        //
        // Difficulty: Hard
        //
        public static bool IsWildMatched(string s, string p)
        {
            int lastStart = -1;
            int matchIdx = 0;

            int i = 0; // s
            int j = 0; // p

            while (i < s.Length)
            {
                if (j < p.Length && (p[j] == s[i] || p[j] == '?')) // exact match or ?
                {
                    i++;
                    j++;
                }
                else if (j < p.Length && p[j] == '*')  // '*' found
                {
                    lastStart = j;
                    matchIdx = i;
                    j++; // move pass '*'
                }
                else if (lastStart != -1) // mismatch, but we had a '*'
                {
                    j = lastStart + 1;
                    matchIdx++;
                    i = matchIdx;
                }
                else
                {
                    return false;
                }
            }

            while (j < p.Length && p[j] == '*')
            {
                j++;
            }

            return j == p.Length;
        }
    }
}
