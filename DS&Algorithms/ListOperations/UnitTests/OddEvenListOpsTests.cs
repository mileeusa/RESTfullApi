using ListInActions.model;
using ListInActions.src;
using NUnit.Framework;
using ListInActions.utilities;

namespace ListInActions.UnitTests
{
    [TestFixture]
    public class OddEvenListOpsTests
    {
        [Test]
        public void OddEvenList_Test()
        {
            ListNode head = new ListNode(1);
            head.next = new ListNode(2);
            head.next.next = new ListNode(3);
            head.next.next.next = new ListNode(4);
            head.next.next.next.next = new ListNode(5);

            ListUtilityOps.PrintLinkedList(head);
            Console.WriteLine("==>");

            var newList = OddEvenListOps.OddEvenList(head);

            ListUtilityOps.PrintLinkedList(newList);
        }
    }
}
