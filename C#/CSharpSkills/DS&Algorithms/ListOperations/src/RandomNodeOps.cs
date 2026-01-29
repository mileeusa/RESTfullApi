using ListInActions.model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ListInActions.src
{
    public class RandomNodeOps
    {
        //
        // From a linked list of unknown size, return one node, such that every node has equal
        // probability (1/N) of being chosen.
        //
        // Time: O(N)
        // Space: O(1)
        //
        // Interview one-liner:
        //   we use reservoir sampling to pick a uniformly random node from a linked list in
        //   one pass with O(1) space.
        //
        public static ListNode? GetRandomNode(ListNode head)
        {
            if (head == null) 
                return null;

            ListNode? result = null;
            int count = 0;

            for (var current = head; current != null; current = current.next)
            {
                count++;
                if (Random.Shared.Next(count) == 0) // we use the thread-safe Random.Shared
                {
                    // For the k-th node:
                    //   We replace the result with probability 1/k
                    //   Otherwise, keep the previous result
                    //
                    result = current;
                }
            }

            return result;
        }
    }
}
