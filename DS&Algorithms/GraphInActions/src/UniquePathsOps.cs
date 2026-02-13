using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace GraphInActions.src
{
    public class UniquePathsOps
    {
        //
        // A robot is located at the top-left corner of a m x n grid (marked 'Start' in the diagram below).
        // The robot can only move either down or right at any point in time. The robot is trying to
        // reach the bottom-right corner of the grid (marked 'Finish' in the diagram below).
        // How many possible unique paths are there?
        //
        // LeetCode 62. Unique Paths
        //
        // Time complexity: O(M*N)
        // Space complexity: O(N)
        //
        // Dificulty: Medium
        //
        public static int UniquePaths(int m, int n)
        {
            if (m == 1 || n == 1) return 1;

            var dp = new int[m, n];

            for (int i = 0; i < m; i++)
                dp[i, 0] = 1;

            for (int j = 0; j < n; j++)
                dp[0, j] = 1;

            for (int i = 1; i < m; i++)
                for (int j = 1; j < n; j++)
                    dp[i, j] = dp[i - 1, j] + dp[i, j - 1];

            return dp[m - 1, n - 1];
        }

        // 
        // You are given an m x n integer array grid. There is a robot initially located at
        // the top-left corner (i.e., grid[0][0]). The robot tries to move to the
        // bottom-right corner (i.e., grid[m - 1][n - 1]). The robot can only
        // move either down or right at any point in time.
        //
        // An obstacle and space are marked as 1 or 0 respectively in grid.A path that
        // the robot takes cannot include any square that is an obstacle.
        //
        // Return the number of possible unique paths that the robot can take to
        // reach the bottom-right corner.
        //
        // The testcases are generated so that the answer will be less than or equal to 2 * 109.
        //
        // LeetCode 63. Unique Paths II
        //
        // Time complexity: O(M*N)
        // Space complexity: O(1)
        //
        // Dificulty: Medium
        //
        public static int UniquePathsWithObstacles(int[][] obstacleGrid)
        {
            int m = obstacleGrid.Length;
            int n = obstacleGrid[0].Length;

            if (obstacleGrid[0][0] == 1)
                return 0;

            obstacleGrid[0][0] = 1;
            for (int row = 1; row < m; row++)
                obstacleGrid[row][0] = (obstacleGrid[row][0] == 0 && obstacleGrid[row - 1][0] == 1) ? 1 : 0;

            for(int col = 1; col < n; col++)
                obstacleGrid[0][col] = (obstacleGrid[0][col] == 0 && obstacleGrid[0][col - 1] == 1) ? 1 : 0;

            for (int row = 1; row < m; row++)
                for (int col = 1; col < n; col++)
                    obstacleGrid[row][col] = (obstacleGrid[row][col] == 0) ? obstacleGrid[row - 1][col] + obstacleGrid[row][col - 1] : 0;

            return obstacleGrid[m - 1][n - 1];
        }
    }
}
