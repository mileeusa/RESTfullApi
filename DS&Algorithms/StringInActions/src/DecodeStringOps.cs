using FluentAssertions;
using NUnit.Framework;
using NUnit.Framework.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace StringInActions.src
{
    public class DecodeStringOps
    {
        //
        // Given an encoded string, return its decoded string.
        //
        // The encoding rule is: k[encoded_string], where the encoded_string
        // inside the square brackets is being repeated exactly k times.
        // Note that k is guaranteed to be a positive integer.
        //
        // You may assume that the input string is always valid; there are
        // no extra white spaces, square brackets are well-formed, etc.
        // Furthermore, you may assume that the original data does not
        // contain any digits and that digits are only for those repeat
        // numbers, k.For example, there will not be input like 3a or 2[4].
        //
        // The test cases are generated so that the length of the output will
        // never exceed 10^5.
        //
        // Example 1:
        //   Input: s = "3[a]2[bc]"
        //   Output: "aaabcbc"
        //
        // Example 2:
        //   Input: s = "3[a2[c]]"
        //   Output: "accaccacc"
        //
        // Example 3:
        //   Input: s = "2[abc]3[cd]ef"
        //   Output: "abcabccdcdcdef"
        //
        // LeetCode 394. Decode String
        //
        // Dificulty: Medium
        //
        public static string DecodeString(string s)
        {
            if (string.IsNullOrEmpty(s)) return s;

            var countStack = new Stack<int>();
            var stringStack = new Stack<StringBuilder>();

            var current = new StringBuilder();
            int k = 0;

            foreach (char c in s)
            {
                if (char.IsDigit(c))
                {
                    k = k * 10 + (c - '0');
                }
                else if (c == '[')
                {
                    countStack.Push(k);
                    stringStack.Push(current);
                    current = new StringBuilder();
                    k = 0;
                }
                else if (c == ']')
                {
                    int repeat = countStack.Pop();
                    var prev = stringStack.Pop();

                    for (int i = 0; i < repeat; i++)
                    {
                        prev.Append(current);
                    }

                    current = prev;
                }
                else
                {
                    current.Append(c);
                }
            }

            return current.ToString();
        }
    }
}
