using ListInActions.model;
using ListInActions.src;

namespace ListInActions.UnitTests
{
    public class MergeListOpsTests
    {
        public static void MergeTwoSortedLists_Test()
        {
            ListNode list1 = new(1);
            list1.next = new(2);
            list1.next.next = new(4);
            ListNode list2 = new(1);
            list2.next = new(3);
            list2.next.next = new(4);
            Console.WriteLine();
            Console.WriteLine("Using MergeListOps.MergeTwoSortedLists()");
            Console.WriteLine("List1: 1 -> 2 -> 4");
            Console.WriteLine("List2: 1 -> 3 -> 4");

            ListNode? mergedList = MergeListOps.MergeTwoSortedLists(list1, list2);
            while (mergedList != null)
            {
                if (mergedList.next == null)
                {
                    Console.Write(mergedList.val);
                    break;
                }
                else
                {
                    Console.Write(mergedList.val + "->");
                }

                mergedList = mergedList.next;
            }
        }
    }
}
