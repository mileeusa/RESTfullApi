using ListInActions.model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace ListInActions.src
{
    public class DeleteUnsortedListOps
    {
        // 
        // You are given an array of integers nums and the head of a linked list. Return the
        // head of the modified linked list after removing all nodes from the linked list
        // that have a value that exists in nums.
        //
        // LeetCode 3217. Delete Nodes From Linked List Present in Array
        //
        // Hint:
        //   Add all elements of nums into a HashSet.
        //   Scan the list to check if the current element should be deleted by checking the Set.
        //
        public static ListNode ModifiedList(int[] nums, ListNode head)
        {
            // TBD
            return null;
        }

        // 
        // Key idea:
        //   Remove all values that appear more than once, keeping only values with frequency 1.
        //   That means:
        //     First pass → count frequencies
        //     Second pass → rebuild list with only unique values
        //
        // LeetCode 1836. Remove Duplicates From an Unsorted Linked List
        //
        // Time complexity:  O(N)
        // Space complexity: O(N)
        //
        // Note: this is in-place implementation
        //
        //                        <<<<<Interview-ready summary>>>>>
        //
        // Because the list is unsorted, I need to know whether a value appears later. I’ll first
        // count frequencies, then do an in-place pass where I delete any node whose value
        // appears more than once. I’ll use a dummy head so deletions at the front are
        // handled cleanly, and only move the prev pointer when I keep a node.
        //
        public ListNode DeleteDuplicatesUnsorted(ListNode head)
        {
            if (head == null || head.next == null) return head;

            var freq = new Dictionary<int, int>();

            var curr = head;
            while (curr != null)
            {
                freq[curr.val] = freq.GetValueOrDefault(curr.val, 0) + 1;
                curr = curr.next;
            }

            var dummy = new ListNode(0);
            dummy.next = head;

            var prev = dummy;
            curr = head;

            while (curr != null)
            {
                if (freq.TryGetValue(curr.val, out var f) && f > 1)
                {
                    prev.next = curr.next;
                }
                else
                {
                    prev.next = curr;
                    prev = prev.next;
                }

                curr = curr.next;
            }

            return dummy.next;
        }
    }
}
