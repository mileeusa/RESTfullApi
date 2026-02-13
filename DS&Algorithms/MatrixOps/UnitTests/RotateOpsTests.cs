using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MatrixOps.UnitTests
{
    [TestFixture] class RotateOpsTests
    {
        [Test]
        public void RotateMatrix_Test()
        {
            int[][] matrix = new int[][]
            {
                [1, 2, 3], //new int[] { 1, 2, 3 },
                [4, 5, 6], //new int[] { 4, 5, 6 },
                [7, 8, 9]  //new int[] { 7, 8, 9 }
            };

            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine("Original Matrix:");
            PrintMatrix(matrix);
            RotateOps.RotateMatrix(matrix);

            Console.WriteLine("Rotated Matrix:");
            PrintMatrix(matrix);

            Assert.That(matrix[0], Is.EqualTo([7, 4, 1]));
            Assert.That(matrix[1], Is.EqualTo([8, 5, 2]));
            Assert.That(matrix[2], Is.EqualTo([9, 6, 3]));
        }

        private void PrintMatrix(int[][] matrix)
        {
            int n = matrix.GetLength(0);
            for (int i = 0; i < n; i++)
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
