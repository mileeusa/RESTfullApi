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
    public class DuplicateOpsTests
    {
        [Test]
        public void RemoveDuplicatesFromUnsortedList_Test()
        {
            ListNode head = new ListNode(1);
            head.next = new ListNode(2);
            head.next.next = new ListNode(2);
            head.next.next.next = new ListNode(1);

            var newList = DuplicateOps.RemoveDuplicatesFromUnsortedList(head);

            while (newList != null)
            {
                Console.Write($"{newList.val} ");
                newList = newList.next;
            }
        }

        [Test]
        public void RemoveDuplicateFromSortedList_Test()
        {
            ListNode head = new ListNode(1);
            head.next = new ListNode(1);
            head.next.next = new ListNode(2);
            head.next.next.next = new ListNode(2);

            var newList = DuplicateOps.RemoveDuplicateFromSortedList(head);

            while (newList != null)
            {
                Console.Write($"{newList.val} ");
                newList = newList.next;
            }
        }
    }
}
