using NUnit.Framework;
using ListInActions.src;
using ListInActions.model;

namespace ListInActions.UnitTests
{
    [TestFixture]
    public class RandomNodeOpsTests
    {
        [Test]
        public void GetRandomNode_Test()
        {
            // Arrange
            ListNode head = new ListNode(1);
            head.next = new ListNode(2);
            head.next.next = new ListNode(3);
            head.next.next.next = new ListNode(4);
            head.next.next.next.next = new ListNode(5);

            int[] nums = { 1, 2, 3, 4, 5 };

            // Act
            ListNode? randomNode = RandomNodeOps.GetRandomNode(head);

            // Assert
            Assert.That(randomNode, Is.Not.Null);
            Assert.That(nums, Does.Contain(randomNode!.val)); 
        }
    }
}
