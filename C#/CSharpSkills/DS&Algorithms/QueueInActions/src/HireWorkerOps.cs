using FluentAssertions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using static Microsoft.ApplicationInsights.MetricDimensionNames.TelemetryContext;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace QueueInActions.src
{
    public class HireWorkerOps
    {
        //
        // You are given a 0-indexed integer array costs where costs[i] is the
        // cost of hiring the ith worker.
        //
        // You are also given two integers k and candidates.We want to hire
        // exactly k workers according to the following rules:
        //   -- You will run k sessions and hire exactly one worker in each session.
        //   -- In each hiring session, choose the worker with the lowest cost
        //      from either the first candidates workers or the last candidates
        //      workers. Break the tie by the smallest index.
        //        -- For example, if costs = [3, 2, 7, 7, 1, 2] and candidates = 2,
        //           then in the first hiring session, we will choose the 4th
        //           worker because they have the lowest cost [3, 2, 7, 7, 1, 2].
        //        -- In the second hiring session, we will choose 1st worker
        //           because they have the same lowest cost as 4th worker but
        //           they have the smallest index [3, 2, 7, 7, 2]. Please note
        //           that the indexing may be changed in the process.
        //
        //   -- If there are fewer than candidates workers remaining, choose
        //      the worker with the lowest cost among them.Break the tie
        //      by the smallest index.
        //
        //   -- A worker can only be chosen once.
        //
        // Return the total cost to hire exactly k workers.

        // LeetCode 2462. Total Cost to Hire K Workers
        //
        //
        // Time:  O(K+Candidates)LogN)
        // Space: O(Candidates)
        //
        public static long TotalCost(int[] costs, int k, int candidates)
        {
            int n = costs.Length;
            long total = 0;

            var leftHeap = new PriorityQueue<(int cost, int index), (int cost, int index)>();
            var rightHeap = new PriorityQueue<(int cost, int index), (int cost, int index)>();

            int left = 0;
            int right = n - 1;

            // fill the left
            for (int i = 0; i < candidates && left <= right; i++)
            {
                leftHeap.Enqueue((costs[left], left), (costs[left], left));
                left++;
            }

            // file the right
            for (int i = 0; i < candidates && left <= right; i++)
            {
                rightHeap.Enqueue((costs[right], right), (costs[right], right));
                right--;
            }

            for (int i = 0; i < k; i++)
            {
                if (rightHeap.Count > 0 &&
                   (leftHeap.Count == 0 ||
                    rightHeap.Peek().cost < leftHeap.Peek().cost ||
                    (rightHeap.Peek().cost == leftHeap.Peek().cost &&
                     rightHeap.Peek().index < leftHeap.Peek().index)))
                {
                    var worker = rightHeap.Dequeue();
                    total += worker.cost;

                    // continue the fill
                    if (left <= right)
                    {
                        rightHeap.Enqueue((costs[right], right), (costs[right], right));
                        right--;
                    }
                }
                else
                {
                    var worker = leftHeap.Dequeue();
                    total += worker.cost;

                    // continue the fill
                    if (left <= right)
                    {
                        leftHeap.Enqueue((costs[left], left), (costs[left], left));
                        left++;
                    }
                }
            }

            return total;
        }
    }
}
