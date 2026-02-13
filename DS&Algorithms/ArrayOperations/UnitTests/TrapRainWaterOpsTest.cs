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
    public class TrapRainWaterOpsTest
    {
        [Test]
        public void MaxWaterArea_Test()
        {
            // arrange
            int[] heights = { 0, 1, 0, 2, 1, 0, 1, 3, 2, 1, 2, 1 };

            var list = new int[] { 12, 12, 14, 15 };
            Console.WriteLine($"list[^1]: {list[^1]}");
            Assert.That(list[^1], Is.EqualTo(15));

            // act
            int result = TrapRainWaterOps.MaxWaterArea(heights);

            // assert
            Console.WriteLine();
            Console.WriteLine($"The maximum water area is: {result}");
            Console.WriteLine();

            Assert.That(result, Is.EqualTo(14));
        }

        [Test]
        public void TrapRainWater_TestOne()
        {
            // arrange
            int[] heights = { 0, 1, 0, 2, 1, 0, 1, 3, 2, 1, 2, 1 };

            // act
            int result = TrapRainWaterOps.Trap(heights);

            // assert
            Console.WriteLine();
            Console.WriteLine($"The total amount of rain water trapped is: {result}");
            Console.WriteLine();

            Assert.That(result, Is.EqualTo(6));
        }

        [Test]
        public void TrapRainWater_TestTwo()
        {
            // arrange
            int[] heights = { 0, 1, 0, 2, 1, 0, 1, 3, 2, 1, 2, 1 };

            // act
            int result = TrapRainWaterOps.TrapRainWater(heights);

            // assert
            Console.WriteLine();
            Console.WriteLine($"The total amount of rain water trapped is: {result}");
            Console.WriteLine();

            Assert.That(result, Is.EqualTo(6));
        }

        [Test]
        public void TrapRainWater_DP_TestOne()
        {
            // arrange
            int[] heights = { 0, 1, 0, 2, 1, 0, 1, 3, 2, 1, 2, 1 };

            // act
            int result = TrapRainWaterOps.TrapRainWater_DP(heights);

            // assert
            Console.WriteLine();
            Console.WriteLine($"The total amount of rain water trapped is: {result}");
            Console.WriteLine();

            Assert.That(result, Is.EqualTo(6));
        }
    }
}
