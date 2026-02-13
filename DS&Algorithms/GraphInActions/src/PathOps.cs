using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraphInActions.src
{
    public class PathOps
    {
        // Implement Dijkstra’s /ˈdɑɪkstɹə/ shortest path from a source node to all other nodes in a weighted graph (non-negative weights).
        public static Dictionary<int, int> DijkstraShortestPaths(Dictionary<int, List<(int neighbor, int weight)>> graph, int start)
        {
            var dist = new Dictionary<int, int>();  // vertex, distance
            var pq = new PriorityQueue<int, int>(); // vertex, distance <- min-heap

            foreach (var node in graph.Keys)
            {
                dist[node] = int.MaxValue;
            }

            dist[start] = 0;
            pq.Enqueue(start, 0);

            while (pq.Count > 0)
            {
                pq.TryDequeue(out int node, out int d);

                if (d > dist[node])
                {
                    // outdated tuple
                    continue;
                }

                foreach (var (neighbor, weight) in graph[node])
                {
                    if (!dist.TryGetValue(neighbor, out int currDist))
                    {
                        dist[neighbor] = int.MaxValue;
                    }

                    int newDist = d + weight;

                    if (newDist < currDist)
                    {
                        dist[neighbor] = newDist;
                        pq.Enqueue(neighbor, newDist);
                    }
                }
            }

            return dist;
        }

        // BFS search
        public static List<int> ShortestPathUnweighted(Dictionary<int, List<int>> graph, int start, int target)
        {
            var parent = new Dictionary<int, int?>(); // node, parent node
            var q = new Queue<int>();

            q.Enqueue(start);
            parent[start] = -1;

            while (q.Count > 0)
            {
                int node = q.Dequeue();

                if (node == target)
                {
                    break;
                }

                foreach (var neighbor in graph[node])
                {
                    if (!parent.ContainsKey(neighbor))
                    {
                        parent[neighbor] = node;
                        q.Enqueue(neighbor);
                    }
                }
            }

            // reconstruct path
            if (!parent.ContainsKey(target))
            {
                return []; // no path found
            }

            var path = new List<int>();

            for (int curr = target; curr > 0; curr = parent[curr]!.Value)
            {
                path.Add(curr);
            }

            path.Reverse();

            return path;
        }

        //
        // Tree ⇒ unique path ⇒ DFS once per query or preprocess LCA.
        //
        public static int ShortestPathWeighted(Dictionary<int, List<(int next, int w)>> graph, int start, int target)
        {

            HashSet<int> visited = [];
            return ShortestPathWeightedDfs(graph, visited, start, target, 0);
        }

        public static int ShortestPathWeightedDfs(Dictionary<int, List<(int next, int w)>> graph, HashSet<int> visited, int node, int target, int dist)
        {
            if (node == target)
            {
                return dist;
            }

            if (graph.TryGetValue(node, out var pair))
            {
                visited.Add(node);
                foreach (var (next, w) in pair)
                {
                    if (!visited.Contains(next))
                    {
                        int res = ShortestPathWeightedDfs(graph, visited, next, target, dist + w);
                        if (res != -1)
                        {
                            return res;
                        }
                    }
                }
            }

            return -1;
        }
    }
}
