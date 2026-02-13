using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecursiveInActions.src
{
    public class ClimbingStairsOps
    {
        // 
        // You are climbing stairs. You can advance 1 to k steps at the same time. Your destination is
        // exactly n steps up. Write a program which takes as input n and k, return the number of
        // ways in which you can get to your destination.
        //
        // Key idea (DP intuition)
        //
        // Let:
        //   dp[i] = number of ways to reach step i
        //
        // To get to step i, your last jump could have been:
        //   1 step from i-1
        //   2 steps from i-2
        //   ...
        //   k steps from i-k
        //
        // So:
        //   dp[i] = dp[i - 1] + dp[i - 2] + ... + dp[i - k]
        //
        //   with boundary conditions:
        //     dp[0] = 1   // exactly one way to stand still
        //     dp[i] = 0   // for i < 0
        //
        // Time complexity: O(N*K)
        // Space complexity: O(N)
        public static long ClimbStairsWithKSteps_Recursive(int n, int k)
        {
            var memo = new long[n + 1];
            return RecursiveClimb(n, k, memo);
        }

        private static long RecursiveClimb(int n, int k, long[] memo)
        {
            if (n == 0) return 1;

            if (memo[n] != 0)
                return memo[n];

            long ways = 0;
            for (int i = 1; i <= k && n - i > 0; i++)
            {
                ways += RecursiveClimb(n - i, k, memo);
            }

            memo[n] = ways;

            return ways;
        }
    }
}
