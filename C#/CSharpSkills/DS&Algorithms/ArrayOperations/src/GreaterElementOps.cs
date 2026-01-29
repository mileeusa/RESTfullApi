using Newtonsoft.Json.Linq;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using static System.Net.Mime.MediaTypeNames;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace ArrayInActions.src
{
    public class GreaterElementOps
    {
        //
        // The next greater element of some element x in an array is the first greater element
        // that is to the right of x in the same array.
        //
        // You are given two distinct 0-indexed integer arrays nums1 and nums2, where nums1
        // is a subset of nums2.
        //
        // For each 0 <= i < nums1.length, find the index j such that nums1[i] == nums2[j]
        // and determine the next greater element of nums2[j] in nums2.If there is no
        // next greater element, then the answer for this query is -1.
        //
        // Return an array ans of length nums1.length such that ans[i] is the next
        // greater element as described above.
        //
        // LeetCode 496: Next Greater Element I
        //
        // Time:  O(N)
        // Space: O(N)
        //
        // Difficulty: Easy
        //
        public static int[] NextGreaterElement(int[] nums1, int[] nums2)
        {
            if (nums1 == null || nums1.Length == 0 || nums2 == null || nums2.Length == 0) return [];

            var dict = new Dictionary<int, int>(); // key: current, value: next Greater Element
            var ss = new Stack<int>();

            foreach (var n in nums2)
            {
                while (ss.Count > 0 && n > ss.Peek())
                {
                    dict[ss.Pop()] = n;
                }
                ss.Push(n);
            }

            while (ss.Count > 0)
            {
                dict[ss.Pop()] = -1;
            }

            var ans = new int[nums1.Length];
            for (int i = 0; i < nums1.Length; i++)
            {
                ans[i] = dict[nums1[i]];
            }

            return ans;
        }

        //
        // LeetCode 503: Next Greater Element II
        //
        // 🔍Problem Twist vs 496:
        //     -- The array is circular
        //     -- After the last element, you can continue searching from the start
        //     -- For each index i, find the first greater element when moving forward circularly
        //
        // 💡Key Insight
        //  Use the same monotonic decreasing stack, but simulate circular traversal by:
        //     -- Traversing the array twice(0 → 2n - 1)
        //     -- Use modulo: nums[i % n]
        //     -- Only push indices during the first pass
        //
        // Time:  O(N)
        // Space: O(N)
        //
        // Difficulty: Medium
        //
        public static int[] NextGreaterElements(int[] nums)
        {
            var n = nums.Length;
            var ans = new int[n];
            Array.Fill(ans, -1);

            var ss = new Stack<int>(); // store indices

            for (int i = 0; i < 2 * n; i++)
            {
                int num = nums[i % n];
                while (ss.Count > 0 && num > nums[ss.Peek()])
                {
                    ans[ss.Pop()] = num;
                }

                if (i < n)
                {
                    ss.Push(i);
                }
            }

            return ans;
        }
    }
}
