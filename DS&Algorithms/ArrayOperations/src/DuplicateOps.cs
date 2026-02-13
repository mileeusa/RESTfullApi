using Microsoft.VisualStudio.TestPlatform.Utilities;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Reflection.Metadata;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using static Microsoft.ApplicationInsights.MetricDimensionNames.TelemetryContext;

namespace ArrayInActions.src
{
    public class DuplicateOps
    {
        //
        // Given an array of size N in which every number is between 1 and N, determine
        // if there are any duplicates in it
        //
        public static bool HasDuplicates(int[] nums)
        {
            for (int i = 0; i < nums.Length; i++)
            {
                int index = Math.Abs(nums[i]) - 1;

                if (nums[index] < 0)
                    return true;

                nums[index] = -nums[index];
            }

            return false;
        }

        //
        // Given an integer array nums of length n where all the integers of nums are
        // in the range [1, n] and each integer appears at most twice, return
        // an array of all the integers that appears twice.
        //
        // You must write an algorithm that runs in O(n) time and uses only constant
        // auxiliary space, excluding the space needed to store the output
        //
        // LeetCode 442. Find All Duplicates in an Array
        //
        public static IList<int> FindDuplicates(int[] nums)
        {
            var result = new List<int>();

            for (int i = 0; i < nums.Length; i++)
            {
                int index = Math.Abs(nums[i]) - 1;

                if (nums[index] < 0)
                {
                    result.Add(index + 1);
                }

                nums[index] = -nums[index];
            }

            return result;
        }

        //
        // gGiven an array nums[100] which contains numbers between 1 and 99. return the duplicate value
        //
        public static int FindDuplicate(int[] nums)
        {
            int xor = 0;
            for (int i = 0; i < nums.Length; i++)
                xor ^= nums[i];

            for (int i = 1; i < nums.Length; i++)
                xor ^= i;

            return xor;
        }

        public static int FindDuplicate_II(int[] nums)
        {
            foreach(var n in nums)
            {
                int idx = Math.Abs(n) - 1;

                if (nums[idx] < 0)
                    return idx + 1;

                nums[idx] = -nums[idx];
            }

            return -1;
        }


        //
        // Given a stream of integers, find the first non-repeating number at any point.
        //
        // Input
        //   A stream(or array) of integers
        //   Numbers can repeat
        //   Stream size up to 10^6
        //
        // Output
        //   After each insertion, return the first non-repeating number
        //   If none exists, return -1
        //
        //   <<<<<<<<<<<<<<<<<< How to say this in the interview >>>>>>>>>>>>>>>>>>>>
        //   “Since the input is a stream, I need O(1) updates and to preserve order.
        //   I’ll use a hash map for frequency and a queue to track insertion order.
        //   This gives me O(N) time and space.”
        //   >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>
        //
        public static List<int> FirstNonRepeating(int[] nums)
        {
            var freq = new Dictionary<int, int>();
            var queue = new Queue<int>();
            var result = new List<int>();

            foreach (int num in nums)
            {
                if (!freq.ContainsKey(num))
                {
                    freq[num] = 0;
                    queue.Enqueue(num);
                }

                freq[num]++;

                while (queue.Count > 0 && freq[queue.Peek()] > 1)
                {
                    queue.Dequeue();
                }

                result.Add(queue.Count > 0 ? queue.Peek() : -1);
            }

            return result;
        }
    }
}
