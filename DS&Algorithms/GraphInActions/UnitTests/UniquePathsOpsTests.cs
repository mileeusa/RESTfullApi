using GraphInActions.src;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraphInActions.UnitTests
{
    [TestFixture]
    public class UniquePathsOpsTests
    {
        [Test]
        public void UniquePaths_Test()
        {
            int m = 3, n = 7;
            int expected = 28;

            var result = UniquePathsOps.UniquePaths(m, n);
            Assert.That(result, Is.EqualTo(expected));
        }

        [Test]
        public void UniquePathsII_Test()
        {
            var obstacleGrid = new int[][] {
                [ 0, 0, 0 ],
                [ 0, 1, 0 ],
                [ 0, 0, 0 ]
            };

            var result = UniquePathsOps.UniquePathsWithObstacles(obstacleGrid);

            Assert.That(result, Is.EqualTo(2));
        }
    }
}
