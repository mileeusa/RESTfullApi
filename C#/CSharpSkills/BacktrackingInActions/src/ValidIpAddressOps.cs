using Microsoft.VisualBasic;
using NUnit.Framework.Constraints;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Text.RegularExpressions;

namespace BacktrackingInActions.src
{
    public class ValidIpAddressOps
    {
        //
        // LeetCode 93. Restore IP Addresses
        //
        // Nature of the Problem:
        //   Restore IP Addresses = constrained enumeration
        //   Exactly 4 segments
        //   Each segment length 1–3
        //   Each segment value 0–255
        //   Leading zero rules
        //   Need to return all valid strings
        //
        // This matches DFS + backtracking perfectly:
        //   Build one segment at a time
        //   Validate locally
        //   Backtrack immediately when invalid
        //
        public static IList<string> RestoreIpAddresses(string s)
        {
            var result = new List<string>();
            Backtrack(s, 0, 0, new List<string>(), result);
            return result;
        }

        private static void Backtrack(string s, int index, int segment, List<string> path, List<string> result)
        {
            if (segment == 4)
            {
                if(index == s.Length)
                {
                    result.Add(string.Join(".", path));
                }

                return;
            }

            int remainingChars = s.Length - index;
            int remainingSegments = 4 - segment;

            if (remainingChars < remainingSegments || remainingChars > remainingSegments * 3)
            {
                return;
            }

            int value = 0;

            for (int len = 1; len <= 3 && index + len <= s.Length; len++)
            {
                // leading zero check
                if (len > 1 && s[index] == '0')
                    break;

                value = value * 10 + s[index + len - 1] - '0';

                if (value > 255) break;

                path.Add(s.Substring(index, len));
                Backtrack(s, index + len, segment + 1, path, result);
                path.RemoveAt(path.Count - 1);
            }
        }       
    }
}
