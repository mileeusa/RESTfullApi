using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace ArrayInActions.src
{
    public class ConsecutiveOps
    {
        //
        // Given an unsorted array of integers nums, return the length of
        // the longest consecutive elements sequence.
        //
        // You must write an algorithm that runs in O(n) time.
        //
        // LeetCode: 128. Longest Consecutive Sequence
        //
        // Time:  O(N)
        // Space: O(N)
        //
        // Difficulty: Medium
        //
        public static int LongestConsecutive(int[] numbers)
        {
            if (numbers == null || numbers.Length == 0)
                return 0;

            var map = new Dictionary<int, bool>();

            foreach (int num in numbers)
                map[num] = false; // mark all numbers as unvisited

            int longest = 0;

            foreach (int num in numbers)
            {
                if (!map[num]) // if the number is unvisited
                {
                    int length = 1;

                    map[num] = true; // mark it as visited

                    // check for consecutive numbers on the left and right
                    for (int j = num - 1; map.ContainsKey(j); j--)
                    {
                        map[j] = true; // mark as visited
                        length++;

                    }
                    for (int j = num + 1; map.ContainsKey(j); j++)
                    {
                        map[j] = true; // mark as visited
                        length++;
                    }

                    longest = Math.Max(longest, length);
                }
            }

            return longest;
        }
    }
}
