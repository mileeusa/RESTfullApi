using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraphInActions.src
{
    public class IslandsOps
    {
        // 
        // Given an m x n 2D binary grid grid which represents a map of '1's (land)
        // and '0's (water), return the number of islands.
        //
        // An island is surrounded by water and is formed by connecting adjacent
        // lands horizontally or vertically.
        //
        // You may assume all four edges of the grid are all surrounded by water.
        //
        //    Input: grid = [
        //       ["1","1","0","0","0"],
        //       ["1","1","0","0","0"],
        //       ["0","0","1","0","0"],
        //       ["0","0","0","1","1"]
        //    ]
        //    Output: 3
        //
        // LeetCode: 200. Number of Islands
        //
        // Time:  O(M * N)
        // Space: O(M * N) in the worst case of DFS recursion stack, or BFS iterative queue
        //
        // This is a connected components problem on a grid:
        //  - We can use DFS to explore each island and mark visited lands.
        //  - Each time we find an unvisited land ('1'), we increment the island count and
        //    perform DFS to mark all connected lands as visited.
        //
        public static int NumIslands(char[][] grid)
        {
            if (grid == null || grid.Length == 0)
            {
                return 0;
            }
            int numIslands = 0;
            int m = grid.Length;
            int n = grid[0].Length;

            for (int r = 0; r < m; r++)
            {
                for (int c = 0; c < n; c++)
                {
                    if (grid[r][c] == '1')
                    {
                        numIslands++;
                        DFS(grid, r, c);
                        //BFS(grid, r, c);
                    }
                }
            }
            return numIslands;
        }

        private static void DFS(char[][] grid, int r, int c)
        {
            int m = grid.Length;
            int n = grid[0].Length;

            if (r < 0 || c < 0 || r >= m || c >= n || grid[r][c] == '0')
            {
                return;
            }
            grid[r][c] = '0'; // mark as visited
            DFS(grid, r - 1, c); // up
            DFS(grid, r + 1, c); // down
            DFS(grid, r, c - 1); // left
            DFS(grid, r, c + 1); // right
        }

        private static void BFS(char[][] grid, int r, int c)
        {
            int rows = grid.Length;
            int cols = grid[0].Length;

            var queue = new Queue<(int, int)>();
            queue.Enqueue((r, c));

            grid[r][c] = '0'; // mark as visited

            int[] dr = { 1, -1, 0, 0 };
            int[] dc = { 0, 0, 1, -1 };

            while (queue.Count > 0)
            {
                var (x, y) = queue.Dequeue();

                for (int i = 0; i < 4; i++)
                {
                    int nx = x + dr[i];
                    int ny = y + dc[i];

                    if (nx >= 0 && ny >= 0 && nx < rows && ny < cols && grid[nx][ny] == '1')
                    {
                        grid[nx][ny] = '0';
                        queue.Enqueue((nx, ny));
                    }
                }
            }
        }
    }
}
