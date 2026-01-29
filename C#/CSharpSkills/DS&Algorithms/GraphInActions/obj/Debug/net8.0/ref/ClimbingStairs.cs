using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IntegerOps
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

        public static int MinCostClimbingStairs(int[] cost)
        {
            int n = cost.Length;
            int[] dp = new int[n];
            dp[0] = cost[0];
            dp[1] = cost[1];

            for(int i = 2; i < n; i++)
            {
                dp[i] = cost[i] + Math.Min(dp[n-1], dp[n-2]);
            }

            return Math.Min(dp[n - 1], dp[n - 2]);
        }

        public static void ClimbStairs_Test()
        {
            int n = 5;
            Console.WriteLine();
            Console.WriteLine("ClimbingStairs.ClimbStairs");
            Console.WriteLine($"Number of ways to climb {n} stairs: {ClimbStairs(n)}");
        }

        public static void MinCostClimbingStairs_Test()
        {
            int[] cost = { 10, 15, 20 };
            Console.WriteLine();
            Console.WriteLine("ClimbingStairs.MinCostClimbingStairs");
            Console.WriteLine($"Minimum cost to climb stairs with costs [{string.Join(", ", cost)}]: {MinCostClimbingStairs(cost)}");
        }
    }
}
