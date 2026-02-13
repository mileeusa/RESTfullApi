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
    public class SearchMatrixOpsTests
    {
        [Test]
        public void SearchMatrix_Test()
        {
            var matrix = new int[][]
            {
                [1,   3,  5,  7],
                [10, 11, 16, 20],
                [23, 30, 34, 60],
            };

            bool found = SearchMatrixOps.SearchMatrix(matrix, 11);

            // assert
            Assert.That(found, Is.True);
        }
    }
}
