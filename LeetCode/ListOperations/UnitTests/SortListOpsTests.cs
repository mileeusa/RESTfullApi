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
    public class SortListOpsTests
    {
        [Test]
        public void InsertionSortList_WhenExecute_ShouldSortLinkedList()
        {
            // Arrange
            var head = new model.ListNode(4, new model.ListNode(2, new model.ListNode(1, new model.ListNode(3))));

            // Act
            var sortedHead = SortListOps.InsertionSortList(head);

            // Assert
            var expectedValues = new List<int> { 1, 2, 3, 4 };
            var current = sortedHead;
            int index = 0;
            while (current != null)
            {
                Assert.That(current.val, Is.EqualTo(expectedValues[index]));
                current = current.next;
                index++;
            }
        }
    }
}
