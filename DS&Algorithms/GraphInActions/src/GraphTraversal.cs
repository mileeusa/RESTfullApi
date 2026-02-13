using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraphInActions
{
    public class GraphTraversal
    {
        private readonly int _vertices;
        private readonly Dictionary<int, List<int>> _adjacencyList = [];

        /// <summary>
        /// BFSGraph Representation: The graph is represented using an adjacency list.
        /// 
        /// BFS Algorithm:
        ///   A Queue is used to explore nodes level by level.
        ///   A visited array ensures nodes are not revisited.
        /// 
        /// Output: The BFS traversal prints nodes in the order they are visited.
        /// 
        /// </summary>
        /// 
        /// This implementation is simple and works for directed or undirected graphs. You can 
        /// adapt it further for weighted graphs or specific use cases like finding the 
        /// shortest path in unweighted graphs.
        /// 
        public GraphTraversal(int vertices)
        {
            _vertices = vertices;
            for (int i = 0; i < vertices; i++)
            {
                _adjacencyList[i] = [];
            }
        }

        // Add an edge to the graph
        public void AddEdge(int source, int destination)
        {
            _adjacencyList[source].Add(destination);
        }

        // Perform BFS traversal
        public List<int> GraphTraversalBFS(int startVertex)
        {
            List<int> result = [];
            bool[] visited = new bool[_vertices];
            Queue<int> queue = new();

            visited[startVertex] = true;
            queue.Enqueue(startVertex);

            while (queue.Count > 0)
            {
                int currentVertex = queue.Dequeue();
                //Console.Write(currentVertex + " ");

                result.Add(currentVertex);

                foreach (int neighbor in _adjacencyList[currentVertex])
                {
                    if (!visited[neighbor])
                    {
                        visited[neighbor] = true;
                        queue.Enqueue(neighbor);
                    }
                }
            }
            //Console.WriteLine();
            //Console.WriteLine();

            return result;
        }
    }
}
