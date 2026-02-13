using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraphInActions.src
{
    public class DiameterOps
    {
        public static int GraphDiameter(Dictionary<int, List<(int neighbor, int weight)>> graph)
        {
            int diameter = 0;
            foreach (var node in graph.Keys)
            {
                var distances = PathOps.DijkstraShortestPaths(graph, node);
                int maxDistFromNode = distances.Values.Where(d => d < int.MaxValue).DefaultIfEmpty(0).Max();
                diameter = Math.Max(diameter, maxDistFromNode);
            }
            return diameter;
        }

        /// <summary>
        /// Calculates the diameter of a weighted tree (longest path between any two nodes).
        /// </summary>
        /// <param name="graph">Adjacency list representing the tree (Undirected).</param>
        /// <returns></returns>
        public static int TreeDiameterUndirected(Dictionary<int, List<(int neighbor, int weight)>> graph)
        {
            // Edge case: Empty tree has no diameter
            if (graph == null || graph.Count == 0)
                return 0;

            // 1. Pick an arbitrary start node (e.g., the first key found)
            int arbitraryNode = graph.Keys.First();

            // 2. First BFS: Find the furthest node from the arbitrary node
            (int furthestNodeA, _) = GetFurthestNodeUndirected(graph, arbitraryNode);

            // 3. Second BFS: Find the furthest node from A. 
            //    The distance calculated here is the diameter.
            (_, int diameter) = GetFurthestNodeUndirected(graph, furthestNodeA);

            return diameter;
        }

        /// <summary>
        /// Helper method using BFS to find the furthest node and its distance from a start node.
        /// </summary>
        private static (int node, int maxDist) GetFurthestNodeUndirected(Dictionary<int, List<(int neighbor, int weight)>> graph, int startNode)
        {
            // Track visited nodes and their distances from startNode
            var distances = new Dictionary<int, int>();
            var queue = new Queue<int>();

            distances[startNode] = 0;
            queue.Enqueue(startNode);

            int maxNode = startNode;
            int maxDist = 0;

            while (queue.Count > 0)
            {
                int u = queue.Dequeue();
                int currentDist = distances[u];

                // Update max if this node is further away
                if (currentDist > maxDist)
                {
                    maxDist = currentDist;
                    maxNode = u;
                }

                // Iterate neighbors
                if (graph.TryGetValue(u, out var neighbors))
                {
                    foreach (var (neighbor, weight) in neighbors)
                    {
                        // If not visited yet
                        if (!distances.ContainsKey(neighbor))
                        {
                            distances[neighbor] = currentDist + weight;
                            queue.Enqueue(neighbor);
                        }
                    }
                }
            }

            return (maxNode, maxDist);
        }

        /// <summary>
        /// Calculates the diameter of a directed (rooted) tree.
        /// The diameter is the longest path between any two nodes, treating edges as undirected,
        /// even though the input structure only allows Parent -> Child traversal.
        /// </summary>
        public static int TreeDiameterDirected(Dictionary<int, List<(int neighbor, int weight)>> tree)
        {
            if (tree == null || tree.Count == 0) return 0;

            int maxDiameter = 0;

            // Since we don't know the root, and the tree might be a forest (disconnected), we can attempt to process from nodes. 
            // We use memoization to ensure O(N) complexity even if we start from non-root nodes multiple times.
            var memoHeight = new Dictionary<int, int>();

            foreach (var node in tree.Keys)
            {
                if (!memoHeight.ContainsKey(node))
                {
                    GetLongestPathDown(tree, node, memoHeight, ref maxDiameter);
                }
            }

            return maxDiameter;
        }

        /// <summary>
        /// Recursive method to find the longest path downwards from the current node to a leaf.
        /// Updates the global _maxDiameter as it calculates heights.
        /// </summary>
        public static int GetLongestPathDown(
            Dictionary<int, List<(int neighbor, int weight)>> tree, 
            int currentNode,
            Dictionary<int, int> memo, ref int maxDiameter)
        {
            // If we already calculated the height for this node, return it.
            if (memo.TryGetValue(currentNode, out int value))
            {
                return value;
            }

            int max1 = 0; // First longest path down
            int max2 = 0; // Second longest path down

            // If the node has children (is in keys)
            if (tree.TryGetValue(currentNode, out var neighbors))
            {
                foreach (var (neighbor, weight) in neighbors)
                {
                    // Recursively get the height of the child
                    int heightFromChild = GetLongestPathDown(tree, neighbor, memo, ref maxDiameter) + weight;

                    // Update the top 2 longest paths
                    if (heightFromChild > max1)
                    {
                        max2 = max1;
                        max1 = heightFromChild;
                    }
                    else if (heightFromChild > max2)
                    {
                        max2 = heightFromChild;
                    }
                }
            }

            // The diameter passing THROUGH this node is the sum of the two longest paths down.
            maxDiameter = Math.Max(maxDiameter, max1 + max2);

            // Memoize and return the single longest path extending down from this node.
            memo[currentNode] = max1;
            return max1;
        }
    }
}
