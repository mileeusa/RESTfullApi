using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ListInActions.src
{
    // 
    // LeetCode 707. Design Linked List
    //
    // Time complexity:
    //
    //  Operation  <==>  Time
    //  Get              O(1)
    //  AddAtIndex       O(n) (index shift)
    //  DeleteAtIndex    O(n) (index shift)
    //  Pointer ops      O(1)
    //
    public class MyLinkedList
    {
        class MyNode(int val)
        {
            public int val = val;
            public MyNode? next = null;
            public MyNode? prev = null;
        }

        private int size = 0;
        private MyNode head, tail;
        private Dictionary<Index, MyNode> indexMap;

        public MyLinkedList()
        {
            head = new MyNode(0);
            tail = new MyNode(0);
            head.next = tail;
            tail.prev = head;

            size = 0;
            indexMap = new Dictionary<Index, MyNode>();
        }

        public int Get(int index)
        {
            if (index < 0 || index >= size)
                return -1;

            return indexMap[index].val;
        }

        public void AddAtHead(int val)
        {
            AddAtIndex(0, val);
        }

        public void AddAtTail(int val)
        {
            AddAtIndex(size, val);
        }

        public void AddAtIndex(int index, int val)
        {
            if (index < 0 || index >= size)
                return;

            MyNode next = (index == size) ? tail : indexMap[index];
            MyNode prev = next.prev!;

            MyNode node = new MyNode(val);
            node.next = next;
            node.prev = prev;

            prev.next = node;
            next.prev = node;

            // shift indices right
            for (int i = size - 1; i >= index; i--)
            {
                indexMap[i + 1] = indexMap[i];
            }

            indexMap[index] = node;
            size++;
        }

        public void DeleteAtIndex(int index)
        {
            if (index < 0 || index >= size)
                return;

            MyNode node = indexMap[index];
            node.prev!.next = node.next;
            node.next!.prev = node.prev;

            // shift indices left
            for (int i = index + 1; i < size; i++)
            {
                indexMap[i-1] = indexMap[i];
            }

            indexMap.Remove(size - 1);
            size--;
        }
    }
}
