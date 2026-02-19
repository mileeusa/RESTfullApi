using ListInActions.model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ListInActions.utilities
{
    public class ListUtilityOps
    {
        public static void PrintLinkedList(ListNode head)
        {
            var current = head;

            while (current != null)
            {
                Console.Write(current.val);
                if (current.next != null)
                {
                    Console.Write(" -> ");
                }
                current = current.next;
            }
            Console.WriteLine();
        }
    }
}
