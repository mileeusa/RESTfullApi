using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraphInActions.src
{
    public class OrangeRottingOps
    {
        public static int OrangeRotting(int[][] grid)
        {
            int rows = grid.Length;
            int cols = grid[0].Length;

            var queue = new Queue<(int r, int c, int time)>();
            int freshCount = 0;

            for (int r = 0; r < rows; r++)
                for (int c = 0; c < cols; c++)
                    if (grid[r][c] == 2)
                        queue.Enqueue((r, c, 0));
                    else if (grid[r][c] == 1)
                        freshCount++;
            
            if (freshCount == 0) return 0; // No fresh oranges to rot

            int minutes = 0;
            int[] dr = new int[] { -1, 1, 0, 0 };
            int[] dc = new int[] { 0, 0, -1, 1 };

            // BFS to rot adjacent fresh oranges
            while (queue.Count > 0)
            {
                var (r, c, time) = queue.Dequeue();
                minutes = Math.Max(minutes, time);

                for (int i = 0; i < 4; i++)
                {
                    int nr = r + dr[i];
                    int nc = c + dc[i];
                    if (nr >= 0 && nr < rows && nc >= 0 && nc < cols && grid[nr][nc] == 1)
                    {
                        grid[nr][nc] = 2; // Rot the fresh orange
                        queue.Enqueue((nr, nc, time + 1));
                        freshCount--;
                    }
                }
            }
            return freshCount > 0 ? -1 : minutes; 
        }
    }
}
