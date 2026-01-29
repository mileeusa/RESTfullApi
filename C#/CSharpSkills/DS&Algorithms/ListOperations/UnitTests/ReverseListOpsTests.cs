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
    public class ReverseListOpsTests
    {
        [Test]
        public void ReverseList_Test()
        {
            // arrange
            ListNode node = new ListNode(1);
            node.next = new ListNode(2);
            node.next.next = new ListNode(3);
            node.next.next.next = new ListNode(4);
            node.next.next.next = new ListNode(5);

            Console.WriteLine($"Reverse Linked List: {string.Join(", ", RetrieveList(node))}");

            // act
            ListNode? newNode = ReverseListOps.ReverseList(node);

            // assert
            Console.WriteLine($"=> {string.Join(", ", RetrieveList(newNode))}");
        }

        public static List<int> RetrieveList(ListNode? head)
        {
            var list = new List<int>();
            ListNode? curr = head;

            while (curr != null)
            {
                list.Add(curr.val);
                curr = curr.next;
            }

            return list;
        }
    }
}
