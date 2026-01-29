using NUnit.Framework;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ListInActions.src.Flatten
{
    public class MyNode
    {
        public int Val;
        public MyNode Next;
        public MyNode Child;

        public MyNode(int val)
        {
            Val = val;
            Next = null;
            Child = null;
        }
    }

    public class FlattenOps
    {
        // Flatten Nested Linked List — Recursive (DFS)
        //
        // Idea
        //   Traverse node by node
        //   When a node has a Child, recursively flatten it
        //   Insert child list between current and next
        //
        // Time:  O(N)
        // Space: O(depth) (recursive stack)
        //
        public static MyNode FlattenRecursive(MyNode head)
        {
            if (head == null)
                return null;

            MyNode curr = head;

            while (curr != null)
            {
                if (curr.Child != null)
                {
                    MyNode next = curr.Next;

                    // Flatten child
                    MyNode childHead = FlattenRecursive(curr.Child);

                    // Attach child
                    curr.Next = childHead;
                    curr.Child = null;

                    // Find tail of child list
                    MyNode tail = childHead;
                    while (tail.Next != null)
                        tail = tail.Next;

                    // Attach back the next
                    tail.Next = next;
                }
                curr = curr.Next;
            }

            return head;
        }

        public static MyNode FlattenIterative(MyNode head)
        {
            if (head == null)
                return null;

            Stack<MyNode> stack = new Stack<MyNode>();
            MyNode curr = head;

            while (curr != null)
            {
                if (curr.Child != null)
                {
                    if (curr.Next != null)
                        stack.Push(curr.Next);

                    curr.Next = curr.Child;
                    curr.Child = null;
                }
                else if (curr.Next == null && stack.Count > 0)
                {
                    curr.Next = stack.Pop();
                }

                curr = curr.Next;
            }

            return head;
        }
    }
}
