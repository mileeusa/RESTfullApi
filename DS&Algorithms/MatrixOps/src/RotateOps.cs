using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MatrixOps
{
    public class RotateOps
    {
        public static void RotateMatrix(int[][] matrix)
        {
            int n = matrix.GetLength(0);

            // transpose the matrix (swap rows with columns)
            for (int i = 0; i < n; i++)
            {
                for (int j = i; j < n; j++)
                {
                    (matrix[i][j], matrix[j][i]) = (matrix[j][i], matrix[i][j]);
                }
            }

            // reverse each row to get the final rotated matrix
            for (int i = 0; i < n; i++)
            {
                Array.Reverse(matrix[i]);
            }
        }
    }
}
