using Microsoft.VisualStudio.TestPlatform.Utilities;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArrayInActions.src
{
    public class DuplicateOps
    {
        //
        // Given a stream of integers, find the first non-repeating number at any point.
        //
        // Input
        //   A stream(or array) of integers
        //   Numbers can repeat
        //   Stream size up to 10^6
        // Output
        //   After each insertion, return the first non-repeating number
        //   If none exists, return -1
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
