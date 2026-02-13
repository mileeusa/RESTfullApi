using ListInActions.model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ListInActions.src
{
    public class DuplicateOps
    {
        // 
        // Remove the duplicated from unsorted linked list
        // 
        public static ListNode RemoveDuplicatesFromUnsortedList(ListNode head)
        {
            var set = new HashSet<int>();

            ListNode dummy = new ListNode(0, head);
            ListNode prev = dummy;
            ListNode curr = head;

            while (curr != null)
            {
                if (set.Contains(curr.val))
                {
                    prev.next = curr.next;
                }
                else
                {
                    set.Add(curr.val);
                    prev = curr;
                }

                curr = curr.next;
            }

            return dummy.next;
        }

        public static ListNode RemoveDuplicateFromSortedList(ListNode head)
        {
            if (head == null) return null;

            ListNode curr = head;

            while (curr.next != null)
            {
                if (curr.val == curr.next.val)
                {
                    curr.next = curr.next.next;
                }
                else
                {
                    curr = curr.next;
                }
            }

            return head;
        }
    }
}
