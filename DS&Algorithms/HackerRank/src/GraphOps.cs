using Newtonsoft.Json.Linq;
using NUnit.Framework.Internal.Execution;
using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace HackerRank.src
{
    // Helper class for Union-Find (Disjoint Set Union)
    public class DSU
    {
        private int[] parent;
        public DSU(int n)
        {
            parent = Enumerable.Range(0, n).ToArray();
        }

        public int Find(int i)
        {
            if (parent[i] == i) return i;
            return parent[i] = Find(parent[i]); // Path compression
        }

        public bool Union(int i, int j)
        {
            int rootI = Find(i);
            int rootJ = Find(j);
            if (rootI != rootJ)
            {
                parent[rootI] = rootJ;
                return true;
            }
            return false;
        }
    }

    public struct Edge
    {
        public int U, V, Cost;
    }

    public class GraphOps
    {
        // the developers of Hackerland aims to build a server network across the country to
        // enhance their applications. the country can be visualized as a large coordinate
        // grid where n servers are installed at various coordinates, with ith server
        // located at(x[i], y[i]). The cost to connect any two servers i and j is
        // calculated as min(abs(x[i]-x[j]), abs(y[i] - y[j])), where i and j the
        // absolute value of an integer a.
        //
        // Given arrays x and y(List<int>) of n integer each, determine the min cost to
        // construct a network such that every server is reachable from every other servers,
        // either directly or indirectly.
        //
        // Return the min possible cost to construct the network such that every server is
        // reachable from every other servers.
        //
        // Analysis:
        //   This is a classic variation of the Minimum Spanning Tree (MST) problem.The catch
        //   here is the cost function: cost(i, j) = min(|x[i] - x[j]|, |y[i] - y[j]|). In a
        //   standard MST problem with N nodes, you'd have N(N-1)/2 edges. With N potentially
        //   being large, we can't check every pair.The StrategyTo minimize the cost
        //   efficiently, we only need to consider "neighboring" servers.
        //
        //   Specifically: Sort the servers by their X-coordinates and consider edges between
        //   adjacent servers in the sorted list.Sort the servers by their Y-coordinates
        //   and consider edges between adjacent servers in the sorted list.This reduces
        //   our edges from O(N^2) to O(N), which we can then process using
        //   Kruskal's Algorithm and a Union-Find data structure.
        //
        // Time complexity: Sorting takes O(nlogn) and Kruskal's takes O(ElogE). Since we
        //                  limited our edges to 2N, the total time complexity is a
        //                  very healthy O(nlogn).
        // Space complexity: O(N)
        //
        public static int GetMinCost(List<int> x, List<int> y)
        {
            int n = x.Count;
            var edges = new List<Edge>();
            var points = new List<(int val, int id)>();

            // 1. Generate edges based on X-axis neighbors
            for (int i = 0; i < n; i++) 
                points.Add((x[i], i));

            points = points.OrderBy(p => p.val).ToList();

            for (int i = 0; i < n - 1; i++)
            {
                edges.Add(new Edge
                {
                    U = points[i].id,
                    V = points[i + 1].id,
                    Cost = Math.Abs(points[i].val - points[i + 1].val)
                });
            }

            // 2. Generate edges based on Y-axis neighbors
            points.Clear();
            for (int i = 0; i < n; i++) 
                points.Add((y[i], i));

            points = points.OrderBy(p => p.val).ToList();

            for (int i = 0; i < n - 1; i++)
            {
                edges.Add(new Edge
                {
                    U = points[i].id,
                    V = points[i + 1].id,
                    Cost = Math.Abs(points[i].val - points[i + 1].val)
                });
            }

            // 3. Kruskal's Algorithm
            edges = edges.OrderBy(e => e.Cost).ToList();
            DSU dsu = new DSU(n);
            int minCost = 0;
            int edgesUsed = 0;

            foreach (var edge in edges)
            {
                if (dsu.Union(edge.U, edge.V))
                {
                    minCost += edge.Cost;
                    edgesUsed++;
                    if (edgesUsed == n - 1) break;
                }
            }

            return minCost;
        }
    }
}
