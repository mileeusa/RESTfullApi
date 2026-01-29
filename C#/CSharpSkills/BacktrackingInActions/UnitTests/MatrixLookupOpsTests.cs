using BacktrackingInActions.src;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace BacktrackingInActions.UnitTests
{
    [TestFixture]
    public class MatrixLookupOpsTests
    {
        [Test]
        public void Exist_Test_One()
        {
            var board = new char[][]
            {
                ['A', 'B', 'C', 'E'],
                ['S', 'F', 'C', 'S'],
                ['A', 'D', 'E', 'E']
            };
            string word = "ABCCED";

            var result = MatrixLookupOps.Exist(board, word);

            Assert.That(result, Is.True);
        }

        [Test]
        public void Exist_Test_Two()
        {
            var board = new char[][]
            {
                ['A', 'B', 'C', 'E'],
                ['S', 'F', 'C', 'S'],
                ['A', 'D', 'E', 'E']
            };
            string word = "ABCB";

            var result = MatrixLookupOps.Exist(board, word);

            Assert.That(result, Is.False);
        }
    }
}
