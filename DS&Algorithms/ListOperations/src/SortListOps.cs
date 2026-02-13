using ListInActions.model;
using System.Globalization;

namespace ListInActions.src
{
    public class SortListOps
    {
        //
        // One-sentence intuition (interview-ready)
        //   We iterate through the list, detach each node, and insert it into the correct position of
        //   a growing sorted list using a dummy head to simplify edge cases.
        //
        // Insertion Sort builds the sorted list one element at a time by repeatedly taking the next
        // element from the input list and inserting it into the correct position in the sorted list.
        //
        // Time complexity: worst case: O(N^2), best case: O(N)
        // Space complexity: O(1)
        //
        public static ListNode? InsertionSortList(ListNode head)
        {
            if (head == null) return head;

            var dummyHead = new ListNode(); // dummy head for the sorted list,
                                            // and prev.Next always points to the start of the sorted list
            var current = head;

            while (current != null)
            {
                // save next node list
                ListNode nextNode = current.next;

                // start over the sorted list to find the insertion position for current node
                ListNode prev = dummyHead;

                // this loop finds the last node whose value is smaller that current.Val
                while (prev.next != null && prev.next.val < current.val)
                {
                    prev = prev.next;
                }

                // then we can insert the current between prev and prev.next
                current.next = prev.next!;
                prev.next = current;

                current = nextNode;
            }

            return dummyHead.next;
        }
    }
}
