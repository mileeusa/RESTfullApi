using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.Security.AccessControl;
using System.Security.Cryptography;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using static System.Formats.Asn1.AsnWriter;

namespace GraphInActions.src
{
    public class DirectedGraph_BFS_CheapestFlightPrice
    {
        //
        // There are n cities connected by some number of flights. You are given
        // an array flights where flights[i] = [fromi, toi, pricei] indicates
        // that there is a flight from city fromi to city toi with cost pricei.
        //
        // You are also given three integers src, dst, and k, return the cheapest
        // price from src to dst with at most k stops.If there is no such route,
        // return -1.

        // LeetCode 787:
        //    Cheapest Flights Within K Stops
        //
        // Time complexity:  O(E * (K+1)) // N: number of cities, E: number of flights, K: number of stops
        // Space complexity: O(N)
        //
        public static int FindCheapestPrice_BellmanFord(int n, int[][] flights, int src, int dst, int k)
        {
            var cost = new int[n];
            Array.Fill(cost, int.MaxValue / 2);
            cost[src] = 0;

            for (int i = 0; i <= k; i++)
            {
                var newCost = (int[])cost.Clone();

                foreach (var f in flights)
                {
                    var u = f[0];
                    var v = f[1];
                    var price = f[2];

                    int currentCost = cost[u] + price;

                    if (currentCost < newCost[v])
                    {
                        newCost[v] = currentCost;
                    }
                }

                cost = newCost;
            }

            return (cost[dst] == int.MaxValue) ? -1 : cost[dst];
        }

        public static int FindCheapestPrice_BFS(int n, int[][] flights, int src, int dst, int k)
        {
            var graph = new Dictionary<int, List<(int, int)>>();

            // build the adjacency/edge for direct graph
            foreach (var f in flights)
            {
                if (!graph.ContainsKey(f[0]))
                {
                    graph[f[0]] = new List<(int, int)>();
                }

                graph[f[0]].Add((f[1], f[2]));
            }

            // BFS
            var q = new Queue<(int node, int cost, int stops)>();
            q.Enqueue((src, 0, 0));

            var minCost = new int[n];
            Array.Fill(minCost, int.MaxValue);
            minCost[src] = 0;
            int maxEdges = k + 1;

            int result = int.MaxValue;

            while (q.Count > 0)
            {
                var (node, cost, stops) = q.Dequeue();
                if (stops > maxEdges) continue;

                if (node == dst)
                {
                    result = Math.Min(result, cost);
                    continue;
                }

                if (!graph.ContainsKey(node)) continue;

                foreach (var (next, price) in graph[node])
                {
                    int newCost = cost + price;
                    if (newCost < minCost[next])
                    {
                        minCost[next] = newCost;
                        q.Enqueue((next, newCost, stops + 1));
                    }
                }
            }

            return (result == int.MaxValue) ? -1 : result;
        }
    }
}
