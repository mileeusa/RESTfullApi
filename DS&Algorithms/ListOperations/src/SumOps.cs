using ListInActions.model;
using NUnit.Framework;
using NUnit.Framework.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ListInActions.src
{
    public class SumOps
    {
        //
        // In a linked list of size n, where n is even, the ith node (0-indexed) of
        // the linked list is known as the twin of the (n-1-i)th node,
        // if 0 <= i <= (n / 2) - 1.
        //
        // For example, if n = 4, then node 0 is the twin of node 3, and node 1 is
        // the twin of node 2. These are the only nodes with twins for n = 4.
        //
        // The twin sum is defined as the sum of a node and its twin.
        //
        // Given the head of a linked list with even length, return the maximum twin sum of the linked list.
        //
        // LeetCode 75:
        //   2130. Maximum Twin Sum of a Linked List
        //
        // Time complexity:  O(n)
        // Space complexity: O(n)
        //
        // Difificulty: Medium
        //
        public static int PairSum(ListNode head)
        {
            if (head == null) return 0;

            int length = 0;
            var curr = head;

            // count length
            while (curr != null)
            {
                length++;
                curr = curr.next;
            }

            int half = length / 2;
            var arr = new int[half];

            // store first half
            curr = head;
            for (int i = 0; i < half; i++)
            {
                arr[i] = curr.val;
                curr = curr.next;
            }

            // add second half in reverse
            for (int i = half - 1; i >= 0; i--)
            {
                arr[i] += curr.val;
                curr = curr.next;
            }

            // find max
            int max = arr[0];
            for (int i = 1; i < half; i++)
            {
                max = Math.Max(max, arr[i]);
            }

            return max;
        }

        // Interview-level note (important)
        //
        // Best possible solution uses:
        //   Fast/slow pointers to find the middle
        //   Reverse the second half in-place
        //   Compare twin sums in one pass
        //
        // Time complexity:  O(n)
        // Space complexity: O(1)
        //
        public static int PairSum_ReverseSecondHalf(ListNode head)
        {
            if (head == null) return 0;

            ListNode fast = head;
            ListNode slow = head;

            while (fast != null && fast.next != null)
            {
                fast = fast.next!.next!;
                slow = slow.next!;
            }

            // reverse second half
            ListNode prev = null;

            while (slow != null)
            {
                ListNode next = slow.next;
                slow.next = prev;
                prev = slow;
                slow = next;
            }

            // calculate max twin sum
            int maxSum = 0;
            ListNode first = head;
            ListNode second = prev;

            while (second != null)
            {
                int sum = first.val + second.val;
                maxSum = Math.Max(maxSum, sum);
                first = first.next;
                second = second.next;
            }

            return maxSum;
        }

        //
        // You are given two non-empty linked lists representing two non-negative integers.
        // The digits are stored in reverse order, and each of their nodes contains a single digit.
        // Add the two numbers and return the sum as a linked list.
        //
        // You may assume the two numbers do not contain any leading zero, except the number 0 itself.
        //
        // LeetCode 2: Add Two Numbers
        //
        // Time complexity:  O(max(m, n))
        // Space complexity: O(max(m, n))
        //
        // Difificulty: Medium
        //
        public static ListNode AddTwoNumbers(ListNode l1, ListNode l2)
        {
            ListNode dummyHead = new ListNode(0);
            var current = dummyHead;
            var first = l1;
            var second = l2;

            int carry = 0;
            while (first != null || second != null)
            {
                int x = (first != null) ? first.val : 0;
                int y = (second != null) ? second.val : 0;
                int sum = carry + x + y;
                carry = sum / 10;
                current.next = new ListNode(sum % 10);
                current = current.next;

                if (first != null) first = first.next;
                if (second != null) second = second.next;
            }

            if (carry > 0)
            {
                current.next = new ListNode(carry);
            }

            return dummyHead.next!;
        }
    }
}
