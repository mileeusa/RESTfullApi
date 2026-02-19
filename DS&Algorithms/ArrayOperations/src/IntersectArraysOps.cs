using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArrayInActions.src
{
    public class IntersectArraysOps
    {
        public static int[] IntersectTwoSortedArrays(int[] a, int[] b)
        {
            var ans = new List<int>();

            int m = a.Length;
            int n = b.Length;

            int i = 0;
            int j = 0;

            while (i < m && j < n)
            {
                if (a[i] == b[j])
                {
                    if (ans.Count == 0 || ans[^1] != a[i])
                    {
                        ans.Add(a[i]);
                    }

                    i++;
                    j++;
                }
                else if (a[i] < b[j])
                    i++;
                else
                    j++;
            }

            return ans.ToArray();
        }

        //
        // Given two integer arrays nums1 and nums2, return an array of their intersection. Each element in the result
        // must be unique and you may return the result in any order.
        //
        // LeetCode 349. Intersection of Two Arrays
        //
        // Difficulty: Easy
        //
        public static int[] IntersectTwoUnsortedArrays(int[] nums1, int[] nums2)
        {
            var ans = new List<int>();

            var seen = new Dictionary<int, int>();
            foreach (int num in nums1)
            {
                seen[num] = seen.GetValueOrDefault(num, 0) + 1;
            }

            foreach (int num in nums2)
            {
                if (seen.ContainsKey(num) && !ans.Contains(num))
                {
                    ans.Add(num);
                    seen.Remove(num);
                }
            }

            return ans.ToArray();
        }
    }
}
