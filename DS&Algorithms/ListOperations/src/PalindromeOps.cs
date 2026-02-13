using ListInActions.model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ListInActions.src
{
    public class PalindromeOps
    {
        public static bool IsPalindrome(ListNode head)
        {
            if (head == null || head.next == null) 
                return true;

            ListNode slow = head;
            ListNode fast = head;

            while (fast != null && fast.next != null)
            {
                slow = slow.next;
                fast = fast.next.next;
            }

            var secondHalf = ReverseList(slow);
            var firstHalf = head;

            var tmp = secondHalf;

            while (secondHalf != null)
            {
                if (firstHalf.val != secondHalf.val)
                    return false;

                firstHalf = firstHalf.next;
                secondHalf = secondHalf.next;
            }

            // optional: reverse the list
            // ReverseList(tmp);

            return true;
        }

        private static ListNode ReverseList(ListNode head)
        {
            if (head == null || head.next == null) 
                return head;

            ListNode prev = null;
            ListNode curr = head;

            while (curr != null)
            {
                var next = curr.next;
                curr.next = prev;
                prev = curr;
                curr = next;
            }

            return prev;
        }
    }
}
