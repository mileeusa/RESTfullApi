using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Intrinsics.Arm;
using System.Text;
using System.Threading.Tasks;
using static Microsoft.ApplicationInsights.MetricDimensionNames.TelemetryContext;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace DP
{
    public class ClimbingStairs
    {
        //
        // You are climbing a staircase. It takes n steps to reach the top. Each time you can
        // either climb 1 or 2 steps. In how many distinct ways can you climb to the top?
        //
        // LeetCode 70. Climbing Stairs
        //
        // Difficulty: Easy
        //
        public static int ClimbStairs(int n)
        {
            if (n <= 1)
                return 1;

            int[] dp = new int[n + 1];
            dp[0] = 1; // 1 way to stay at the ground (do nothing)
            dp[1] = 1; // 1 way to reach the first step
            for (int i = 2; i <= n; i++)
            {
                dp[i] = dp[i - 1] + dp[i - 2];
            }
            return dp[n];
        }

        //
        // This is Fibonacci with O(n) time and O(1) space; further optimization would
        // trade clarity for negligible gains
        //
        public static int ClimbStairs_Optimized(int n)
        {
            if (n <= 1)
                return 1;

            int prev1 = 1;
            int prev2 = 1; // ways to climb 0 or 1 step

            for (int i = 2; i <= n; i++)
            {
                int answer = prev1 + prev2;
                prev2 = prev1;
                prev1 = answer;
            }

            return prev1;
        }

        public static int MinCostClimbingStairs(int[] cost)
        {
            int n = cost.Length;
            int[] dp = new int[n];
            dp[0] = cost[0];
            dp[1] = cost[1];

            for (int i = 2; i < n; i++)
            {
                dp[i] = cost[i] + Math.Min(dp[i - 1], dp[i - 2]);
            }

            return Math.Min(dp[n - 1], dp[n - 2]);
        }

        public static int MinCostClimbingStairs_Optimized(int[] cost)
        {
            int a0 = cost[0];
            int a1 = cost[1];

            for (int i = 2; i < cost.Length; i++)
            {
                int c = cost[i] + Math.Min(a1, a0);
                a0 = a1;
                a1 = c;
            }

            return Math.Min(a0, a1);
        }

        // You are climbing a staircase with n + 1 steps, numbered from 0 to n.
        //
        // You are also given a 1-indexed integer array costs of length n, where
        // costs[i] is the cost of step i.
        //
        // From step i, you can jump only to step i + 1, i + 2, or i + 3. The
        // cost of jumping from step i to step j is defined as: costs[j] + (j - i)^2
        //
        // You start from step 0 with cost = 0.
        // Return the minimum total cost to reach step n.
        //
        // LeetCode: 3693 Climbing Stairs II
        //
        // Each step depends only on the previous three states, making it a classic
        // bottom-up DP problem.
        //
        // Since transitions are constant, we can optimize space to O(1).
        //
        public static int ClimbStairs(int n, int[] costs)
        {
            int dp0 = 0;            // cost to reach step 0
            int dp1 = int.MaxValue; // cost to reach step 1
            int dp2 = int.MaxValue; // cost to reach step 2

            for (int i = 1; i <= n; i++)
            {
                int curr = int.MaxValue;

                if (dp0 != int.MaxValue)
                {
                    curr = Math.Min(curr, dp0 + costs[i - 1] + 1 * 1);
                }

                if (dp1 != int.MaxValue)
                {
                    curr = Math.Min(curr, dp1 + costs[i - 1] + 2 * 2);
                }

                if (dp2 != int.MaxValue)
                {
                    curr = Math.Min(curr, dp2 + costs[i - 1] + 3 * 3);
                }

                dp2 = dp1;
                dp1 = dp0;
                dp0 = curr;
            }

            return dp0;
        }

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
        public static long ClimbStairsWithKSteps(int n, int k)
        {
            var dp = new long[n + 1];

            dp[0] = 1;
            for (int i = 1; i <= n; i++)
            {
                for (int step = 1; step <= k && i - step >= 0; step++)
                {
                    dp[i] += dp[i - step];
                }
            }

            return dp[n];
        }

        public static long ClimbStairsWithKSteps_Optimized(int[] stairs, int k)
        {
            int n = stairs.Length;
            var dp = new long[n + 1];
            dp[0] = 1;

            long windowSum = dp[0];

            for (int i = 1; i <= n; ++i)
            {
                dp[i] = windowSum;

                if (i > k)
                    windowSum -= dp[i - k];

                windowSum += dp[i];
            }

            return dp[n];
        }

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
