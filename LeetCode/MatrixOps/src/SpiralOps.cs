using ListInActions.model;
using Microsoft.ApplicationInsights;
using Microsoft.Testing.Platform.Extensions.Messages;
using NUnit.Framework;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using static System.Net.WebRequestMethods;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace MatrixOps.src
{
    public class SpiralOps
    {
        //
        // Given an m x n matrix, return all elements of the matrix in spiral order.
        //
        // LeetCode 54. Spiral Matrix
        //
        //  1  2  3  4
        //  5  6  7  8
        //  9 10 11 12
        // 13 14 15 16
        //
        // => 1, 2, 3, 4, 8, 12, 16, 15, 14, 13, 9, 5, 6, 7, 11, 10
        //
        public static List<int> SpiralOrder(int[][] arr)
        {
            var result = new List<int>();
            int row_size = arr.Length;
            int col_size = arr[0].Length;

            int top = 0;
            int left = 0;
            int right = col_size - 1;
            int bottom = row_size - 1;

            while (result.Count < row_size * col_size)
            {
                // traversal left to right
                for (int c = left; c <= right; c++)
                    result.Add(arr[top][c]);

                // traversal top to bottom
                for (int r = top + 1; r <= bottom; r++)
                    result.Add(arr[r][right]);

                if (top != bottom)
                {
                    // traversal right to left
                    for (int c = right - 1; c >= left; c--)
                        result.Add(arr[bottom][c]);
                }

                if (left != right)
                {
                    // traversal bottom to top
                    for (int r = bottom - 1; r >= top + 1; r--)
                        result.Add(arr[r][left]);
                }

                top++;
                left++;
                right--;
                bottom--;
            }

            return result;
        }

        // 
        // Given a positive integer n, generate an n x n matrix filled with elements from 1 to n2 in spiral order.
        // 
        // Example:
        //
        //   Input: n = 3
        //
        //     1 -> 2 -> 3
        //               |
        //     8 -> 9    4
        //     |         |
        //     7 <- 6 <- 5
        //
        //   Output: [[1, 2, 3],[8, 9, 4],[7, 6, 5]]
        //
        // LeetCode 59. Spiral Matrix II
        //
        public int[][] GenerateMatrix(int n)
        {
            var result = new int[n][];

            for (int i = 0; i < n; i++)
                result[i] = new int[n];

            // row
            int top = 0;
            int bottom = n - 1;

            // column
            int left = 0;
            int right = n - 1;

            int cnt = 1;

            while (cnt <= n * n)
            {
                // traversal left to right
                for (int c = left; c <= right; c++)
                {
                    result[top][c] = cnt++;
                }

                // traversal downwards
                for (int r = top + 1; r <= bottom; r++)
                {
                    result[r][right] = cnt++;
                }

                if (top != bottom)
                {
                    // traversal right to left
                    for (int c = right - 1; c >= left; c--)
                        result[bottom][c] = cnt++;
                }

                if (left != right)
                {
                    // traversal upwards
                    for (int r = bottom - 1; r > top; r--)
                        result[r][left] = cnt++;
                }

                top++;     //  1  2  3  4      1  2  3  4
                left++;    //  5  6  7  8  => 12 13 14  5
                bottom--;  //  9 10 11 12  => 11 16 15  6 
                right--;   // 13 14 15 16     10  9  8  7
            }

            return result;
        }

        //
        // You start at the cell (rStart, cStart) of an rows x cols grid facing east. The northwest corner is at the
        // first row and column in the grid, and the southeast corner is at the last row and column.
        //
        // You will walk in a clockwise spiral shape to visit every position in this grid.Whenever you move
        // outside the grid's boundary, we continue our walk outside the grid (but may return to the grid
        // boundary later.). Eventually, we reach all rows * cols spaces of the grid.
        //
        // Return an array of coordinates representing the positions of the grid in the order you visited them.
        //
        // Example 1:
        //   Input: rows = 1, cols = 4, rStart = 0, cStart = 0
        //   Output: [[0, 0],[0, 1],[0, 2],[0, 3]]
        //
        //   +-----------------+
        //   |  +----------+   |
        //   |  +          +   |
        //   |  | 1 -> 2   3   4
        //   |  +      +   +
        //   |  +--- --+   |
        //   +-------------+
        //
        // Example 2:
        //   Input: rows = 5, cols = 6, rStart = 1, cStart = 4
        //   Output: [[1, 4],[1, 5],[2, 5],[2, 4],[2, 3],[1, 3],[0, 3],[0, 4],[0, 5],[3, 5],[3, 4],
        //           [3, 3],[3, 2],[2, 2],[1, 2],[0, 2],[4, 5],[4, 4],[4, 3],[4, 2],[4, 1],[3, 1],
        //           [2, 1],[1, 1],[0, 1],[4, 0],[3, 0],[2, 0],[1, 0],[0, 0]]
        //
        // LeetCode 885. Spiral Matrix III
        //
        // Highlight:
        //   Define four(4) directions, two loop each step. After each step, update the location based on the pre-defined directions
        //
        // Time complexity:  O(Max(Rows * Cols)^2)
        // Space complexity: O(Rows * Cols)
        //
        public static int[][] SpiralMatrixIII(int rows, int cols, int rStart, int cStart)
        {
            var result = new List<int[]>();
            int n = rows * cols;

            var directions = new int[][]
            {
                [ 0,  1 ], // east
                [ 1,  0 ], // south
                [ 0, -1 ], // west
                [-1,  0 ]  // north
            };

            int dir = 0;
            int step = 1;

            while (result.Count < n)
            {
                for (int i = 0; i < 2; i++)
                {
                    for (int j = 0; j < step; j++)
                    {
                        if (rStart >= 0 && rStart < rows && cStart >= 0 && cStart < cols)
                        {
                            result.Add([rStart, cStart]);
                        }

                        rStart += directions[dir][0];
                        cStart += directions[dir][1];
                    }

                    dir = (dir + 1) % 4;
                }

                step++;
            }

            return result.ToArray();
        }

        // 
        // You are given two integers m and n, which represent the dimensions of a matrix.
        //
        // You are also given the head of a linked list of integers.
        //
        // Generate an m x n matrix that contains the integers in the linked list presented in
        // spiral order (clockwise), starting from the top-left of the matrix. If there are
        // remaining empty spaces, fill them with -1.
        //
        // Return the generated matrix.
        //
        // LeetCode 2326. Spiral Matrix IV
        // 
        // Time complexity: O(M*N)
        // Space complexity: O(1) except the resulting matrix to return
        //
        public static int[][] SpiralMatrixIV(int rows, int cols, ListNode head)
        {
            var matrix = new int[rows][];

            for (int r = 0; r < rows; r++)
                matrix[r] = new int[cols];

            for (int r = 0; r < rows; r++)
                for (int c = 0; c < cols; c++)
                    matrix[r][c] = -1;

            var directions = new int[][]
            {
                [ 0,  1 ],
                [ 1,  0 ],
                [ 0, -1 ],
                [-1,  0 ]
            };

            var current = head;

            int row = 0;
            int col = 0;
            int dir = 0;

            while (current != null)
            {
                matrix[row][col] = current.val;
                current = current.next;

                int nRow = row + directions[dir][0];
                int nCol = col + directions[dir][1];

                if (nRow < 0 || nRow >= rows ||
                    nCol < 0 || nCol >= cols ||
                    matrix[nRow][nCol] != -1)
                {
                    dir = (dir + 1) % 4;
                    nRow = row + directions[dir][0];
                    nCol = col + directions[dir][1];
                }

                (row, col) = (nRow, nCol);
            }

            return matrix;
        }
    }
}
