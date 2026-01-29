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
    public class MazeOpsTests
    {
        [Test]
        public void NearestExit_Test()
        {
            var maze = new char[][]
            {
                ['+', '+', '.', '+'],
                ['.', '.', '.', '+'],
                ['+', '+', '+', '.']
            };

            var entrance = new int[] { 1, 2 };

            var steps = MazeOps.NearestExit(maze, entrance);

            Assert.That(steps, Is.EqualTo(1));
        }

        [Test]
        public void NearestExit_Test_2()
        {
            var maze = new char[][]
            {
                ['+', '+', '+'],
                ['.', '.', '.'],
                ['+', '+', '+']
            };

            var entrance = new int[] { 1, 0 };

            var steps = MazeOps.NearestExit(maze, entrance);

            Assert.That(steps, Is.EqualTo(2));
        }
    }
}
