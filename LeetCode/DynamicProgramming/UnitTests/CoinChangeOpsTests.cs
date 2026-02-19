using DP;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DynamicProgrammingInActions.UnitTests
{
    [TestFixture] class CoinChangeOpsTests
    {
        [TestCase( new int[] { 1, 2, 5 }, 11, 3)]
        [TestCase( new int[] { 1, 2, 5 },  7, 2)]
        [TestCase( new int[] { 1, 2, 5 },  3, 2)]
        [TestCase( new int[] { 1, 2, 5 },  4, 2)]
        [TestCase( new int[] { 1, 2, 5 }, 15, 3)]
        [TestCase( new int[] { 1, 2, 5 }, 23, 6)]
        public void CoinChange_Test(int[] coins, int amount, int expectedCoins)
        {
            // arrange

            // act
            int result = CoinChangeOps.CoinChange(coins, amount);

            // assert
            Assert.That(result, Is.EqualTo(expectedCoins));
        }
    }
}
