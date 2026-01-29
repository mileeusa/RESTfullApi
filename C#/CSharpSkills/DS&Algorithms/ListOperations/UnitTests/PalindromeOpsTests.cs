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
    public class PalindromeOpsTests
    {
        [Test]
        public void IsPalindrome_Test()
        {
            ListNode head = new ListNode(1);
            head.next = new ListNode(2);
            head.next.next = new ListNode(2);
            head.next.next.next = new ListNode(1);

            var isTrue = PalindromeOps.IsPalindrome(head);

            Assert.That(isTrue, Is.True);
        }
    }
}
