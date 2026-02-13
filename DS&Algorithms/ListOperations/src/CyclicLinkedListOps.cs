using ListInActions.model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ListInActions.src
{
    public class CyclicLinkedListOps
    {
        /// <summary>
        /// Reverses a singly linked cyclic list in place and returns the new head node.
        /// </summary>
        /// 
        /// <remarks>The method assumes that the input list is cyclic, meaning the last node's Next
        /// property points back to the head node. After reversal, the list remains cyclic, with the new head's Next
        /// property eventually leading back to itself through the reversed nodes.</remarks>
        /// 
        /// <param name="head">The head node of the cyclic singly linked list to reverse. Cannot be null if the list is non-empty.</param>
        /// <returns>The new head node of the reversed cyclic list. Returns null if the input list is null.</returns>
        /// 
        public static ListNode? ReversePureCyclicList(ListNode head)
        {
            if (head == null || head.next == null)
            {
                return head;
            }

            ListNode prev = head;
            ListNode curr = head.next;

            while (curr != head)
            {
                ListNode next = curr.next;
                curr.next = prev;
                prev = curr;
                curr = next;
            }

            head.next = prev;

            return prev;
        }

        /// <summary>
        /// Reverses a singly linked list that may contain a cycle. 
        /// </summary>
        /// <param name="head"></param>
        /// <returns></returns>
        /// 
        /// Key Insight:
        ///   Because a cyclic list has no terminal node, I first detect and temporarily break the cycle, 
        ///   reverse the list safely, then restore the cycle at the correct location.”
        ///   
        public static ListNode? ReverseCyclicList(ListNode head)
        {
            if (head == null || head.next == null)
            {
                return head;
            }

            ListNode? cycleEntry = DetectCycleEntry(head);
            if (cycleEntry == null)
            {
                // just a normal list
                return ReverseList(head);
            }

            // find the cycle tail
            ListNode tail = cycleEntry;
            while (tail.next != cycleEntry)
            {
                tail = tail.next!;
            }

            // break the cycle
            tail.next = null;

            // reverse the now linear list
            ListNode newHead = ReverseList(head);

            // restore the cycle
            cycleEntry.next = tail;

            return newHead;
        }

        public static ListNode DetectCycleEntry(ListNode head)
        {
            if (head == null || head.next == null)
            {
                return null;
            }

            ListNode slow = head;
            ListNode fast = head;

            while (fast != null && fast.next != null)
            {
                slow = slow.next!;
                fast = fast.next.next!;
                if (slow == fast)
                {
                    break;
                }
            }
            if (fast?.next == null)
            {
                return null;
            }

            slow = head;
            while (slow != fast)
            {
                slow = slow.next!;
                fast = fast.next!;
            }

            return slow;
        }

        public static bool HasCycle(ListNode head)
        {
            if (head == null || head.next == null)
            {
                return false;
            }

            ListNode slow = head;
            ListNode fast = head;
            while (fast != null && fast.next != null)
            {
                slow = slow.next!;
                fast = fast.next.next!;
                if (slow == fast)
                {
                    return true;
                }
            }
            return false;
        }
        public static ListNode? ReverseList(ListNode? head)
        {
            if (head == null || head.next == null)
            {
                return head;
            }

            ListNode? prev = null;
            ListNode? curr = head;

            while (curr != null)
            {
                ListNode next = curr.next!;
                curr.next = prev!;
                prev = curr;

                curr = next;
            }

            head = prev;

            return head;
        }
    }
}
