using System;
using System.Collections.Generic;
using System.Text;
using static Microsoft.ApplicationInsights.MetricDimensionNames.TelemetryContext;

namespace BacktrackingInActions.src
{
    public class MatrixLookupOps
    {
        //
        // Given an m x n grid of characters board and a string word, return
        // true if word exists in the grid.
        //
        // The word can be constructed from letters of sequentially adjacent cells,
        // where adjacent cells are horizontally or vertically neighboring.
        // The same letter cell may not be used more than once.
        //
        // LeetCode 79. Word Search
        //
        public static bool Exist(char[][] board, string word)
        {
            int rows = board.Length;
            int cols = board[0].Length;

            for (int r = 0; r < rows; r++)
            {
                for (int c = 0; c < cols; c++)
                {
                    if (DFS(board, r, c, word, 0))
                    {
                        return true; 
                    }
                }
            }
            return false;
        }

        private static bool DFS(char[][] board, int row, int col, string word, int index)
        {
            if (index == word.Length)
                return true;

            int rows = board.Length;
            int cols = board[0].Length;

            var dr = new int[] { 1, -1, 0, 0 };
            var dc = new int[] { 0, 0, 1, -1 };

            if (row < 0 || row >= rows || col < 0 || col >= cols || board[row][col] != word[index])
            {
                return false; 
            }

            char tmp = board[row][col];
            board[row][col] = ' ';
            
            for (int k = 0; k < 4; k++)
            {
                if (DFS(board, row + dr[k], col + dc[k], word, index + 1))
                    return true;
            }

            board[row][col] = tmp;
            return false;
        }
    }
}
