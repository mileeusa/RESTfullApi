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
        [Test]
        public static void ClimbStairs_Test()
        {
            // arrange
            int n = 5;
            Console.WriteLine();
            Console.WriteLine("ClimbingStairs.ClimbStairs");

            // act
            var total = ClimbingStairs.ClimbStairs(n);

            // assert
            Console.WriteLine($"Number of ways to climb {n} stairs: {total}");
            Assert.That(total, Is.EqualTo(8));
        }

        [Test]
        public static void ClimbStairs_Optimized_Test()
        {
            // arrange
            int n = 5;
            Console.WriteLine();
            Console.WriteLine("ClimbingStairs.ClimbStairs_Optimized");
            
            // act
            var total = ClimbingStairs.ClimbStairs_Optimized(n);

            // assert
            Console.WriteLine($"Number of ways to climb {n} stairs: {total}");
            Assert.That(total, Is.EqualTo(8));
        }

        [Test]
        public static void MinCostClimbingStairs_Test()
        {
            int[] cost = { 10, 15, 20 };
            Console.WriteLine();
            Console.WriteLine("ClimbingStairs.MinCostClimbingStairs");
            Console.WriteLine($"Minimum cost to climb stairs with costs [{string.Join(", ", cost)}]: {ClimbingStairs.MinCostClimbingStairs(cost)}");
        }

        [Test]
        public static void MinCostClimbingStairs_Optimized_Test()
        {
            int[] cost = { 10, 15, 20 };
            Console.WriteLine();
            Console.WriteLine("ClimbingStairs.MinCostClimbingStairs");
            Console.WriteLine($"Minimum cost to climb stairs with costs [{string.Join(", ", cost)}]: {ClimbingStairs.MinCostClimbingStairs_Optimized(cost)}");
        }
    }
}
