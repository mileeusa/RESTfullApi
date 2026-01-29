using ListInActions.model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ListInActions.src
{
    public class RotateListOps
    {
        public static ListNode RotateRight(ListNode head, int k)
        {
            if (head == null || head.next == null || k == 0) return head;

            int length = 0;
            ListNode tail = head;
            while (tail.next != null)
            {
                length++;
                tail = tail.next;
            }

            k = k % length;

            if (k == 0) return head;

            tail.next = head; // make if circular list at first

            int steps = length - k; 

            ListNode newTail = head;
            for (int i = 1; i < steps; i++)
            {
                newTail = newTail.next; // need forward length - k - 1 to find the new tail
            }

            var newHead = newTail.next;
            newTail.next = null;

            return newHead;
        }

        public static ListNode RotateLeft(ListNode head, int k)
        {
            if (head == null || head.next == null || k == 0)
                return head;

            ListNode curr = head;
            int len = 0;
            while (curr != null)
            {
                curr = curr.next;
                len++;
            }

            k %= len;
            if (k == 0) return head;

            ListNode slow = head; 
            ListNode fast = head;

            // 2. Move fast k steps ahead
            for (int i = 1; i <= k; i++)
                fast = fast.next;

            // 3. Move both until fast reaches tail
            while (fast.next != null)
            {
                fast = fast.next;
                slow = slow.next;
            }

            // 4. Rotate
            ListNode newHead = slow.next;
            slow.next = null;
            fast.next = head;

            return newHead;
        }
    }
}
