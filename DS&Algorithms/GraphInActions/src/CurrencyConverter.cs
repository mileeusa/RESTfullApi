using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraphInActions
{
    public class CurrencyConverter
    {
        /// <summary>
        /// conversionList = [("A", "B", 1.1), ("A", "C", 2.1), ("A", "D", 2.64), ("B", "C", 2.0), 
        ///                   ("B", "D", 2.4), ("B", "E", 4.0), ("C", "E", 2.1), ("C", "D", 1.26), 
        ///                   ("F", "C", 3.0), ("D", "F", 2.7), ("F", "G", 2.0)]
        ///
        /// Write a function like calculateConversion(source, destination, conversionList) that will 
        /// take a source country, destination, and the list of conversions, and returns the 
        /// conversion steps, and overall conversion factor, if there is any. 
        /// 
        /// for example: calculateConversion("A", "E", conversionList) => ["A", "B", "E"] , 4.4 = 1.1 * 4 
        ///              calculateConversion("F", "D", conversionList) => ["F", "C", "D"] , 3.78
        /// 
        /// NOTE: The conversion is direct graph issue, i.e. directional, not bidirectional.
        /// 
        /// </summary>
        /// <param name="source"></param>
        /// <param name="destination"></param>
        /// <param name="conversionList"></param>
        /// <returns></returns>
        /// 
        /// LeetCode: 
        /// 
        public static (List<string> path, double factor) CalculateConversion(
            string source, string destination, List<(string, string, double)> conversionList)
        {
            // Build adjacency list (graph)
            var graph = new Dictionary<string, List<(string, double)>>();
            foreach (var (from, to, rate) in conversionList)
            {
                if (!graph.ContainsKey(from))
                    graph[from] = [];

                // Ensure keys exist so we can detect missing nodes cleanly
                if (!graph.ContainsKey(to))
                    graph[to] = [];

                graph[from].Add((to, rate));
            }

            if (!graph.ContainsKey(source) || !graph.ContainsKey(destination))
                return (new List<string>(), 0.0);

            // Breadth-First Search (BFS) for fewest-steps path
            var q = new Queue<string>();
            q.Enqueue(source);

            var visited = new HashSet<string> { source };
            var parent = new Dictionary<string, (string prev, double rateFromPrev)>();

            while (q.Count > 0)
            {
                var u = q.Dequeue();
                if (u == destination) break;

                foreach (var (v, rate) in graph[u])
                {
                    if (!visited.Contains(v))
                    {
                        visited.Add(v);
                        q.Enqueue(v);
                        parent[v] = (u, rate);
                    }
                }
            }

            // Reconstruct path (if any)
            if (source != destination && !parent.ContainsKey(destination))
                return (new List<string>(), 0.0);

            var path = new List<string>();
            string cur = destination;
            path.Add(cur);
            double factor = 1.0;

            while (cur != source)
            {
                var (prev, rate) = parent[cur];
                factor *= rate;
                cur = prev;
                path.Add(cur);
            }

            path.Reverse();

            return (path, factor);
        }        
    }
}
