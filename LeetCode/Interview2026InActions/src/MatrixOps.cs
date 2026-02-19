using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace Interview2026InActions.src
{
    public class MatrixOps
    {
        public static List<int> SpiralMatrix(int[][] grid)
        {
            if (grid == null || grid.Length == 0) return new List<int>();

            int m = grid.Length;
            int n = grid[0].Length;

            int top = 0;
            int bottom = m - 1;

            int left = 0;
            int right = n - 1;

            var ans = new List<int>();

            while (ans.Count < m * n) {
                // left to right
                for (int c = left; c <= right; c++) {
                    ans.Add(grid[top][c]);
                }

                // top to bottom
                for (int r = top + 1; r <= bottom; r++) {
                    ans.Add(grid[r][right]);
                }

                // right to left
                if (top != bottom)
                {
                    for (int c = right - 1; c >= left; c--) {
                        ans.Add(grid[bottom][c]);
                    }
                }

                // bottom to top
                if (bottom != top)
                {
                    for (int r = bottom - 1; r > top; r--) {
                        ans.Add(grid[r][left]);
                    }
                }

                top++;
                bottom--;
                left++;
                right--;
            }

            return ans;
        }
    }
}
