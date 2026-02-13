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
    public class IslandsOpsTests
    {
        [Test]
        public void IslandsOps_Test()
        {
            // arrange
            var grid = new char[][]
            {
                new char[] {'1','1','0','0','0'},
                new char[] {'1','1','0','0','0'},
                new char[] {'0','0','1','0','0'},
                new char[] {'0','0','0','1','1'}
            };

            // act
            var numberOfIslands = IslandsOps.NumIslands(grid);

            // assert
            Assert.That(numberOfIslands, Is.EqualTo(3));
        }
    }
}
