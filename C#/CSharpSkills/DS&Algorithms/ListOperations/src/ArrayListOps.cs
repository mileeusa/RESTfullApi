using ListInActions.model;
using Newtonsoft.Json.Linq;
using NUnit.Framework;
using System.Collections.Generic;

namespace ListInActions.src
{
    public class ArrayListOps
    {
        //
        // You are given the head of a linked list containing unique integer values and
        // an integer array nums that is a subset of the linked list values.
        //
        // Return the number of connected components in nums where two values are
        // connected if they appear consecutively in the linked list.
        //
        // LeetCode Problem 817: https://leetcode.com/problems/linked-list-components/
        //
        public static int NumComponents(ListNode head, int[] nums)
        {
            var numSet = new HashSet<int>(nums);

            int count = 0;
            ListNode? current = head;

            //
            // While walking the linked list, whenever a node is in nums and either:
            //   -- it's the end of the list OR
            //   -- its next value is not in nums
            //
            //  Then we found the END of a connected component -> increment answer.
            //
            while (current != null)
            {

                if (numSet.Contains(current.val) &&
                    (current.next == null || !numSet.Contains(current.next.val)))
                {
                    count++;
                }

                current = current.next;
            }

            return count;
        }
    }
}
