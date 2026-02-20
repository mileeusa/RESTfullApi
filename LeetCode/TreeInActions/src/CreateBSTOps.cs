using ListInActions.model;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TreeInActions.src.model;

namespace TreeInActions.src
{
    public class CreateBSTOps
    {
        //
        // Given the head of a singly linked list where elements are sorted in ascending order, convert it to a
        // height-balanced binary search tree.
        //
        // LeetCode 109. Convert Sorted List to Binary Search Tree
        //
        // Time complexity: O(N)
        // Space complexity: O(N)
        //
        public static TreeNode? SortedListToBST(ListNode? head)
        {
            if (head == null) return null;

            var arr = ConvertArray(head);

            return ConvertSortedArrayToBST(arr, 0, arr.Count - 1);
        }

        public static TreeNode? ConvertSortedArrayToBST(List<int> list, int left, int right)
        {
            if (left > right) return null;

            int mid = left + (right - left) / 2;
            TreeNode root = new TreeNode(list[mid]);
            root.left = ConvertSortedArrayToBST(list, left, mid - 1);
            root.right = ConvertSortedArrayToBST(list, mid + 1, right);

            return root;
        }

        private static List<int> ConvertArray(ListNode head)
        {
            var ans = new List<int>();
            var current = head;

            while (current != null)
            {
                ans.Add(current.val);
                current = current.next;
            }

            return ans;
        }

        //
        // Given the head of a singly linked list where elements are sorted in ascending order, convert it to a
        // height-balanced binary search tree.
        //
        // LeetCode 109. Convert Sorted List to Binary Search Tree
        //
        // Time complexity: O(NlogN)
        // Space complexity: O(logN)
        //
        public static TreeNode SortedListToBST_Recursive(ListNode? head)
        {

            if (head == null) return null;

            ListNode prev = null;
            ListNode slow = head;
            ListNode fast = head;

            while (fast != null && fast.next != null)
            {
                prev = slow;
                slow = slow.next;
                fast = fast.next.next;
            }

            TreeNode root = new TreeNode(slow.val);

            if (prev != null)
            {
                prev.next = null;
                root.left = SortedListToBST_Recursive(head);
            }
            root.right = SortedListToBST_Recursive(slow.next);

            return root;
        }
    }
}
