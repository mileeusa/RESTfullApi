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
    public class BinarySearchOpsTests
    {
        [Test]
        public void BinarySearchableNumbers_Test()
        {
            // arrange
            int[] nums = new int[] { 2, 1, 3, 5, 4, 7, 6 };

            // act
            int result = BinarySearchOps.BinarySearchableNumbers(nums);

            // assert
            Assert.That(result, Is.EqualTo(1));
        }

        [Test]
        public void BinarySearchableNumbers_ZeroSpace_Test()
        {
            // arrange
            int[] nums = new int[] { 2, 1, 3, 5, 4, 7, 6 };

            // act
            int result = BinarySearchOps.BinarySearchableNumbers_Monotonic(nums);

            // assert
            Assert.That(result, Is.EqualTo(1));
        }
    }
}
