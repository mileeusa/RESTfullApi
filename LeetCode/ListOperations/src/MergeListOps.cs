using ListInActions.model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ListInActions.src
{
    public class MergeListOps
    {
        public static ListNode? MergeTwoSortedLists(ListNode? list1, ListNode? list2)
        {
            if (list1 == null) return list2;
            if (list2 == null) return list1;

            ListNode dummyListNode = new();
            ListNode curr = dummyListNode;
            ListNode? node1 = list1;
            ListNode? node2 = list2;

            while (node1 != null && node2 != null)
            {
                if (node1.val < node2.val)
                {
                    curr.next = new ListNode(node1.val);
                    node1 = node1.next;
                }
                else
                {
                    curr.next = new ListNode(node2.val);
                    node2 = node2.next;
                }
                curr = curr.next;
            }

            while (node1 != null)
            {
                curr.next = new ListNode(node1.val);
                node1 = node1.next;
                curr = curr.next;
            }

            while (node2 != null)
            {
                curr.next = new ListNode(node2.val);
                node2 = node2.next;
                curr = curr.next;
            }

            return dummyListNode.next;
        }        
    }
}
