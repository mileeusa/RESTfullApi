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
    public class QuickSortOpsTests
    {
        [Test]
        public void QuickSort_Test()
        {
            // arrange
            var nums = new int[] { 3, 5, 4, 2, 1, 6, 7 };
            Console.WriteLine($"Quick Sort: {string.Join(", ", nums)}");
            QuickSortOps.QuickSort(nums);
            Console.WriteLine($"Quick Sort: {string.Join(", ", nums)}");
            Assert.That(nums[0], Is.EqualTo(1));
        }
    }
}
