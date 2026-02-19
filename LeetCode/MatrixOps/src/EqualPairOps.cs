using ArrayInActions.src;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace MatrixOps.src
{
    public class EqualPairOps
    {
        //
        // Given a 0-indexed n x n integer matrix grid, return the number of
        // pairs (ri, cj) such that row ri and column cj are equal.
        //
        // A row and column pair is considered equal if they contain the
        // same elements in the same order (i.e., an equal array).
        //
        // Time complexity:  O(N^2)
        // Space complexity: O(N^2)
        //
        public static int EqualPairs(int[][] grid)
        {
            int n = grid.Length;

            var map = new Dictionary<string, int>();

            for (int row = 0; row < n; row++)
            {
                string key = string.Join(", ", grid[row]);
                map[key] = map.GetValueOrDefault(key) + 1;
            }

            int count = 0;

            for (int col = 0; col < n; col++)
            {
                var cols = new int[n];
                for (int row = 0; row < n; row++)
                {
                    cols[row] = grid[row][col];
                }

                string key = string.Join(", ", cols);

                if (map.TryGetValue(key, out var value))
                {
                    count += value;
                }
            }

            return count;
        }

        public static int EqualPairs_Custom_Comparer(int[][] grid)
        {
            int n = grid.Length;

            var rowCount = new Dictionary<int[], int>(new IntArrayComparer());

            for (int row = 0; row < n; row++)
            {
                if (!rowCount.TryAdd(grid[row], 1))
                {
                    rowCount[grid[row]]++;
                }
            }

            int count = 0;

            for (int col = 0; col < n; col++)
            {
                var cols = new int[n];
                for (int row = 0; row < n; row++)
                {
                    cols[row] = grid[row][col];
                }

                if (rowCount.TryGetValue(cols, out var value))
                {
                    count += value;
                }
            }

            return count;
        }
    }
}
