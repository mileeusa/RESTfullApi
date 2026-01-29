using ListInActions.model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ListInActions.src
{
    public class ReverseListOps
    {
        /// <summary>
        /// Iterative approach to reverse a singly linked list
        /// </summary>
        /// <param name="head"></param>
        /// <returns></returns>
        ///
        /// Time: O(N)
        /// Space: O(1)
        ///
        /// Key Intwerview Points:
        ///   We iterate through the list, reversing each node’s Next pointer to point to the previous node 
        ///   while advancing forward. At the end, prev becomes the new head.
        ///   
        public static ListNode? ReverseList(ListNode? head)
        {
            if (head == null || head.next == null)
            {
                return head;
            }

            ListNode? curr = head;
            ListNode? prev = null;

            while (curr != null)
            {
                ListNode? next = curr.next;
                curr.next = prev!; // Use null-forgiving operator to indicate prev can be null here
                prev = curr;
                curr = next;
            }

            head = prev;

            // Return prev, which is the new head of the reversed list
            return head;
        }

        public static ListNode? ReverseList_Recursive(ListNode? head)
        {
            if (head == null || head.next == null)
            {
                return head;
            }

            // reverse from the second node onward, then flip the current node’s pointer after recursion returns.
            ListNode? newHead = ReverseList_Recursive(head.next);
            head.next.next = head;
            head.next = null;

            return newHead;
        }

    }
}
