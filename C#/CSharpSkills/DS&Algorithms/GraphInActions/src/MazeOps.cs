using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace GraphInActions.src
{
    public class MazeOps
    {
        // You are given an m x n matrix maze (0-indexed) with empty
        // cells (represented as '.') and walls (represented as '+').
        // You are also given the entrance of the maze, where
        // entrance = [entrancerow, entrancecol] denotes the
        // row and column of the cell you are initially standing at.
        //
        // In one step, you can move one cell up, down, left, or right.
        // You cannot step into a cell with a wall, and you cannot
        // step outside the maze.Your goal is to find the nearest
        // exit from the entrance.An exit is defined as an empty
        // cell that is at the border of the maze. The entrance does
        // not count as an exit.
        //
        // Return the number of steps in the shortest path from the
        // entrance to the nearest exit, or -1 if no such path exists.

        // LeetCode 1926. Nearest Exit from Entance in Maze
        //
        // Dificult: Medium
        //
        public static int NearestExit(char[][] maze, int[] entrance)
        {
            int m = maze.Length;
            int n = maze[0].Length;

            var q = new Queue<(int row, int col)>();
            q.Enqueue((entrance[0], entrance[1]));

            maze[entrance[0]][entrance[1]] = '+'; // marked as visited

            int steps = 0;
            int[] dr = new int[] { -1, 1, 0, 0 };
            int[] dc = new int[] { 0, 0, -1, 1 };

            while (q.Count > 0)
            {
                int size = q.Count;

                for (int i = 0; i < size; i++)
                {
                    var (row, col) = q.Dequeue();
                    if ((row == 0 || row == m - 1 || col == 0 || col == n - 1) && !(row == entrance[0] && col == entrance[1]))
                        return steps;

                    for (int k = 0; k < 4; k++)
                    {
                        int nr = row + dr[k];
                        int nc = col + dc[k];

                        if (nr >= 0 && nr < m && nc >= 0 && nc < n && maze[nr][nc] == '.')
                        {
                            q.Enqueue((nr, nc));
                            maze[nr][nc] = '+'; // marked as visited
                        }
                    }
                }

                steps++;
            }

            return -1;
        }
    }
}
