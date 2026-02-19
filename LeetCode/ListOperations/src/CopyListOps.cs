using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ListInActions.src.CopyList
{
    public class MyNode
    {
        public int val;
        public MyNode next;
        public MyNode random;

        public MyNode(int _val)
        {
            val = _val;
            next = null;
            random = null;
        }
    }

    public class CopyListOps
    {
        public static MyNode CopyRandomList(MyNode head)
        {
            if (head == null) return head;

            MyNode curr = head;
            while (curr != null)
            {
                MyNode copy = new MyNode(curr.val);
                copy.next = curr.next;
                curr.next = copy;
                curr = copy.next;
            }

            // assign the random node
            curr = head;
            while (curr != null && curr.next != null)
            {
                if (curr.random != null)
                    curr.next.random = curr.random.next;

                curr = curr.next.next;
            }

            // separate the lists
            MyNode dummy = new MyNode(0);
            curr = head;
            MyNode copyCurr = dummy;

            while (curr != null)
            {
                MyNode copy = curr.next;
                curr.next = copy.next;
                copyCurr.next = copy;

                copyCurr = copy;
                curr = curr.next;
            }

            return dummy.next;
        }

        public static MyNode CopyRandomList_Hashtable(MyNode head)
        {
            if (head == null) return head;

            var map = new Dictionary<MyNode, MyNode>();

            MyNode curr = head;
            while (curr != null)
            {
                map[curr] = new MyNode(curr.val);
                curr = curr.next;
            }

            curr = head;
            while (curr != null)
            {
                map[curr].next = (curr.next != null) ? map[curr.next] : null;
                map[curr].random = (curr.random != null) ? map[curr.random] : null;
                curr = curr.next;
            }

            return map[head];
        }
    }
}
