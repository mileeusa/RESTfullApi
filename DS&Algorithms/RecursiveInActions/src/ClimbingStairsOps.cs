using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Intrinsics.X86;
using System.Text;
using System.Threading.Tasks;
using static Microsoft.ApplicationInsights.MetricDimensionNames.TelemetryContext;
using static System.Runtime.InteropServices.JavaScript.JSType;

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

        //
        // You are given a non-negative integer k. There exists a staircase with an infinite number of stairs, with the
        // lowest stair numbered 0.
        //
        // Alice has an integer jump, with an initial value of 0. She starts on stair 1 and wants to reach stair k
        // using any number of operations.If she is on stair i, in one operation she can:
        //   Go down to stair i - 1.This operation cannot be used consecutively or on stair 0.
        //   Go up to stair i + 2jump.And then, jump becomes jump + 1.
        //
        // Return the total number of ways Alice can reach stair k.
        //
        // Note that it is possible that Alice reaches the stair k, and performs some operations to reach the stair k again.
        //
        // LeetCode 3154. Find Number of Ways to Reach the K-th Stair
        //
        // Difficulty: Hard
        //
        public static int WaysToReachStair(int k)
        {
            var memo = new Dictionary<(long, int, bool), long>();
            return (int)dfs(1, 0, true, k, memo);
        }

        private static long dfs(long i, int jump, bool canDown, int k, Dictionary<(long, int, bool), long> memo)
        {
            if (jump >= 63) return 0;

            // tight pruning
            if (i > k + jump + 1) return 0;

            var key = (i, jump, canDown);

            if (memo.TryGetValue(key, out var val)) 
                return val;

            long ways = (i == k) ? 1 : 0;

            // jump
            ways += dfs(i + (1L << jump), jump + 1, true, k, memo);

            // down
            if (i > 0 && canDown)
                ways += dfs(i - 1, jump, false, k, memo);

            memo[key] = ways;

            return ways;
        }
    }
}
