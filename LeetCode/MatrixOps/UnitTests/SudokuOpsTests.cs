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
    public class SudokuOpsTests
    {
        [Test]
        public void IsValidSudoku_Test_1()
        {
            var board = new char[][]
            {
                [ '5', '3', '.', '.', '7', '.', '.', '.', '.' ],
                [ '6', '.', '.', '1', '9', '5', '.', '.', '.' ],
                [ '.', '9', '8', '.', '.', '.', '.', '6', '.' ],
                [ '8', '.', '.', '.', '6', '.', '.', '.', '3' ],
                [ '4', '.', '.', '8', '.', '3', '.', '.', '1' ],
                [ '7', '.', '.', '.', '2', '.', '.', '.', '6' ],
                [ '.', '6', '.', '.', '.', '.', '2', '8', '.' ],
                [ '.', '.', '.', '4', '1', '9', '.', '.', '5' ],
                [ '.', '.', '.', '.', '8', '.', '.', '7', '9' ]
            };

            var isValid = SudokuOps.IsValidSudoku(board);

            Assert.That(isValid, Is.True);
        }

        [Test]
        public void IsValidSudoku_Test_2()
        {
            var board = new char[][]
            {
                [ '8','3','.','.','7','.','.','.','.' ],
                [ '6','.','.','1','9','5','.','.','.' ],
                [ '.','9','8','.','.','.','.','6','.' ],
                [ '8','.','.','.','6','.','.','.','3' ],
                [ '4','.','.','8','.','3','.','.','1' ],
                [ '7','.','.','.','2','.','.','.','6' ],
                [ '.','6','.','.','.','.','2','8','.' ],
                [ '.','.','.','4','1','9','.','.','5' ],
                [ '.','.','.','.','8','.','.','7','9' ]
            };

            var isValid = SudokuOps.IsValidSudoku(board);

            Assert.That(isValid, Is.False);
        }
    }
}
