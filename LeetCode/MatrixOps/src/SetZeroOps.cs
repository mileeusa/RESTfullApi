using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MatrixOps
{
    public class SetZeroOps
    {
        // Given an m x n integer matrix, if an element is 0, set its entire row and column to 0's.
        // You must do it in place.
        //
        // LeetCode: 73. Set Matrix Zeroes
        //
        // Time complexity: O(M * N)
        // Space complexity: O(1)
        //
        // Difficulty: Medium
        //
        public static void SetZeroes(int[][] matrix)
        {
            int m = matrix.Length;
            int n = matrix[0].Length;

            // the first row and column act as markers
            bool firstRowZero = false;
            bool firstColZero = false;

            // check first row has a zero
            for (int i = 0; i < n; i++)
            {
                if (matrix[0][i] == 0)
                {
                    firstColZero = true;
                    break;
                }
            }

            // check first column has a zero
            for (int i = 0; i < m; i++)
            {
                if (matrix[i][0] == 0)
                {
                    firstRowZero = true;
                    break;
                }
            }

            // use first row and column as marker
            for (int i = 1; i < m; i++)
            {
                for (int j = 1; j < n; j++)
                {
                    if (matrix[i][j] == 0)
                    {
                        matrix[i][0] = 0; // mark the row
                        matrix[0][j] = 0; // mark the column
                    }
                }
            }

            // zero out cells based on markers
            for (int i = 1; i < m; i++)
            {
                for (int j = 1; j < n; j++)
                {
                    if (matrix[i][0] == 0 || matrix[0][j] == 0)
                    {
                        matrix[i][j] = 0;
                    }
                }
            }

            // handle the first row
            if (firstRowZero)
            {
                for (int i = 0; i < m; i++)
                {
                    matrix[i][0] = 0;
                }
            }

            // handle the fist column
            if (firstColZero)
            {
                for (int i = 0; i < n; i++)
                {
                    matrix[0][i] = 0;
                }
            }
        }


        public static void SetZeroes_Test()
        {
            int[][] matrix = new int[][]
            {
                new int[] { 1, 1, 1 },
                new int[] { 1, 0, 1 },
                new int[] { 1, 1, 1 }
            };
            Console.WriteLine();
            Console.WriteLine("Original Matrix:");
            PrintMatrix(matrix);
            SetZeroes(matrix);
            Console.WriteLine("Matrix after SetZeroes:");
            PrintMatrix(matrix);
        }

        private static void PrintMatrix(int[][] matrix)
        {
            int m = matrix.Length;
            int n = matrix[0].Length;
            for (int i = 0; i < m; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    Console.Write(matrix[i][j] + " ");
                }
                Console.WriteLine();
            }
        }
    }
}
