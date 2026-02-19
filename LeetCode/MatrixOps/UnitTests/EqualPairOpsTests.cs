using MatrixOps.src;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MatrixOps.UnitTests
{
    [TestFixture]
    public class EqualPairOpsTests
    {
        [Test]
        public void EqualPairs_Test()
        {
            // arrange
            int[][] matrixA = new int[][]
            {
                [3, 2, 1], //new int[] {3, 2, 1},
                [1, 7, 6], //new int[] {1, 7, 6},
                [2, 7, 7]  //new int[] {2, 7, 7}
            };

            Console.WriteLine();
            Console.WriteLine("EqualPairOps.EqualPairs:");

            // act
            int cnt = EqualPairOps.EqualPairs(matrixA);

            // assert
            Assert.That(cnt, Is.EqualTo(1));
        }

        [Test]
        public void EqualPairs_Custom_Comparer_Test()
        {
            // arrange
            int[][] matrixA = new int[][]
            {
                [3, 2, 1], //new int[] {3, 2, 1},
                [1, 7, 6], //new int[] {1, 7, 6},
                [2, 7, 7]  //new int[] {2, 7, 7}
            };

            Console.WriteLine();
            Console.WriteLine("EqualPairOps.EqualPairs_Custom_Comparer:");

            // act
            int cnt = EqualPairOps.EqualPairs_Custom_Comparer(matrixA);

            // assert
            Assert.That(cnt, Is.EqualTo(1));
        }
    }
}
