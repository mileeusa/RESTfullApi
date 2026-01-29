using Microsoft.ApplicationInsights;
using NUnit.Framework.Internal.Execution;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace MatrixOps.src
{
    public class DiagonalOps
    {
        //
        // You’re given an m x n matrix. Return all elements in diagonal order, alternating direction for each diagonal.
        //
        // LeetCode 498 — Diagonal Traverse
        //
        // Time:  O(m·n)
        // Space: O(m·n)
        //
        // Key Observation
        //
        //   All elements on the same diagonal share the same sum:
        //   diagonal index = row + col
        //     Diagonal 0 → (0,0)
        //     Diagonal 1 → (0,1), (1,0)
        //     Diagonal 2 → (0,2), (1,1), (2,0)
        //   …
        //   Direction rule:
        //     Even diagonal index → traverse upward (reverse order)
        //     Odd diagonal index  → traverse downward(normal order)
        //
        public static int[] FindDiagonalOrder(int[][] mat)
        {
            if (mat == null || mat.Length == 0 || mat[0].Length == 0) return [];

            int m = mat.Length;
            int n = mat[0].Length;

            var dict = new Dictionary<int, List<int>>();

            for (int i = 0; i < m; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    int d = i + j;

                    if (!dict.ContainsKey(d))
                    {
                        dict[d] = new List<int>();
                    }

                    dict[d].Add(mat[i][j]);
                }
            }

            var res = new int[m*n];
            int index = 0;

            for (int d = 0; d < m + n - 1; d++)
            {
                if (d % 2 == 0)
                    dict[d].Reverse();

                foreach (var v in dict[d])
                {
                    res[index++] = v;
                }
            }

            return res;
        }
    }
}
