using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArrayInActions.src
{
    public class LargestAreaOps
    {
        public static long LargestSquareArea(int[][] bottomLeft, int[][] topRight)
        {
            int n = bottomLeft.Length;
            long maxArea = 0;

            for (int i = 0; i < n; i++)
            {
                for (int j = i + 1; j < n; j++)
                {
                    int left   = Math.Max(bottomLeft[i][0], bottomLeft[j][0]);
                    int bottom = Math.Max(bottomLeft[i][1], bottomLeft[j][1]);

                    int right  = Math.Min(topRight[i][0], topRight[j][0]);
                    int top    = Math.Min(topRight[i][1], topRight[j][1]);

                    int width = right - left;
                    int height = top - bottom;

                    if (width > 0 && height > 0)
                    {
                        int side = Math.Min(width, height);
                        maxArea = Math.Max(maxArea, (long)side * side);
                    }
                }
            }

            return maxArea;
        }
    }
}
