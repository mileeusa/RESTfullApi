using ListInActions.model;
using ListInActions.src;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ListInActions.UnitTests
{
    [TestFixture]
    public class ArrayListOpsTests
    {
        [Test]
        public void NumComponents_Test()
        {
            // Arrange
            ListNode head = new ListNode(0);
            head.next = new ListNode(1);
            head.next.next = new ListNode(2);
            head.next.next.next = new ListNode(3);
            head.next.next.next.next = new ListNode(4);

            int[] nums = { 0, 3, 1, 4 };

            // Act
            int result = ArrayListOps.NumComponents(head, nums);

            // Assert
            Assert.That(result, Is.EqualTo(2));
        }
    }
}
