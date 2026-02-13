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
    public class BFSOpsTests
    {
        [Test]
        public void MinReorder_Test_One()
        {
            // arrange
            int n = 6;
            int[][] connections = new int[][]
            {
                new int[] {0,1},
                new int[] {1,3},
                new int[] {2,3},
                new int[] {4,0},
                new int[] {4,5}
            };

            // act
            int result = BFSOps.MinReorder(n, connections);

            // assert
            Assert.That(result, Is.EqualTo(3));
        }
    }
}
