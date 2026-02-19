using ListInActions.model;
using ListInActions.src;
using ListInActions.utilities;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ListInActions.UnitTests
{
    [TestFixture]
    public class SumOpsTests
    {
        [Test]
        public void PairSum_Test()
        {
            // arrange
            Console.WriteLine();
            Console.WriteLine("SumOps.PairSum_Test:");
            ListNode head = new ListNode(5);
            head.next = new ListNode(4);
            head.next.next = new ListNode(2);
            head.next.next.next = new ListNode(1);

            // act
            var result = SumOps.PairSum(head);
            // assert
            Console.WriteLine($"Max twin sum: {result}:");

            // assert
            Assert.That(result, Is.EqualTo(6)); // (1,5) and (2, 4)
        }

        [Test]
        public void PairSum_ReverseSecondHalf_Test()
        {
            // arrange
            Console.WriteLine();
            Console.WriteLine("SumOps.PairSum_Test:");
            ListNode head = new ListNode(5);
            head.next = new ListNode(4);
            head.next.next = new ListNode(2);
            head.next.next.next = new ListNode(1);

            // act
            var result = SumOps.PairSum_ReverseSecondHalf(head);
            // assert
            Console.WriteLine($"Max twin sum: {result}:");

            // assert
            Assert.That(result, Is.EqualTo(6)); // (1,5) and (2, 4)
        }

        [Test]
        public void AddTwoNumbers_Test()
        {
            // arrange
            Console.WriteLine();
            Console.WriteLine("SumOps.AddTwoNumbers:");
            ListNode l1 = new ListNode(2);
            l1.next = new ListNode(4);
            l1.next.next = new ListNode(3);
            ListNode l2 = new ListNode(5);
            l2.next = new ListNode(6);
            l2.next.next = new ListNode(4);
            ListUtilityOps.PrintLinkedList(l1);
            ListUtilityOps.PrintLinkedList(l2);

            // act
            var result = SumOps.AddTwoNumbers(l1, l2);

            // assert
            Console.Write("Result: ");
            ListUtilityOps.PrintLinkedList(result);

            // assert
            Assert.Pass();
        }

        
    }
}
