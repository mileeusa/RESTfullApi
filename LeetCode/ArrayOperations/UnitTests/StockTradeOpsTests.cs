using ArrayInActions.src;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArrayInActions.UnitTests
{
    [TestFixture]
    public class StockTradeOpsTests
    {
        [TestCase(new int[] { 7, 1, 5, 3, 6, 4 }, 7)]
        [TestCase(new int[] { 1, 2, 3, 4, 5 }, 4)]
        [TestCase(new int[] { 7, 6, 4, 3, 1 }, 0)]
        public void MaxProfit_121_Test(int[] prices, int expectedProfit)
        {
            var profit = StockTradeOps.MaxProfit_122(prices);

            Assert.That(profit, Is.EqualTo(expectedProfit));
        }

        [TestCase (new int[] { 7, 1, 5, 3, 6, 4 }, 7)]
        [TestCase (new int[] { 1, 2, 3, 4, 5 }, 4)]
        [TestCase (new int[] { 7, 6, 4, 3, 1 }, 0)]
        public void MaxProfit_122_Test(int[] prices, int expectedProfit)
        {
            var profit = StockTradeOps.MaxProfit_122(prices);

            Assert.That(profit, Is.EqualTo(expectedProfit));
        }

        [TestCase(new int[] { 3, 3, 5, 0, 0, 3, 1, 4 }, 6)]
        [TestCase(new int[] { 1, 2, 3, 4, 5 }, 4)]
        [TestCase(new int[] { 7, 6, 4, 3, 1 }, 0)]
        public void MaxProfit_123_Test(int[] prices, int expectedProfit)
        {
            var profit = StockTradeOps.MaxProfit_123(prices);

            Assert.That(profit, Is.EqualTo(expectedProfit));
        }

        [TestCase(new int[] { 1, 2, 3, 0, 2 }, 3)]
        [TestCase(new int[] { 1 }, 0)]
        public void MaxProfit_309_Test(int[] prices, int expectedProfit)
        {
            var profit = StockTradeOps.MaxProfit_309(prices);

            Assert.That(profit, Is.EqualTo(expectedProfit));
        }

        [TestCase(new int[] { 2, 4, 1 }, 2, 2)]
        [TestCase(new int[] { 3, 2, 6, 5, 0, 3 }, 2, 7)]
        public void MaxProfit_188_Test(int[] prices, int k, int expectedProfit)
        {
            var profit = StockTradeOps.MaxProfit_188(prices, k);

            Assert.That(profit, Is.EqualTo(expectedProfit));
        }
    }
}
