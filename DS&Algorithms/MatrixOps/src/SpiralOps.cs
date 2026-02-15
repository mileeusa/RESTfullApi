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

            int up = 0;
            int left = 0;
            int right = col_size - 1;
            int down = row_size - 1;

            while (result.Count < row_size * col_size)
            {
                // traversal left to right
                for (int c = left; c <= right; c++)
                    result.Add(arr[up][c]);

                // traversal up to downwards
                for (int r = up + 1; r <= down; r++)
                    result.Add(arr[r][right]);

                if (up != down)
                {
                    // traversal right to left
                    for (int c = right - 1; c >= left; c--)
                        result.Add(arr[down][c]);
                }

                if (left != right)
                {
                    // traversal upwards to up
                    for (int r = down - 1; r >= up + 1; r--)
                        result.Add(arr[r][left]);
                }

                up++;
                left++;
                right--;
                down--;
            }

            return result;
        }

        // 
        // Given a positive integer n, generate an n x n matrix filled with elements from 1 to n2 in spiral order.
        // 
        // LeetCode 59. Spiral Matrix II
        //
        public int[][] GenerateMatrix(int n)
        {
            var result = new int[n][];

            for (int i = 0; i < n; i++)
                result[i] = new int[n];

            // row
            int up = 0;
            int down = n - 1;

            // column
            int left = 0;
            int right = n - 1;

            int cnt = 1;

            while (cnt <= n * n)
            {
                // traversal left to right
                for (int c = left; c <= right; c++)
                {
                    result[up][c] = cnt++;
                }

                // traversal downwards
                for (int r = up + 1; r <= down; r++)
                {
                    result[r][right] = cnt++;
                }

                if (up != down)
                {
                    // traversal right to left
                    for (int c = right - 1; c >= left; c--)
                        result[down][c] = cnt++;
                }

                if (left != right)
                {
                    // traversal upwards
                    for (int r = down - 1; r > up; r--)
                        result[r][left] = cnt++;
                }

                up++;     //  1  2  3  4
                left++;   //  5  6  7  8
                down--;   //  9 10 11 12
                right--;  // 13 14 15 16
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

            var dir = new int[][]
            {
                [ 0,  1 ], // east
                [ 1,  0 ], // south
                [ 0, -1 ], // west
                [-1,  0 ]  // north
            };

            for (int step = 1, direction = 0; result.Count < n;)
            {
                for (int i = 0; i < 2; i++)
                {
                    for (int j = 0; j < step; j++)
                    {
                        if (rStart >= 0 && rStart < rows && cStart >= 0 && cStart < cols)
                        {
                            result.Add([rStart, cStart]);
                        }

                        rStart += dir[direction][0];
                        cStart += dir[direction][1];
                    }

                    direction = (direction + 1) % 4;
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

                int nextRow = row + directions[dir][0];
                int nextCol = col + directions[dir][1];

                if (nextRow < 0 || nextRow >= rows ||
                    nextCol < 0 || nextCol >= cols ||
                    matrix[nextRow][nextCol] != -1)
                {
                    dir = (dir + 1) % 4;
                    nextRow = row + directions[dir][0];
                    nextCol = col + directions[dir][1];
                }
                row = nextRow;
                col = nextCol;
            }

            return matrix;
        }
    }
}
