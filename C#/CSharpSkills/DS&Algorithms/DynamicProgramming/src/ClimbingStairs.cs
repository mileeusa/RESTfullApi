using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace DP
{
    public class ClimbingStairs
    {
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

            for(int i = 2; i < n; i++)
            {
                dp[i] = cost[i] + Math.Min(dp[i-1], dp[i-2]);
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
    }
}
