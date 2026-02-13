using Microsoft.ApplicationInsights;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MatrixOps.src
{
    public class SearchMatrixOps
    {
        //
        // You are given an m x n integer matrix matrix with the following two properties:
        //   Each row is sorted in non-decreasing order.
        //   The first integer of each row is greater than the last integer of the previous row.
        //
        //  Given an integer target, return true if target is in matrix or false otherwise.
        //
        //  You must write a solution in O(log(m* n)) time complexity.
        //
        // Leet Code 74. Search a 2D matrix
        //
        // Time complexity: O(log(M*N);
        // Space complexity: O(1)
        //
        public static bool SearchMatrix(int[][] matrix, int target)
        {
            if (matrix == null || matrix.Length == 0 || matrix[0].Length == 0) return false;

            int m = matrix.Length;
            int n = matrix[0].Length;

            int left = 0;
            int right = m * n - 1;

            while (left <= right)
            {
                int mid = left + (right - left) / 2;
                int curr = matrix[mid / n][mid % n];

                if (curr == target)
                    return true;
                else if (curr < target)
                {
                    left = mid + 1;
                }
                else
                {
                    right = mid - 1;
                }
            }

            return false;
        }
    }
}
