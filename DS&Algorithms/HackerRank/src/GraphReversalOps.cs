using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace HackerRank.src
{
    public class GraphReversalOps
    {
        // A country can be represented as a graph with g_nodes cities connected by (g_nodes - 1) uni-directional edges. The ith edge connects
        // cities g_front[i] and g_to[i].
        //
        // If the roads were bi-directional, every node would be reachable from every other node.The resulting graph would be a tree.
        //
        // for each city i (1 <= i <= g_nodes), find the minimum number of edges that must be reversed so that it is possible travel from
        // city i to any other city using the directed edges.
        //
        // Example:
        //
        //   g_nodes = 4
        //   g_edges = 3
        //   g_from = [1, 2, 3]
        //   g_to = [4, 4, 4]
        //
        // return [2, 2, 2, 3]
        //
        // Complete the function CountReverseEdges with the following params:
        //   int g_nodes: the numbe of nodes
        //   int g_edges: the number of edges in the graph
        //   int g_from[g_edges]: the original node of each directed edge
        //   int g_to[g_edges]: the terminal node of each directed edge
        //
        // Return:
        //   int[g_node]: the ith integer is the minimum number of edges to reverse so that other node is reachable from the ith node
        //
        // Time complexity: O(N)
        // Space complexity: O(N)
        //
        public static List<int> CountReverseEdges(int gNodes, List<int> gFrom, List<int> gTo)
        {
            //
            // Build adjacency list: (neighbor, weight)
            // weight 0 = original direction (u -> v)
            // weight 1 = reverse direction (v -> u)
            //
            var adj = new List<(int node, int isReverse)>[gNodes + 1];

            for (int i = 1; i <= gNodes; i++) 
                adj[i] = [];

            for (int i = 0; i < gFrom.Count; i++)
            {
                int u = gFrom[i];
                int v = gTo[i];                
                adj[u].Add((v, 0)); // To go u -> v, it costs 0 reversals.
                adj[v].Add((u, 1)); // To go v -> u, it costs 1 reversal because the original was u -> v.
            }

            int[] results = new int[gNodes + 1];
            bool[] visited = new bool[gNodes + 1];
            var q = new Queue<int>();

            // --- STEP 1: Calculate cost for Node 1 to reach all others ---
            q.Enqueue(1);
            visited[1] = true;

            int rootReversals = 0;

            while (q.Count > 0)
            {
                int u = q.Dequeue();
                foreach (var (node, isReverse) in adj[u])
                {
                    if (!visited[node])
                    {
                        visited[node] = true;                        
                        rootReversals += isReverse; // If we traverse a '1' edge, we reversed an original edge
                        q.Enqueue(node);
                    }
                }
            }

            // --- STEP 2: Propagate costs using BFS Rerooting ---
            Array.Fill(visited, false);
            results[1] = rootReversals;
            q.Enqueue(1);
            visited[1] = true;

            while (q.Count > 0)
            {
                int u = q.Dequeue();
                foreach (var (node, isReverse) in adj[u])
                {
                    if (!visited[node])
                    {
                        visited[node] = true;

                        results[node] = (isReverse == 0) ? results[u] + 1 : results[u] - 1;
                        q.Enqueue(node);
                    }
                }
            }

            List<int> ans = new List<int>();
            for (int i = 1; i <= gNodes; i++) 
                ans.Add(results[i]);

            return ans;
        }
    }
}
