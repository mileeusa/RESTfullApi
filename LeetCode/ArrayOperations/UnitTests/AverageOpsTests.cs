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
    public class AverageOpsTests
    {
        [Test]
        public void FindMaxAverage_Test()
        {
            int[] nums = { 1, 12, -5, -6, 50, 3 };
            int k = 4;

            var result = AverageOps.FindMaxAverageI(nums, k);

            Console.WriteLine($"Average of {k} maximum elements: {result}");

            Assert.That(result, Is.EqualTo(12.75));
        }

        [Test]
        public void FindMaxAverageII_Test()
        {
            // arrange
            int[] nums = { 1, 12, -5, -6, 50, 3 };
            int k = 4;
            
            // act
            var result = AverageOps.FindMaxAverageII(nums, k);

            // assert
            Console.WriteLine($"Average of at least {k} maximum elements: {result}");

            double error = Math.Abs(result - 12.75);

            Assert.That(error, Is.LessThan(1e-5));
        }
    }
}
