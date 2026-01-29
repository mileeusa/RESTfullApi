using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Channels;
using System.Threading.Tasks;
using static NUnit.Framework.Constraints.Tolerance;

namespace GraphInActions.src
{
    public class BFSOps
    {
        //
        // There are n cities numbered from 0 to n - 1 and n - 1 roads such that there is
        // only one way to travel between two different cities
        // (this network form a tree). Last year, The ministry of transport decided to
        // orient the roads in one direction because they are too narrow.
        //
        // Roads are represented by connections where connections[i] = [ai, bi]
        // represents a road from city ai to city bi.
        //
        // This year, there will be a big event in the capital (city 0), and many people
        // want to travel to this city.
        //
        // Your task consists of reorienting some roads such that each city can visit
        // the city 0. Return the minimum number of edges changed.
        //
        // It's guaranteed that each city can reach city 0 after reorder.
        //
        // Example 1:
        //   Input: n = 6, connections = [[0, 1],[1, 3],[2, 3],[4, 0],[4, 5]]
        //   Output: 3
        //   Explanation: Change the direction of edges show in red such that each node
        //   can reach the node 0 (capital).
        //
        // Leetcode 75: 
        //   Problem 1466 Reorder Routes to Make All Paths Lead to the City Zero
        //
        // Time:  O(N)
        // Space: O(N)
        //
        public static int MinReorder(int n, int[][] connections)
        {
            var graph = new List<int>[n];
            for (int i = 0; i < n; i++)
                graph[i] = new List<int>();

            // build adjacent list
            foreach (var conn in connections)
            {
                int from = conn[0];
                int to = conn[1];
                graph[from].Add(to);
                graph[to].Add(-from);
            }

            var visited = new bool[n];
            var queue = new Queue<int>();
            queue.Enqueue(0);

            visited[0] = true;
            int result = 0;

            // BFS
            while (queue.Count > 0)
            {
                int node = queue.Dequeue();
                foreach (var nei in graph[node])
                {
                    var absNei = Math.Abs(nei);

                    if (!visited[absNei])
                    {
                        if (nei > 0) result++;
                        visited[absNei] = true;
                        queue.Enqueue(absNei);
                    }
                }
            }

            return result;
        }
    }
}
