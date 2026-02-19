using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArrayInActions.src
{
    public class MergeIntervalsOps
    {
        //
        // Given an array of intervals where intervals[i] = [starti, endi], merge all
        // overlapping intervals, and return an array of the non-overlapping
        // intervals that cover all the intervals in the input.
        //
        // LeetCode: 56 Merge Intervals
        //
        // Time complexity: O(N log N)
        // Space complexity: O(N)
        //
        // Difficulty: Medium
        //
        public static int[][] Merge(int[][] intervals)
        {
            if (intervals == null || intervals.Length == 0)
            {
                return Array.Empty<int[]>();
            }

            // Sort intervals by start time
            //
            // Time complexity: O(N log N)
            //
            Array.Sort(intervals, (a, b) => a[0] - b[0]);

            List<int[]> merged = new();
            int[] curr = intervals[0];

            // walk through all the intervals, and we may need to merge
            // the end of the interval if ever overlapped
            //
            for (int i = 1; i < intervals.Length; i++)
            {
                var next = intervals[i];

                int currentStart = curr[0];
                int currentEnd = curr[1];

                int nextStart = next[0];
                int nextEnd = next[1];

                if (currentEnd >= nextStart) // Overlapping intervals
                {
                    // Merge the intervals by updating the end time
                    curr[1] = Math.Max(currentEnd, nextEnd);
                }
                else // Non-overlapping interval
                {
                    merged.Add(curr);
                    curr = next;
                }
            }

            merged.Add(curr); // Add the last interval

            return merged.ToArray();
        }

        //
        // Given an array of intervals where intervals[i] = [starti, endi], return the
        // minimum number of intervals you need to remove to make the rest of the
        // intervals non-overlapping.
        //
        // Note that intervals which only touch at a point are non-overlapping.
        // For example, [1, 2] and [2, 3] are non-overlapping.
        //
        // LeetCode: 435. Non-overlapping Intervals
        //
        // Time complexity: O(N log N)
        // Space complexity: O(1)
        //
        // Difficulty: Medium
        //
        public static int EraseOverlapIntervals(int[][] intervals)
        {
            if (intervals == null || intervals.Length == 0)
            {
                return 0;
            }

            Array.Sort(intervals, (a, b) => a[1] - b[1]); // sort by end time

            int count = 0;
            int prevEnd = intervals[0][1];

            for (int i = 1; i < intervals.Length; i++)
            {
                if (prevEnd > intervals[i][0]) // Overlapping intervals
                {
                    count++;
                }
                else
                {
                    prevEnd = intervals[i][1];
                }
            }

            return count;
        }
    }
}
