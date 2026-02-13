using NUnit.Framework;
using ListInActions.src;
using NUnit.Framework.Legacy;
using ListInActions.model;

namespace ListInActions.UnitTests
{
    [TestFixture]
    public class DeleteListOpsTests
    {
        [Test]
        public void DeleteDuplicates_Test()
        {
            // arrange
            ListNode head = new ListNode(1, new ListNode(1, new ListNode(2, new ListNode(3, new ListNode(3)))));

            List<int> expectedValues = new List<int> { 2 };
            List<int> actualValues = new List<int>();
            
            // act
            ListNode? modifiedHead = DeleteSortedListOps.DeleteDuplicates(head);

            ListNode? current = modifiedHead;
            while (current != null)
            {
                actualValues.Add(current.val);
                current = current.next;
            }

            // assert
            CollectionAssert.AreEqual(expectedValues, actualValues);
        }

        [Test]
        public void RemoveNthElement_Test()
        {
            // Create the linked list 1 -> 2 -> 3 -> 4 -> 5
            ListNode head = new ListNode(1, new ListNode(2, new ListNode(3, new ListNode(4, new ListNode(5)))));
            int n = 2;

            // Remove the 2nd node from the end
            ListNode? modifiedHead = DeleteSortedListOps.RemoveNthElement(head, n);

            // Expected linked list after removal: 1 -> 2 -> 3 -> 5
            List<int> expectedValues = new List<int> { 1, 2, 3, 5 };
            List<int> actualValues = new List<int>();

            ListNode? current = modifiedHead;
            while (current != null)
            {
                actualValues.Add(current.val);
                current = current.next;
            }

            CollectionAssert.AreEqual(expectedValues, actualValues);
        }

        [Test]
        public void DeleteMiddle_Test()
        {
            // arrange
            ListNode head = new ListNode(1, new ListNode(2, new ListNode(3, new ListNode(4, new ListNode(5)))));

            // act
            ListNode newHead = DeleteSortedListOps.DeleteMiddle(head);

            // assert
            List<int> expectedValues = new List<int> { 1, 2, 4, 5 };
            List<int> actualValues = new List<int>();

            ListNode? current = newHead;
            while (current != null)
            {
                actualValues.Add(current.val);
                current = current.next;
            }
            CollectionAssert.AreEqual(expectedValues, actualValues);
        }
    }
}
