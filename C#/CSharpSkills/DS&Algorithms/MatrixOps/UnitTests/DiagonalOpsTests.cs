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
    public class DiagonalOpsTests
    {
        [Test]
        public void FindDiagonalOrder_Test()
        {
            var mat = new int[][]
            {
                [1, 2, 3],
                [4, 5, 6],
                [7, 8, 9]
            };

            var result = DiagonalOps.FindDiagonalOrder(mat);

            Assert.That(result.Count, Is.EqualTo(9));
        }
    }
}
