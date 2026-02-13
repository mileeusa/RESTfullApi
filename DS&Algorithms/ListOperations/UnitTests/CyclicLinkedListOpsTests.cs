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
    public class CyclicLinkedListOpsTests
    {
        [Test]
        public void HasCycle_TestOne()
        {
            // arrange
            var node1 = new model.ListNode(3);
            var node2 = new model.ListNode(2);
            var node3 = new model.ListNode(0);
            var node4 = new model.ListNode(-4);
            node1.next = node2;
            node2.next = node3;
            node3.next = node4;
            node4.next = node2; // Create a cycle here

            // act
            bool hasCycle = CyclicLinkedListOps.HasCycle(node1);

            // assert
            Assert.That(hasCycle, Is.True);
        }

        [Test]
        public void HasCycle_TestTwo()
        {
            // arrange
            var node1 = new model.ListNode(3);
            var node2 = new model.ListNode(2);
            var node3 = new model.ListNode(0);
            var node4 = new model.ListNode(-4);
            node1.next = node2;
            node2.next = node3;
            node3.next = node4;
            node4.next = null;

            // act
            bool hasCycle = CyclicLinkedListOps.HasCycle(node1);

            // assert
            Assert.That(hasCycle, Is.False);
        }

        [Test]
        public void ReversePureCyclicList_Test()
        {
            // arrange
            var node1 = new model.ListNode(1);
            var node2 = new model.ListNode(2);
            var node3 = new model.ListNode(3);
            node1.next = node2;
            node2.next = node3;
            node3.next = node1;

            // act
            var newHead = CyclicLinkedListOps.ReversePureCyclicList(node1);

            // assert
            // After reversal, the new head should be node4
            Assert.That(newHead.val, Is.EqualTo(3));

            // Verify the cycle is maintained and the order is reversed
            Assert.That(newHead.next.val, Is.EqualTo(2));
            Assert.That(newHead.next.next.val, Is.EqualTo(1));
            Assert.That(newHead.next.next.next, Is.EqualTo(newHead)); // Cycle check
        }

        [Test]
        public void ReverseCyclicList_Test()
        {
            var node3 = new model.ListNode(3);
            var node4 = new model.ListNode(4);
            var node5 = new model.ListNode(5);
            node3.next = node4;
            node4.next = node5;
            node5.next = node3; // Create a cycle here

            // act
            var newHead = CyclicLinkedListOps.ReverseCyclicList(node3);

            // assert
            Assert.That(newHead.val, Is.EqualTo(5));
            Assert.That(newHead.next.val, Is.EqualTo(4));
        }
    }
}
