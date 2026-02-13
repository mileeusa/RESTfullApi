using NUnit.Framework;
using NUnit.Framework.Constraints;
using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace ArrayInActions.src
{
    public class IntervalOps
    {
        //
        // You are given an array of non-overlapping intervals intervals where intervals[i] = [starti, endi]
        // represent the start and the end of the ith interval and intervals is sorted in ascending order
        // by starti. You are also given an interval newInterval = [start, end] that represents
        // the start and end of another interval.
        //
        // Insert newInterval into intervals such that intervals is still sorted in ascending order by
        // starti and intervals still does not have any overlapping intervals(merge overlapping intervals if necessary).
        //
        // Return intervals after the insertion.
        //
        // Note that you don't need to modify intervals in-place. You can make a new array and return it.
        //
        // LeetCode 57. Insert Interval
        //
        // Difficulty: Medium
        //
        public static int[][] Insert(int[][] intervals, int[] newInterval)
        {
            var result = new List<int[]>();
            int n = intervals.Length;

            int i = 0;

            while (i < n && intervals[i][1] < newInterval[0]) // new pair is way outside right of the intervals
            {
                result.Add(intervals[i]);
                i++;
            }

            while (i < n && intervals[i][0] <= newInterval[1]) // overlap
            {
                newInterval[0] = Math.Min(newInterval[0], intervals[i][0]);
                newInterval[1] = Math.Max(newInterval[1], intervals[i][1]);
                i++;
            }

            result.Add(newInterval);

            while (i < n) // append the remaining ones
            {
                result.Add(intervals[i]);
                i++;
            }

            return result.ToArray();
        }

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

                int curStart = curr[0];
                int curEnd = curr[1];

                int nextStart = next[0];
                int nextEnd = next[1];

                if (curEnd >= nextStart) // Overlapping intervals
                {
                    // Merge the intervals by updating the end time
                    curr[1] = Math.Max(curEnd, nextEnd);
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
