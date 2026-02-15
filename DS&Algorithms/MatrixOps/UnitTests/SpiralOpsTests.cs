using ListInActions.model;
using MatrixOps.src;
using NUnit.Framework;
using NUnit.Framework.Legacy;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MatrixOps.UnitTests
{
    [TestFixture]
    class SpiralOpsTests
    {
        [Test]
        public void SpiralOrder_Test()
        {
            var arr = new int[][]
            {
                [ 1,  2,  3,  4],
                [ 5,  6,  7,  8],
                [ 9, 10, 11, 12],
                [13, 14, 15, 16]
            };

            var expected = new int[] { 1, 2, 3, 4, 8, 12, 16, 15, 14, 13, 9, 5, 6, 7, 11, 10 };

            var result = SpiralOps.SpiralOrder(arr);

            Assert.That(result.Count, Is.EqualTo(expected.Length));
            CollectionAssert.AreEquivalent(result, expected);
        }

        [TestCase(1, 4, 0, 0, 4)]
        [TestCase(5, 6, 1, 4, 30)]
        public void SpiralMatrixIII_Test(int rows, int cols, int rStart, int cStart, int expectedCnt)
        {
            var result = SpiralOps.SpiralMatrixIII(rows, cols, rStart, cStart);

            Assert.That(result.Count, Is.EqualTo(expectedCnt));
        }

        [Test]
        public void SpiralMatrixIV_Test()
        {
            var nums = new int[] { 3, 0, 2, 6, 8, 1, 7, 9, 4, 2, 5, 5, 0 };
            ListNode head = BuildList(nums);

            var result = SpiralOps.SpiralMatrixIV(3, 5, head);

            Assert.That(result[1][0], Is.EqualTo(5));
        }

        private ListNode BuildList(int[] nums)
        {
            ListNode dummyHead = new ListNode(0);
            var current = dummyHead;

            foreach (int num in nums)
            {
                current.next = new ListNode(num);
                current = current.next;
            }

            return dummyHead.next;
        }

    }
}
