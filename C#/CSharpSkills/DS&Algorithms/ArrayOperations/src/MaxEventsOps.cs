using NUnit.Framework.Constraints;
using System.Security.Cryptography;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace ArrayInActions.src
{
    public class MaxEventsOps
    {
        //
        // You are given an array of events where events[i] = [startDayi, endDayi].
        // Every event i starts at startDayi and ends at endDayi.
        //
        // You can attend an event i at any day d where startDayi <= d <= endDayi.
        // You can only attend one event at any time d.
        //
        // Return the maximum number of events you can attend.
        //
        // Main points:
        //   -- Always attend the event that ends soonest → avoids blocking future events
        //   -- Always pick the earliest finishing event available on each day
        //   -- Classic greedy correctness proof(interval scheduling)
        //
        // Time  Complexcity: O(N * LogN)
        // Space Complexcity: O(N)
        //
        // LeetCode: 1353. Maximum Number of Events That Can Be Attended
        //
        // Difficulty: Medium
        //
        public static int MaxEvents_PQImpl(int[][] events)
        {
            // Sort by start day
            Array.Sort(events, (a, b) => a[0].CompareTo(b[0]));

            // Min-heap to store end days
            var pq = new PriorityQueue<int, int>();

            int n = events.Length;
            int day = 0;
            int attended = 0;

            // Process until all events are pushed and miniheap becomes empty
            int i = 0;
            while (i < n || pq.Count > 0)
            {
                // Move "day" forward if heap is empty and next event starts later
                if (pq.Count == 0)
                {
                    day = Math.Max(day, events[i][0]); // start day for current i
                }

                // Add all events starting today
                while (i < n && events[i][0] == day)
                {
                    pq.Enqueue(events[i][1], events[i][1]); // events[i][1] - end day for event i
                    i++;
                }

                // remove expired events
                while (pq.Count > 0 && pq.Peek() < day)
                {
                    pq.Dequeue();
                }

                // attend the events that ends early
                if (pq.Count > 0)
                {
                    pq.Dequeue();
                    attended++;
                    day++;
                }
            }

            return attended;
        }

        //
        // You are given an array of events where events[i] = [startDayi, endDayi, valuei]. The ith event starts
        // at startDayi and ends at endDayi, and if you attend this event, you will receive a value of valuei.
        //
        // You are also given an integer k which represents the maximum number of events you can attend.
        //
        // You can only attend one event at a time.If you choose to attend an event, you must attend the entire
        // event. Note that the end day is inclusive: that is, you cannot attend two events where one of them starts
        // and the other ends on the same day.
        //
        // Return the maximum sum of values that you can receive by attending events.
        //
        //   Input: events = [[1,2,4],[3,4,3],[2, 3, 1], k = 2
        //   Output: 7
        //   Explanation: Choose the green events, 0 and 1 for a total value of 4 + 3 = 7.
        //
        //   Input: events = [[1,2,4],[3,4,3],[2,3,10], k = 2
        //   Output: 10
        //   Explanation: Choose event 2 for a total value of 10.
        //
        // LeetCode: 1751. Maximum Number of Events That Can Be Attended II
        //
        // Time: O(N * K * Log(N))
        //
        // Difficulty: Hard
        //
        public static int MaxEventsWithValue(int[][] events, int k)
        {
            int n = events.Length;
            if (n == 0 || k == 0) return 0;

            // Sort by start time
            Array.Sort(events, (a, b) => a[0] -b[0]); // a[0].CompareTo(b[0])

            // Precompute next available non-overlapping event (first event with start[next] > end[current])
            int[] nextIndex = new int[n];
            for (int i = 0; i < n; i++)
            {
                int end = events[i][1];
                int left = i + 1;
                int right = n - 1;
                int idx = n;

                // calculate next index using binary search
                while (left <= right)
                {
                    int mid = left + (right - left) / 2;
                    if (events[mid][0] > end) // found a valid next event
                    {
                        idx = mid;
                        right = mid - 1;
                    }
                    else
                    {
                        left = mid + 1;
                    }
                }

                nextIndex[i] = idx;
            }

            // DP: dp[i,t] = max value from i..n-1 with t picks left
            int[,] dp = new int[n + 1, k + 1];

            for (int i = n - 1; i >= 0; i--)
            {
                for (int t = 1; t <= k; t++)
                {
                    int value = events[i][2];

                    // Option 1: take this event
                    int next = nextIndex[i];
                    int takeV = value;

                    if (next < n)
                        takeV += dp[next, t - 1];

                    // Option 2: skip
                    int skipV = dp[i + 1, t];

                    dp[i, t] = Math.Max(takeV, skipV);
                }
            }

            return dp[0, k];
        }
    }
}
