using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace ArrayInActions.src
{
    public class ArrangeOps
    {
        // 
        // Given an array of integers arr of even length n and an integer k.
        //
        // We want to divide the array into exactly n / 2 pairs such that the sum of
        // each pair is divisible by k.
        //
        // Return true If you can find a way to do that or false otherwise.
        //
        // LeetCode 1497. Check if Array Pairs are Divisible by k
        //
        public static bool CanArrangePairs(int[] arr, int k)
        {
            var freq = new Dictionary<int, int>();

            foreach (var i in arr)
            {
                int rem = (i % k + k) % k;
                freq[rem] = freq.GetValueOrDefault(rem, 0) + 1; ;
            }

            foreach (var rem in freq.Keys)
            {
                // case 1: remainder 0
                if (rem == 0)
                {
                    if (freq[rem] % 2 == 1)
                        return false;
                }

                // Case 2: remainder equals k/2 when k is even
                else if (k % 2 == 0 && rem == k / 2)
                {
                    if (freq[rem] % 2 != 0)
                        return false;
                }
                else
                {
                    if (freq[rem] != freq.GetValueOrDefault(k - rem, 0))
                        return false;
                }
            }

            return true;
        }
    }
}
