using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArrayInActions.UnitTests
{
    [TestFixture]
    public class CountingOpsTests
    {
        [Test]
        public void MajarityElement_Test()
        {
            // arrange
            int[] nums = { 3, 2, 3 };
            Console.WriteLine();
            Console.WriteLine("CountingOps.MajorityElement [{0}]", string.Join(" ", nums));

            // act
            var result = src.CountingOps.MajorityElement(nums);
            Console.WriteLine($"=> {result}");

            // assert
            Assert.That(result, Is.EqualTo(3));
        }

        [Test]
        public void FindKthLargest_Test()
        {
            // arrange
            int[] nums = { 3, 2, 1, 5, 6, 4 };
            int k = 2;
            Console.WriteLine();
            Console.WriteLine("CountingOps.FindKthLargest [{0}], k={1}", string.Join(" ", nums), k);
            // act
            var result = src.CountingOps.FindKthLargest(nums, k);
            Console.WriteLine($"=> {result}");
            // assert
            Assert.That(result, Is.EqualTo(5));
        }
    }
}
