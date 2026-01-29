using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MatrixOps.src
{
    public class SudokuOps
    {
        // 
        // Determine if a 9 x 9 Sudoku board is valid. Only the filled cells need to
        // be validated according to the following rules:
        //   1. Each row must contain the digits 1-9 without repetition.
        //   2. Each column must contain the digits 1-9 without repetition.
        //   3. Each of the nine 3 x 3 sub-boxes of the grid must contain the digits 1-9 without repetition.
        //
        // Note:
        //   A Sudoku board (partially filled) could be valid but is not necessarily solvable.
        //   Only the filled cells need to be validated according to the mentioned rules.
        //
        // LeetCode 36: Valid Sudoku
        //
        public static bool IsValidSudoku(char[][] board)
        {
            int N = 9;

            var rowSet = new HashSet<char>[N];
            var colSet = new HashSet<char>[N];
            var boxSet = new HashSet<char>[N];

            for (int i = 0; i < N; i++)
            {
                rowSet[i] = new HashSet<char>();
                colSet[i] = new HashSet<char>();
                boxSet[i] = new HashSet<char>();
            }

            for (int row = 0; row < N; row++)
            {
                for (int col = 0; col < N; col++)
                {
                    char val = board[row][col];

                    if (val == '.')
                        continue;

                    // check row
                    if (rowSet[row].Contains(val))
                        return false;

                    rowSet[row].Add(val);

                    // check col
                    if (colSet[col].Contains(val))
                        return false;

                    colSet[col].Add(val);

                    // check box
                    int idx = (row / 3) * 3 + (col / 3);
                    if (boxSet[idx].Contains(val))
                        return false;

                    boxSet[idx].Add(val);
                }
            }

            return true;
        }
    }
}
