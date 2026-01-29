using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.ExceptionServices;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace BitsInActions.src
{
    public class BitsOps
    {
        //
        // Given a sorted array consisting of only integers where every element appears
        // twice except for one element
        // that appears once. Find this single element that appears only once.
        //
        // LeetCode 75:
        //    540. Single Element in a Sorted Array
        //
        // Time:  O(N)
        // Space: O(1)
        //
        // XOR approach
        //
        // Dificulty: Medium
        //
        public static int SingleNonDuplicate(int[] nums)
        {
            int ans = nums[0];

            for (int i = 1; i < nums.Length; i++)
            {
                ans ^= nums[i];
            }

            return ans;
        }
 
        //
        //  /////////////////////////// Interview takeaway ////////////////////////
        //
        //   Interviewers prefer the O(n) DP solution that reuses previous bit
        //   counts, especially the i >> 1 or i & (i - 1) approach.
        //  
        //  /////////////////////////// Interview takeaway ////////////////////////
        //
        // Given an integer n, return an array ans of length n + 1
        // such that for each i (0 <= i <= n), ans[i] is the
        // number of 1's in the binary representation of i.
        //
        // LeetCode 75:
        //    338. Counting Bits
        //
        // Time:  O(N)
        // Space: O(N)
        //
        public static int[] CountBits(int n)
        {
            var ans = new int[n + 1];
            for(int i = 1; i <= n; i++)
            {
                // for any number i, i & (i-1) removes the lowest set bit
                ans[i] = ans[i & (i - 1)] + 1;
            }

            return ans;
        }

        public static int[] CountBits_DP(int n)
        {
            var dp = new int[n + 1];
            for (int i = 1; i <= n; i++)
            {
                // (i >> 1) --> remove the last bit
                // (i & 1)  --> checks if the last bit is 1
                dp[i] = dp[i >> 1] + (i & 1);
            }

            return dp;
        }

        //
        // LeetCode 898. Bitwise ORs of Subarrays
        //
        // Time:  O(N*W), W=30 number of bits
        // Space: O(W*N)
        //
        public static int SubarrayBitwiseORs(int[] arr)
        {
            var res = new HashSet<int>();
            var curr = new HashSet<int>();

            foreach(var x in arr)
            {
                var next = new HashSet<int> { x };
                foreach(var v in curr)
                    next.Add(v | x);

                curr = next;

                foreach (var v in curr)
                {
                    res.Add(v); 
                }
            }

            return res.Count;
        }

        public static int SubarrayBitwiseANDs(int[] arr)
        {
            var res = new HashSet<int>();
            var curr = new HashSet<int>();

            foreach (var x in arr)
            {
                var next = new HashSet<int> { x };
                foreach (var v in curr)
                    next.Add(v & x);

                curr = next;

                foreach (var v in curr)
                {
                    res.Add(v);
                }
            }

            return res.Count;
        }

        public static int CountOneBits(int n)
        {
            int count = 0;

            while (n > 0)
            {
                n &= n - 1;
                count++;
            }

            return count;
        }

        public static bool IsPowerOfTwo(int num)
        {
            return num > 0 && (num & (num - 1)) == 0;
        }

        public static int GetBit(int number, int position)
        {
            return (number >> position) & 1;
        }

        public static int SetBit(int number, int position)
        {
            return number | (1 << position);
        }

        public static int ClearBit(int number, int position)
        {
            return number & ~(1 << position);
        }

        public static int ToggleBit(int number, int position)
        {
            return number ^ (1 << position);
        }        
    }
}
