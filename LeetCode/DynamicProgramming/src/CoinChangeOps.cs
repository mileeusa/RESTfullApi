using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace DP
{
    public class CoinChangeOps
    {
        //
        // You are given an integer array coins representing coins of different
        // denominations and an integer amount representing a total
        // amount of money.
        //
        // Return the fewest number of coins that you need to make up that
        // amount. If that amount of money cannot be made up by any
        // combination of the coins, return -1.
        //
        // You may assume that you have an infinite number of each kind of coin.
        //
        //
        // LeetCode 322: Coin Change
        //
        // Time complexity:  O(n * m), where n is the amount and m is the number of coins
        // Space complexity: O(n)
        //
        public static int CoinChange(int[] coins, int amount)
        {
            //
            // dp[i] = x -- when the coint amount target is i, the minimum x coins are needed
            //
            int[] dp = new int[amount + 1];

            for (int i = 1; i <= amount; i++)
            {
                dp[i] = amount + 1;
            }

            // base case
            dp[0] = 0;

            // Build up the DP array
            for (int currentA = 0; currentA <= amount; currentA++)
            {
                foreach (var coin in coins)
                {
                    if (currentA >= coin)
                    {
                        dp[currentA] = Math.Min(dp[currentA], dp[currentA - coin] + 1);
                    }
                }
            }

            // If dp[amount] was not updated, it means it's impossible to make change
            return (dp[amount] > amount) ? -1 : dp[amount];
        }
    }
}
