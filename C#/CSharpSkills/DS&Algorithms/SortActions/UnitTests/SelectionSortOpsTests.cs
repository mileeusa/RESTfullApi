using NUnit.Framework;
using NUnit.Framework.Legacy;
using SortActions.src;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SortActions.UnitTests
{
    [TestFixture]
    public class SelectionSortOpsTests
    {
        [Test]
        public void SelectionSort_Test()
        {
            // arrange
            var nums = new int[] { 3, 5, 4, 2, 1, 6, 7 };
            Console.WriteLine($"Selection Sort: {string.Join(", ", nums)}");
            SelectionSortOps.SelectionSort(nums);
            Console.WriteLine($"Selection Sort: {string.Join(", ", nums)}");
            Assert.That(nums[0], Is.EqualTo(1));
        }

        [Test]
        public void RetrieveTopN_Test()
        {
            // 
            List<int> list = [1, 2, 3, 43, 54, 66, 45, 6, 5, 7, 22, 25];

            var result = SelectionSortOps.RetrieveTopN(list, 10);

            Console.WriteLine("RetrieveTopN");
            Console.WriteLine(string.Join(", ", list));
            Console.WriteLine(string.Join(", ", result));

            Assert.That(result.Count, Is.EqualTo(10));
            CollectionAssert.AreEquivalent(new List<int> { 66, 54, 45, 43, 25, 22, 7, 6, 5, 3 }, result);
        }
    }
}
