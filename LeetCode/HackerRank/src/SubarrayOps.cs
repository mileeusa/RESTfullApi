using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HackerRank.src
{
    public class SubarrayOps
    {
        //
        // A cyber security expert has intercepted a transmission containing an array of binary code.
        // The transmission is considered compromised if the bitwise OR of all the elements in
        // any subarray is present in the subarray itself.
        //
        // Complete the function with the following arguments: int[] arr as the input.
        //
        // Return the number of compromised in the array.
        //
        public static long CountCompromisedSubarrays(int[] arr)
        {
            long totalCompromised = 0;
            int n = arr.Length;

            // Stores unique OR values ending at the previous element 
            // and the rightmost starting index that produces that OR value.
            // List< (OR_value, leftmost_index_with_this_OR) >
            var prevORs = new List<(int orVal, int leftIdx)>();

            // Track the last seen position of every number to check "presence" quickly
            var lastSeen = new Dictionary<int, int>();

            for (int i = 0; i < n; i++)
            {
                int x = arr[i];
                lastSeen[x] = i;
                var currentORs = new List<(int orVal, int leftIdx)>();

                // 1. Update existing OR ranges with the current element
                // We use the property: OR(i, j) = OR(i, j-1) | arr[j]
                int lastVal = x;
                currentORs.Add((x, i));

                foreach (var prev in prevORs)
                {
                    int newOr = prev.orVal | x;
                    // Only add if the OR value actually changed to keep the list small (~31 items)
                    if (newOr != currentORs[^1].orVal)
                    {
                        currentORs.Add((newOr, prev.leftIdx));
                    }
                    else
                    {
                        // If OR value is same, update the start index to the leftmost possible
                        currentORs[^1] = (newOr, prev.leftIdx);
                    }
                }

                // 2. Count compromised subarrays ending at index j
                // For each distinct OR value 'v' starting in range [leftIndex_k, leftIndex_{k-1}-1]
                for (int k = 0; k < currentORs.Count; k++)
                {
                    int v = currentORs[k].orVal;
                    int rangeStart = currentORs[k].leftIdx;
                    int rangeEnd = (k == 0) ? i : currentORs[k - 1].leftIdx - 1;

                    // A subarray [i...j] is compromised if OR(i, j) exists in the subarray.
                    // We know OR(i, j) == v for all i in [rangeStart, rangeEnd].
                    // Does 'v' exist in arr[i...j]? 
                    // It does if the LAST time we saw 'v' was at or after index i.
                    if (lastSeen.ContainsKey(v))
                    {
                        int lastPosOfV = lastSeen[v];
                        // 'v' is present in subarray [i...j] if i <= lastPosOfV
                        // So we need to count how many 'i' in [rangeStart, rangeEnd] satisfy i <= lastPosOfV
                        int validCount = Math.Max(0, Math.Min(rangeEnd, lastPosOfV) - rangeStart + 1);
                        totalCompromised += validCount;
                    }
                }

                prevORs = currentORs;
            }

            return totalCompromised;
        }

        //
        // Optimization: If currentOr reaches a state where all bits are 1 
        // and it's already in the set, all further expansions will also 
        // contain this value unless the OR value changes. 
        //
        // (Note: For simplicity and constraints, a nested loop is often acceptable 
        // if n is moderate, but for very large n, we'd use a 'Last Occurrence' map).
        //
        public static long CountCompromisedSubarrays_TLE(int[] arr)
        {
            long count = 0;
            int n = arr.Length;

            for (int i = 0; i < n; i++)
            {
                int currentOr = 0;
                var elementsInSubarray = new HashSet<int>();

                for (int j = i; j < n; j++)
                {
                    currentOr |= arr[j];
                    elementsInSubarray.Add(arr[j]);

                    if (elementsInSubarray.Contains(currentOr))
                    {
                        count++;
                    }
                }
            }
            return count;
        }
    }
}
