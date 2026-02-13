using ListInActions.model;
using NUnit.Framework.Internal.Execution;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace ListInActions.src
{
    //
    // Given the head of a singly linked list, group all the nodes with odd indices
    // together followed by the nodes with even indices, and return the
    // reordered list.
    //
    // The first node is considered odd, and the second node is even, and so on.
    //
    // Note that the relative order inside both the even and odd groups
    // should remain as it was in the input.
    //
    // You must solve the problem in O(1) extra space complexity and O(n) time complexity.
    //
    // LeetCode 328. Odd Even Linked List
    //
    // Dificulty: Medium
    //
    public class OddEvenListOps
    {
        public static ListNode? OddEvenList(ListNode? head)
        {
            if (head == null) return head;

            var odd = head;
            var even = head.next;
            var evenHead = even;

            while (even != null && even.next != null)
            {
                odd.next = even.next;
                odd = odd.next;

                even.next = odd.next;
                even = even.next;
            }

            odd.next = evenHead;

            return head;
        }
    }
}
