using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace GraphInActions.src
{
    public class ShortestDistanceOps
    {
        //
        // You are given an integer n and a 2D integer array queries.
        //
        // There are n cities numbered from 0 to n - 1. Initially, there is a unidirectional
        // road from city i to city i + 1 for all 0 <= i < n - 1.
        //
        // queries[i] = [ui, vi] represents the addition of a new unidirectional road from
        // city ui to city vi. After each query, you need to find the length of
        // the shortest path from city 0 to city n - 1.
        //
        // There are no two queries such that queries[i][0] < queries[j][0] < queries[i][1] < queries[j][1].
        //
        // Return an array answer where for each i in the range [0, queries.length - 1],
        // answer[i] is the length of the shortest path from city 0 to city n - 1
        // after processing the first i + 1 queries.
        //
        // LeetCode 3244. Shortest Distance After Road Addition Queries II
        //
        // Difficulty: Hard
        //
        public static int[] ShortestDistanceAfterQueries(int n, int[][] queries)
        {
            var map = new Dictionary<int, int>();
            for (int i = 0; i < n - 1; i++)
                map[i] = i + 1;

            var ans = new List<int>();
            for (int i = 0; i < queries.Length; i++)
            {
                int u = queries[i][0];
                int v = queries[i][1];

                if (!map.ContainsKey(u) || map[u] > v)
                {
                    ans.Add(map.Count);
                    continue;
                }

                int j = map[u];
                while (j < v)
                {
                    map.Remove(j);
                    j++;
                }

                map[u] = v;

                ans.Add(map.Count);
            }

            return ans.ToArray();
        }
    }
}
