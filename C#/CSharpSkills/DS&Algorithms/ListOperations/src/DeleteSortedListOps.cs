using ListInActions.model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ListInActions.src
{   
    public class DeleteSortedListOps
    {
        public static ListNode DeleteDuplicates(ListNode head)
        {
            var dummy = new ListNode(0);
            dummy.next = head;

            var prev = dummy;
            var curr = head;

            while (curr != null)
            {
                if (curr.next != null && curr.val == curr.next.val)
                {
                    int val = curr.val;

                    // skip all
                    while (curr != null && curr.val == val)
                    {
                        curr = curr.next;
                    }

                    prev.next = curr;
                }
                else
                {
                    prev = curr;
                    curr = curr.next;
                }
            }

            return dummy.next;
        }

        //
        // Given the head of a linked list, remove the nth node from the end of the list and return its head.
        //
        // LeetCode 19. Remove Nth Node From End of List
        //
        //
        public static ListNode? RemoveNthElement(ListNode head, int n)
        {
            if (head == null) return null;

            //ListNode dummy = new ();
            //dummy.next = head;

            //// use the dummy to cover the general cases, such as remove the head!!!
            //ListNode first = dummy;
            //ListNode second = dummy;

            //int i = 0;
            //for (; i <= n && first != null; i++)
            //{
            //    first = first.next;
            //}

            //if (i != n + 1) return dummy.next;

            //while (first != null)
            //{
            //    first = first.next;
            //    second = second.next;
            //}
            var first = head;
            var second = head;

            for (int i = 0; i < n; i++)
            {
                first = first.next;
            }

            if (first == null) return head.next;

            while (first.next != null)
            {
                first = first.next;
                second = second.next;
            }

            second.next = second.next?.next;

            //return dummy.next;
            return head;
        }

        public static ListNode DeleteMiddle(ListNode head)
        {
            if (head == null || head.next == null) return null;

            ListNode prev = null;
            ListNode slow = head;
            ListNode fast = head;

            while (fast != null && fast.next != null)
            {
                prev = slow;
                slow = slow.next;
                fast = fast.next.next;
            }

            prev.next = slow.next;

            return head;
        }
    }
}
