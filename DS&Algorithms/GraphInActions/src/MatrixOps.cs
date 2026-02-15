using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraphInActions.src
{
    public class MatrixOps
    {
        //
        // Given an m x n binary matrix mat, return the distance of the nearest 0 for each cell.
        //
        // The distance between two cells sharing a common edge is 1.
        //
        // Example:
        //   Input: mat = [[0,0,0],[0,1,0],[1,1,1]]
        //   Output: [[0, 0, 0],[0, 1, 0],[1, 2, 1]]
        //
        // LeetCode 542. 01 Matrix
        //
        public int[][] UpdateMatrix(int[][] mat)
        {
            int m = mat.Length;
            int n = mat[0].Length;

            var matrix = new int[m][];
            var seen = new bool[m][];
            var queue = new Queue<(int row, int col, int steps)>();

            for (int r = 0; r < m; r++)
            {
                matrix[r] = new int[n];
                seen[r] = new bool[n];
            }

            for (int r = 0; r < m; r++)
            {
                for (int c = 0; c < n; c++)
                {
                    matrix[r][c] = mat[r][c];

                    if (matrix[r][c] == 0)
                    {
                        queue.Enqueue((r, c, 0));
                        seen[r][c] = true;
                    }
                }
            }

            var directions = new int[][]
            {
                [ 0,  1 ],
                [ 1,  0 ],
                [ 0, -1 ],
                [-1,  0 ]
            };

            while (queue.Count > 0)
            {
                var item = queue.Dequeue();
                int row = item.row;
                int col = item.col;
                int steps = item.steps;

                foreach (var dir in directions)
                {
                    int nRow = row + dir[0];
                    int nCol = col + dir[1];

                    if (IsValid(nRow, nCol, m, n) && !seen[nRow][nCol])
                    {
                        seen[nRow][nCol] = true;
                        matrix[nRow][nCol] = steps + 1;
                        queue.Enqueue((nRow, nCol, steps + 1));
                    }
                }
            }

            return matrix;
        }

        protected static bool IsValid(int r, int c, int rows, int cols)
        {
            return (r >= 0 && r < rows && c >= 0 && c < cols);
        }
    }
}
