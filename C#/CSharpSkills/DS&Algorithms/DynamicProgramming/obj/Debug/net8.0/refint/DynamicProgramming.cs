using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DP
{
    public static class DynamicProgramming
    {
        public static int coinChange(int[] coins, int amount)
        {
            //
            // dp[i] = x -- when the coint amount target is i, the minimum x coins are needed
            //
            int[] dp = new int[amount + 1];

            for (int i = 1; i <= amount; i++)
            {
                dp[i] = amount + 1;
            }

            for (int currAmount = 0; currAmount <= amount; currAmount++)
            {
                foreach (var coin in coins)
                {
                    if (coin <= currAmount)
                    {
                        dp[currAmount] = Math.Min(dp[currAmount], dp[currAmount - coin] + 1);
                    }
                }
            }
            return (dp[amount] > amount) ? -1 : dp[amount];
        }
    }
}
