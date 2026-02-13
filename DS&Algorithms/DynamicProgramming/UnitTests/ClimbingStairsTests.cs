using DP;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DynamicProgrammingInActions.UnitTests
{
    [TestFixture]
    public class ClimbingStairsTests
    {
        [TestCase(5, 8)]
        public void ClimbStairs_Test(int n, int expected)
        {
            // act
            var total = ClimbingStairs.ClimbStairs(n);

            // assert
            Console.WriteLine($"Number of ways to climb {n} stairs: {total}");
            Assert.That(total, Is.EqualTo(expected));
        }

        [TestCase(5, 8)]
        public void ClimbStairs_Optimized_Test(int n, int expected)
        {
            // act
            var total = ClimbingStairs.ClimbStairs_Optimized(n);

            // assert
            Console.WriteLine($"Number of ways to climb {n} stairs: {total}");
            Assert.That(total, Is.EqualTo(expected));
        }

        [TestCase(new int[] { 10, 15, 20 }, 15)]
        public void MinCostClimbingStairs_Test(int[] cost, int minCost)
        {
            var result = ClimbingStairs.MinCostClimbingStairs(cost);
            Console.WriteLine($"Minimum cost to climb stairs with costs [{string.Join(", ", cost)}]: {result}");

            Assert.That(result, Is.EqualTo(minCost));
        }

        [TestCase(new int[] { 10, 15, 20 }, 15)]
        public void MinCostClimbingStairs_Optimized_Test(int[] cost, int minCost)
        {
            var result = ClimbingStairs.MinCostClimbingStairs(cost);
            Console.WriteLine($"Minimum cost to climb stairs with costs [{string.Join(", ", cost)}]: {result}");

            Assert.That(result, Is.EqualTo(minCost));
        }

        [TestCase(4, 2, 5)]
        public void ClimbStairsWithKSteps_Test(int n, int k, int expected)
        {
            var result = ClimbingStairs.ClimbStairsWithKSteps(n, k);

            Assert.That(result, Is.EqualTo(expected));

        }
    }
}
