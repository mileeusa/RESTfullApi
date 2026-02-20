using ListInActions.model;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TreeInActions.src;

namespace TreeInActions.UnitTests
{
    [TestFixture]
    public class CreateBSTOpsTests
    {
        [Test]
        public void SortedListToBST_Recursive_Test()
        {
            ListNode head = new ListNode(-10);
            head.next = new ListNode(-3);
            head.next.next = new ListNode(0);
            head.next.next.next = new ListNode(5);
            head.next.next.next.next = new ListNode(9);

            var root = CreateBSTOps.SortedListToBST_Recursive(head);

            Assert.That(root.val, Is.EqualTo(0));

        }

        [Test]
        public void SortedListToBST_Test()
        {
            ListNode head = new ListNode(-10);
            head.next = new ListNode(-3);
            head.next.next = new ListNode(0);
            head.next.next.next = new ListNode(5);
            head.next.next.next.next = new ListNode(9);

            var root = CreateBSTOps.SortedListToBST(head);

            Assert.That(root.val, Is.EqualTo(0));

        }
    }
}
