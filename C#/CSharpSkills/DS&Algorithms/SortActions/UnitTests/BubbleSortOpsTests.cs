using NUnit.Framework;
using SortActions.src;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SortActions.UnitTests
{
    [TestFixture]
    public class BubbleSortOpsTests
    {
        [Test]
        public void BubbleSort_Test()
        {
            // arrange
            var nums = new int[] { 3, 5, 4, 2, 1, 6, 7 };

            Console.WriteLine($"Bubble Sort: {string.Join(", ", nums)}");
            BubbleSortOps.BubbleSort(nums);

            Console.WriteLine($"Bubble Sort: {string.Join(", ", nums)}");
            Assert.That(nums[0], Is.EqualTo(1));
        }

        [Test]
        public void BubbleSort_Optimized_Test()
        {
            // arrange
            var nums = new int[] { 3, 5, 4, 2, 1, 6, 7 };

            Console.WriteLine($"Bubble Sort: {string.Join(", ", nums)}");
            BubbleSortOps.BubbleSort_Optimized(nums);

            Console.WriteLine($"Bubble Sort: {string.Join(", ", nums)}");
            Assert.That(nums[0], Is.EqualTo(1));
        }
    }
}
