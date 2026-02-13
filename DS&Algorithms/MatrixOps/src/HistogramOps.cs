using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MatrixOps.src
{
    public class HistogramOps
    {
        public static int MaximalRectangle(char[][] matrix)
        {
            if (matrix == null || matrix.Length == 0 || matrix[0].Length == 0)
                return 0;

            int m = matrix.Length;
            int n = matrix[0].Length;

            var heights = new int[n];

            int maxArea = 0;

            for (int i = 0; i < n; i++)
            {
                for (int j = 0; i <= m; j++)
                {
                    if (matrix[i][j] == '1')
                        heights[j]++;
                    else
                        heights[j] = 0;
                }

                maxArea = Math.Max(maxArea, LargestRechtangleArea(heights));
            }

            return maxArea;
        }

        public static int LargestRechtangleArea(int[] heights)
        {
            int maxArea = 0;
            var stack = new Stack<int>();

            for (int i = 0; i <= heights.Length; i++)
            {
                int currentHeight = (i == heights.Length) ? 0 : heights[i];
                while (stack.Count > 0 && currentHeight < heights[stack.Peek()])
                {
                    int h = heights[stack.Pop()];
                    int width = (stack.Count == 0) ? i : i - stack.Peek() - 1;
                    maxArea = Math.Max(maxArea, h * width);
                }

                stack.Push(i);
            }

            return maxArea;

        }
    }
}