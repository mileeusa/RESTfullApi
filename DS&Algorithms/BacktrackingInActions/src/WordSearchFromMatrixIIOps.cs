using Microsoft.Testing.Platform.Extensions.Messages;
using System;
using System.Collections.Generic;
using System.Text;
using static Microsoft.ApplicationInsights.MetricDimensionNames.TelemetryContext;

namespace BacktrackingInActions.src
{
    public class TrieNode
    {
        public TrieNode[] Children = new TrieNode[26];
        public string? Word;

        public TrieNode() 
        {
            Word = null;
        }
    }

    public class WordSearchFromMatrixIIOps
    {
        static readonly int[] dr = [ -1, 1, 0, 0 ];
        static readonly int[] dc = [ 0, 0, -1, 1 ];

        //
        // Given an m x n board of characters and a list of strings words, return
        // all words on the board.
        //
        // Each word must be constructed from letters of sequentially adjacent
        // cells, where adjacent cells are horizontally or vertically
        // neighboring.The same letter cell may not be used more
        // than once in a word.
        //
        // LeetCode 212. Word Search II
        //
        // Time complexity:  
        // Space complexity: 
        //
        // Difficulty: Medium
        //
        public static IList<string> FindWords(char[][] board, string[] words)
        {
            List<string> result = new List<string>();
            int m = board.Length;
            int n = board[0].Length;

            // step 1. construct the Trie
            TrieNode root = new TrieNode();
            foreach (var word in words)
            {
                var node = root;
                foreach (var ch in word)
                {
                    int idx = ch - 'a';
                    if (node.Children[idx] == null)
                    {
                        node.Children[idx] = new TrieNode();
                    }
                    node = node.Children[idx];
                }
                node.Word = word;
            }

            // step 2. backtracking starting for each cell in the board
            for (int row = 0; row < m; row++) 
            {
                for (int col = 0; col < n; col++)
                {
                    if (root.Children[board[row][col] - 'a'] != null)
                    {
                        Backtrack(board, root, row, col, result);
                    }
                }
            }

            return result;
        }

        private static void Backtrack(char[][] board, TrieNode parent, int row, int col, List<string> result)
        {
            var ch = board[row][col];
            var currNode = parent.Children[ch - 'a'];

            if (currNode.Word != null)
            {
                // match
                result.Add(currNode.Word);
                currNode.Word = null; // de-duplicate
            }

            board[row][col] = '#';

            // check neighbors
            int m = board.Length;
            int n = board[0].Length;

            for (int i = 0; i < 4; i++)
            {
                int newRow = row + dr[i];
                int newCol = col + dc[i];

                if (newRow < 0 || newRow >= m || newCol < 0 || newCol >= n)
                    continue;

                int newChar = board[newRow][newCol];
                if (newChar != '#' && currNode.Children[newChar - 'a'] != null)
                {
                    Backtrack(board, currNode, newRow, newCol, result);
                }
            }

            board[row][col] = ch; // restore
        }
    }
}
