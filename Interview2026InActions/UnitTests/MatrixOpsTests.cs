using Interview2026InActions.src;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interview2026InActions.UnitTests
{
    [TestFixture]
    public class MatrixOpsTests
    {
        [Test]
        public void SpiralMatrix_Test()
        {
            var grid = new int[][]
            {
                [ 1,  2,  3,  4],
                [ 5,  6,  7,  8],
                [ 9, 10, 11, 12],
                [13, 14, 15, 16]
            };

            var result = MatrixOps.SpiralMatrix(grid);

            Assert.That(result, Is.Not.Null);
            Assert.That(result.Count, Is.EqualTo(16));
            Assert.That(result[4], Is.EqualTo(8));
            Assert.That(result[7], Is.EqualTo(15));
        }
    }
}
