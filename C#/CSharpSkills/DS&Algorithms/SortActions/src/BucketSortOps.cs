using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SortActions.src
{
    //
    // Bucket sort is ideal when all data fits in memory and we want the optimal O(n) solution
    // for certain problems like "top k frequent elements
    //
    public class BucketSortOps
    {
        //
        // Given an integer array nums and an integer k, return the k most
        // frequent elements. You may return the answer in any order.
        //
        // Constraints:
        //
        //   1 <= nums.length <= 10^5
        //   -10^4 <= nums[i] <= 10^4        //
        //   k is in the range[1, the number of unique elements in the array].
        //
        //   It is guaranteed that the answer is unique.
        //
        // LeetCode 347: Top K Frequent Elements
        //
        // Time:  O(N)
        // Space: O(N)
        //
        public static int[] TopKFrequent(int[] nums, int k)
        {
            // 1. build the frequency map
            var freq = new Dictionary<int, int>();
            foreach(var n in nums)
                freq[n] = freq.GetValueOrDefault(n) + 1;

            // 2. create the buckets
            // The maximum frequency of any element is n, so we create an array of size n + 1
            // where index i stores all numbers that occur i times.
            //
            var buckets = new List<int>[nums.Length + 1]; 
            foreach (var (key, value) in freq)
            {
                int number = key;
                int frequency = value;

                //buckets[frequency] ??= new List<int>();
                if (buckets[frequency] == null)
                {
                    buckets[frequency] = []; // new List<int>();
                }

                buckets[frequency].Add(number);
            }

            // 3. collect the top k frequent elements
            var result = new List<int>();
            for (int i = buckets.Length - 1; i >= 0; i--)
            {
                if (buckets[i] != null)
                {
                    result.AddRange(buckets[i]);
                }
            }

            return result.Take(k).ToArray();
        }
    }
}
