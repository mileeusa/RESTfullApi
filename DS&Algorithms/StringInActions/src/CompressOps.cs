using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace StringInActions.src
{
    //
    // Given an array of characters chars, compress it using the following algorithm:
    //
    // Begin with an empty string s.For each group of consecutive repeating characters in chars:
    //   If the group's length is 1, append the character to s.
    //   Otherwise, append the character followed by the group's length.
    //
    // After you are done modifying the input array, return the new length of the array.
    // You must write an algorithm that uses only constant extra space.
    //
    // Input: chars = ["a","a","b","b","c","c","c"]
    // Output: Return 6, and the first 6 characters of the input array should be: ["a", "2", "b", "2", "c", "3"]
    //
    // Explanation: The groups are "aa", "bb", and "ccc". This compresses to "a2b2c3".
    //
    // LeetCode 75:
    //     443: String Compression
    //
    // Dificulty: Medium
    //
    public class CompressOps
    {
        public static int Compress(char[] chars)
        {
            int write = 0;
            int i = 0;

            while (i < chars.Length)
            {
                var curr = chars[i];
                int count = 0;

                while (i < chars.Length && curr == chars[i])
                {
                    i++;
                    count++;
                }

                chars[write++] = curr;

                if (count > 1)
                {
                    foreach (var c in count.ToString())
                    {
                        chars[write++] = c;
                    }
                }
            }

            return write;
        }
    }
}
