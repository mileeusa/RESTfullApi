using System;
using System.Collections.Generic;
using System.Text;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace BacktrackingInActions.src
{
    public class CountValidIpOps
    {
        //
        // A valid IP address consists of exactly four integers separated by single dots.
        // Each integer is between 0 and 255 (inclusive) and cannot have leading zeros.
        //
        // For example, "0.1.2.201" and "192.168.1.1" are valid IP addresses,
        // but "0.011.255.245", "192.168.1.312" and "192.168@1.1" are
        // invalid IP addresses.
        //
        // Given a string s containing only digits, return all possible valid IP addresses
        // that can be formed by inserting dots into s. You are not allowed to reorder or
        // remove any digits in s.You may return the valid IP addresses in any order.
        //
        // LeetCode 93. Restore IP Addresses
        //
        // 
        public static int CountValidIPs(string s)
        {
            return Backtrack(s, 0, 0);
        }

        private static int Backtrack(string s, int index, int segment)
        {
            if (segment == 4)
            {
                return (index == s.Length) ? 1 : 0;
            }

            // prune by remaininglength
            int remainingChars = s.Length - index;
            int remainingSegments = 4 - segment;

            if (remainingChars < remainingSegments || remainingChars > remainingSegments * 3)
                return 0;

            int value = 0;
            int total = 0;

            for (int len = 1; len <= 3 && index + len <= s.Length; len++) // max 3 digits each segment
            {
                if (len > 1 && s[index] == '0') // leading zero is nor permitted, except it's exactly "0"
                    break;

                value = value * 10 + (s[index + len - 1] - '0');

                if (value > 255) break;

                total += Backtrack(s, index + len, segment + 1);
            }

            return total;
        }
    }
}
