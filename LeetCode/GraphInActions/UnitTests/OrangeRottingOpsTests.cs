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
    public class OrangeRottingOpsTests
    {
        [Test]
        public void OrangeRotting_Test_One()
        {
            // arrange
            int[][] grid = new int[][]
            {
                new int[] {2,1,1},
                new int[] {1,1,0},
                new int[] {0,1,1}
            };
            // act
            int result = OrangeRottingOps.OrangeRotting(grid);

            // assert
            Assert.That(result, Is.EqualTo(4));
        }

        [Test]
        public void OrangeRotting_Test_Two()
        {
            // arrange
            int[][] grid = new int[][]
            {
                [2, 1, 1],
                [0, 1, 1],
                [1, 0, 1]
            };

            // act
            int result = OrangeRottingOps.OrangeRotting(grid);

            // assert
            Assert.That(result, Is.EqualTo(-1));
        }
    }
}
