using Microsoft.VisualStudio.TestPlatform.Utilities;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;
using static Microsoft.ApplicationInsights.MetricDimensionNames.TelemetryContext;
using static System.Net.Mime.MediaTypeNames;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace ArrayInActions.src
{
    public class StockTradeOps
    {
        // 
        // You are given an array prices where prices[i] is the price of a given stock on the ith day.
        //
        // You want to maximize your profit by choosing a single day to buy one stock and choosing
        // a different day in the future to sell that stock.
        //
        // Return the maximum profit you can achieve from this transaction.If you cannot achieve
        // any profit, return 0.
        //
        // *********************************************************************
        //  you are limited to one traction!!! so you have to find the lowest
        //  price to buy, and find the high price to sell!!!
        // *********************************************************************
        //
        // Example 1:
        //   Input: prices = [7, 1, 5, 3, 6, 4]
        //   Output: 5
        //   Explanation: Buy on day 2 (price = 1) and sell on day 5 (price = 6), profit = 6-1 = 5.
        //
        // Note that buying on day 2 and selling on day 1 is not allowed because you
        // must buy before you sell.
        //
        // Example 2:
        //   Input: prices = [7, 6, 4, 3, 1]
        //   Output: 0
        //   Explanation: In this case, no transactions are done and the max profit = 0.
        //
        // LeetCode 121. Best Time to Buy and Sell Stock
        //
        // Difficulty: Easy
        //
        // Time complexity:  O(N)
        // Space complexity: O(1)
        //
        public int MaxProfit_121(int[] prices)
        {
            int largestProfit = 0;
            int minSoFar = int.MaxValue;

            for (int i = 0; i < prices.Length; i++)
            {
                if (prices[i] < minSoFar)
                {
                    minSoFar = prices[i];
                }
                else
                {
                    largestProfit = Math.Max(largestProfit, prices[i] - minSoFar);
                }
            }

            return largestProfit;
        }

        // 
        // You are given an integer array prices where prices[i] is the price of a
        // given stock on the ith day.
        //
        // On each day, you may decide to buy and/or sell the stock.You can only
        // hold at most one share of the stock at any time.However, you can
        // sell and buy the stock multiple times on the same day, ensuring you
        // never hold more than one share of the stock.
        //
        // *******************************************************************
        //  In other words, there're no limits on the numbers of transactions
        //  so you can trader one by one to catch all the profit
        // *******************************************************************
        //
        // Find and return the maximum profit you can achieve.
        //
        // LeetCode 122. Best Time to Buy and Sell Stock II
        //
        // Time complexity:  O(N)
        // Space complexity: O(1)
        //
        public static int MaxProfit_122(int[] prices)
        {
            int profit = 0;
            for (int i = 1; i < prices.Length; i++)
                if (prices[i] > prices[i-1])
                    profit += prices[i] - prices[i-1];

            return profit;
        }

        // 
        // You are given an array prices where prices[i] is the price of a given stock on the ith day.
        //
        // Find the maximum profit you can achieve.You may complete at most two transactions.
        //
        // Note: You may not engage in multiple transactions simultaneously(i.e., you must
        // sell the stock before you buy again).
        //
        // *******************************************************************
        //  Here you are allowed to have at most two transactions!!!
        // *******************************************************************
        //
        // Example 1:
        //   Input: prices = [3, 3, 5, 0, 0, 3, 1, 4]
        //   Output: 6
        //   Explanation: Buy on day 4 (price = 0) and sell on day 6 (price = 3), profit = 3-0 = 3.
        //   Then buy on day 7 (price = 1) and sell on day 8 (price = 4), profit = 4-1 = 3.
        //
        // Example 2:
        //   Input: prices = [1, 2, 3, 4, 5]
        //   Output: 4
        //   Explanation: Buy on day 1 (price = 1) and sell on day 5 (price = 5), profit = 5-1 = 4.
        //   Note that you cannot buy on day 1, buy on day 2 and sell them later, as you are
        //   engaging multiple transactions at the same time.You must sell before buying again.
        //
        // Example 3:
        //   Input: prices = [7, 6, 4, 3, 1]
        //   Output: 0
        //   Explanation: In this case, no transaction is done, i.e.max profit = 0.
        //
        // 123. Best Time to Buy and Sell Stock III
        //
        //
        // Difficulty: Hard
        //
        public static int MaxProfit_123(int[] prices)
        {
            int cost1 = int.MaxValue;
            int cost2 = int.MaxValue;
            int profit1 = 0;
            int profit2 = 0;

            foreach (int price in prices)
            {
                cost1   = Math.Min(cost1,   price);
                profit1 = Math.Max(profit1, price - cost1  );
                cost2   = Math.Min(cost2,   price - profit1);
                profit2 = Math.Max(profit2, price - cost2  );
            }

            return profit2;
        }

        //
        // You are given an integer array prices where prices[i] is the price of a given
        // stock on the ith day, and an integer k.
        //
        // Find the maximum profit you can achieve.You may complete
        // at most k transactions: i.e.you may buy at most k times and sell at most k times.
        //
        // Note: You may not engage in multiple transactions simultaneously, i.e., you
        // must sell the stock before you buy again.
        //
        // LeetCode 188. Best Time to Buy and Sell Stock IV
        //
        //
        public static int MaxProfit_188(int[] prices, int k)
        {
            if (k <= 0) return 0;

            int[] cost = new int[k+1];
            int[] profit = new int[k+1];

            profit[0] = 0;
            Array.Fill(cost, int.MaxValue);

            foreach (int price in prices)
            {
                for (int i = 0; i < k; i++)
                {
                    cost[i + 1] = Math.Min(cost[i + 1], price - profit[i]);
                    profit[i + 1] = Math.Max(profit[i + 1], price - cost[i + 1]);
                }
            }

            return profit[k];
        }



        //
        // You are given an array prices where prices[i] is the price of a given stock on the ith day.
        //
        // Find the maximum profit you can achieve.You may complete as many transactions as you
        // like (i.e., buy one and sell one share of the stock multiple times) with the
        // following restrictions:
        //
        // After you sell your stock, you cannot buy stock on the next day(i.e., cooldown one day).
        //
        // Note: You may not engage in multiple transactions simultaneously(i.e., you must sell
        // the stock before you buy again).
        //
        // Example 1:
        //   Input: prices = [1, 2, 3, 0, 2]
        //   Output: 3
        //   Explanation: transactions = [buy, sell, cooldown, buy, sell]
        //
        // LeetCode 309. Best Time to Buy and Sell Stock with Cooldown
        //
        //
        // In this algorithm, we introduce three states:
        //    hold:
        //       - you currently own a stock
        //       - you either bought it earlier or bought today (from rest)
        //    sold:
        //       - you sold a stock today
        //       - this is the action that causes colldown
        //       - On the next day, you are not allowed to buy (cooldown day)
        //    rest:
        //       - you do't own stock
        //       - you didn't sell today
        //       - This includes:
        //            * normal day
        //            * the cooldown day after a sale
        //       ==>
        //       rest = max(prevRest, prevSold)
        //
        public static int MaxProfit_309(int[] prices)
        {
            if (prices == null || prices.Length == 0) return 0;

            int hold = -prices[0];
            int sold = 0;
            int rest = 0;

            for (int i = 1; i < prices.Length; i++)
            {
                int prevHold = hold;
                int prevSold = sold;
                int prevRest = rest;

                hold = Math.Max(prevHold, prevRest - prices[i]);
                sold = prevHold + prices[i];
                rest = Math.Max(prevRest, prevSold);
            }

            return Math.Max(sold, rest);;
        }
    }
}
