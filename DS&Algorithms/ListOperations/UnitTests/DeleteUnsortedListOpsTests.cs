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
    public class DeleteUnsortedListOpsTests
    {
        [Test]
        public void ModifiedList_Test()
        {
            var nums = new int[] { 1, 2, 3, 4 };
            ListNode head = new ListNode(1);
            head.next = new ListNode(2);
            head.next.next = new ListNode(5);

            var result = DeleteUnsortedListOps.ModifiedList(nums, head);

            Assert.That(result, Is.Not.Null);

        }
    }
}
