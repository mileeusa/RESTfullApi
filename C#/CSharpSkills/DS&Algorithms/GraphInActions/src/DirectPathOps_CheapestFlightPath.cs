using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraphInActions.src
{
    public class DirectPathOps_CheapestFlightPath
    {
        public static List<int> FindCheapestFlightPath_BellmanFord(int n, int[][] flights, int src, int dst, int k)
        {
            const int INF = int.MaxValue / 2;
            int maxEdges = k + 1;

            int[,] cost = new int[maxEdges + 1, n];   // min cost to each v using exactly i edges
            int[,] parent = new int[maxEdges + 1, n]; // previous node on that path

            for (int i = 0; i <= maxEdges; i++)
                for (int v = 0; v < n; v++)
                    cost[i, v] = INF;

            cost[0, src] = 0;

            for (int i = 1; i <= maxEdges; i++)
            {
                foreach (var f in flights)
                {
                    var u = f[0];
                    var v = f[1];
                    var price = f[2];

                    if (cost[i - 1, u] + price < cost[i, v])
                    {
                        cost[i, v] = cost[i - 1, u] + price;
                        parent[i, v] = u;
                    }
                }
            }

            // Find best layer for destination
            int bestLayer = -1;
            int bestCost = INF;

            for (int i = 1; i <= maxEdges; i++)
            {
                if (cost[i, dst] < bestCost)
                {
                    bestCost = cost[i, dst];
                    bestLayer = i;
                }
            }

            if (bestLayer == -1)
                return new List<int>();

            // reconstruct the path
            var path = new List<int>();
            int curr = dst;
            int layer = bestLayer;

            while (layer >= 0)
            {
                path.Add(curr);
                if (curr == src) break;
                curr = parent[layer--, curr];
            }


            path.Reverse();

            return path;
        }
    }
}
