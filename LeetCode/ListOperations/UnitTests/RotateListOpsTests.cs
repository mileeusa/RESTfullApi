using ListInActions.model;
using ListInActions.src;
using NUnit.Framework;
using ListInActions.utilities;

namespace ListInActions.UnitTests
{
    [TestFixture]
    public class RotateListOpsTests
    {
        [Test]
        public void RotateRight_Test()
        {
            ListNode head = new ListNode(1);
            head.next = new ListNode(2);
            head.next.next = new ListNode(3);
            head.next.next.next = new ListNode(4);
            head.next.next.next.next = new ListNode(5);

            ListNode result = RotateListOps.RotateRight(head, 2);

            ListUtilityOps.PrintLinkedList(result);

        Assert.That(result.val, Is.EqualTo(4));
        }
    }
}
