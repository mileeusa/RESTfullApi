using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HashSetInAction.src
{
    public class UniqueOps
    {
        //
        // Given an array of integers arr, return true if the number of occurrences of
        // each value in the array is unique or false otherwise.
        //
        // LeetCode 75:
        // 1207. Unique Number of Occurrences
        //
        public static bool UniqueOccurrences(int[] arr)
        {
            var freq = new Dictionary<int, int>();

            foreach (var n in arr)
            {
                freq[n] = freq.GetValueOrDefault(n) + 1;
            }

            var seen = new HashSet<int>();

            foreach (var count in freq.Values)
            {
                if (!seen.Add(count))
                {
                    return false;
                }
            }

            return true;
        }
    }
}
