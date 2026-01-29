using NUnit.Framework.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArrayInActions.src
{
    public class HammingOps
    {
        //
        // For every bit position (0–31), count how many numbers have a 1 at that bit. If ones numbers
        // have a 1, and the rest zeros = n - ones have a 0, then that bit contributes:
        //
        //   ones * zeros
        //
        // Because each 1–0 pair contributes exactly 1 to the Hamming distance.
        //
        // LeetCode 477. Total Hamming Distance
        //
        // Difficulty: Medium
        //
        public static int TotalHammingDistance(int[] nums)
        {
            if (nums == null || nums.Length == 0)
            {
                return 0;
            }

            int total = 0;

            for (int bit = 0; bit < 32; bit++)
            {
                int ones = 0;
                foreach (var num in nums)
                {
                    ones += (num >> bit) & 1;
                }

                int zeros = nums.Length - ones;
                total += ones * zeros;
            }

            return total;
        }

        //
        // The Hamming distance between two integers is the number of positions at which
        // their corresponding binary bits differ. This is useful in error detection,
        // coding theory, and various computational problems.
        //
        // Hamming distance = number of 1s in x ^ y (XOR)
        //
        // Difficulty: Easy
        //
        public static int HammingDistance(int x, int y)
        {
            int dist = 0;
            int n = x ^ y;

            while (n > 0)
            {
                n &= n - 1;
                dist++;
            }

            return dist;
        }
    }
}
