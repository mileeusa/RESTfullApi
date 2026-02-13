using Microsoft.VisualStudio.TestPlatform.CommunicationUtilities.ObjectModel;
using NUnit.Framework;
using QueueInActions.model;
using System.Collections.Generic;

namespace QueueInActions.src
{
    public class PriorityQueueOps
    {
        public static List<int> TopN(List<int> list, int k)
        {
            if (list == null || list.Count == 0)
            {
                return [];
            }

            var pq = new PriorityQueue<int, int>();

            for (int i = 0; i < list.Count; i++)
            {
                pq.Enqueue(list[i], list[i]);

                if (pq.Count > k)
                {
                    pq.Dequeue();
                }
            }

            var result = pq.UnorderedItems.Select(x => x.Element).ToList();
            result.Sort(); // ascending
            
            //result.Sort(Comparer<int>.Create((a, b) => b.CompareTo(a))); // descending
            //result.Sort((a, b) => b.CompareTo(a)); // descending

            return result;
        }

        // return the kth Largest Element in a Stream
        //
        // LeetCode 75:
        //    215. Kth Largest Element in an Array
        //
        public static int KthKargest(List<int> nums, int k)
        {
            // create a mini-heap with k elements
            var queue = new PriorityQueue<int, int>();

            foreach (int i in nums)
            {
                queue.Enqueue(i, i);

                if (queue.Count > k)
                {
                    queue.Dequeue(); // remove the smallest
                }
            }

            return queue.Peek();
        }

        // Merge K sorted linked lists into one sorted list.
        public static ListNode MergeLists(ListNode[] lists)
        {
            var pq = new PriorityQueue<ListNode, int>();

            // Push the head of each list to the min-heap
            foreach (var node in lists)
            {
                if (node != null)
                {
                    pq.Enqueue(node, node.val);
                }
            }

            //
            // Note:
            //
            // dummy is a placeholder node to simplify the logic.
            // current is a pointer that will track the last node in the merged list as we build it.
            // Initially, current points to dummy. At the end, dummy.next will be the head of the merged list.
            //
            var dummy = new ListNode(0);
            ListNode current = dummy;

            while (pq.Count > 0)
            {
                // Repeatedly pop the smallest and push its next node.
                var node = pq.Dequeue();                
                if (node.next != null)
                {
                    pq.Enqueue(node.next, node.next.val);
                }

                current.next = node;    // append the smallest node to the merged list
                current = current.next; // move the pointer
            }

            return dummy.next;
        }

        //
        // Given an integer array nums and an integer k, return the k most
        // frequent elements. You may return the answer in any order.
        //
        // Constraints:
        //
        //   1 <= nums.length <= 10^5
        //   -10^4 <= nums[i] <= 10^4        //
        //   k is in the range[1, the number of unique elements in the array].
        //
        //   It is guaranteed that the answer is unique.
        //
        // LeetCode 347: Top K Frequent Elements
        //
        // Time complexity:  O(NlogK)
        // Space complexity: O(N)
        //
        public static int[] TopKFrequent(int[] nums, int k)
        {
            var frequent = new Dictionary<int, int>();

            foreach (var n in nums)
            {
                frequent[n] = frequent.GetValueOrDefault(n, 0) + 1;
            }

            var pq = new PriorityQueue<int, int>();

            foreach(var kv in frequent)
            {
                pq.Enqueue(kv.Key, kv.Value);

                if (pq.Count > k)
                {
                    // Remove the smallest frequency when exceeding K.
                    pq.Dequeue();
                }
            }

            var result = new int[k];
            int i = 0;
            while (pq.Count > 0)
            {
                result[i++] = pq.Dequeue();
            }

            //var result = pq.UnorderedItems.Select(x => x.Element).ToArray();
            //Array.Sort(result);

            return result;
        }

        //
        // Find Median from Data Stream
        //
        // Time complexity: it's O(long N) to insert into a heap
        // Space complexity: O(N)
        //
        public static double FindMedian(int[] nums)
        {
            var minPQ = new PriorityQueue<int, int>();
            var maxPQ = new PriorityQueue<int, int>(Comparer<int>.Create((x, y) => y - x));

            foreach(var num in nums)
            {
                maxPQ.Enqueue(num, num);
                minPQ.Enqueue(maxPQ.Dequeue(), num);

                if (minPQ.Count > maxPQ.Count)
                {
                    maxPQ.Enqueue(minPQ.Dequeue(), num);
                }
            }

            return (maxPQ.Count > minPQ.Count) ? maxPQ.Peek() : (minPQ.Peek() + maxPQ.Peek()) / 2;
        }

        //
        // Given tasks represented by letters and cooldown period n, return the minimum intervals to finish all tasks.
        //
        // Difficulty: Hard
        // Concepts: Max Heap, scheduling
        //
        // Solution: Priority Queue + Greedy
        //
        public static int LeastInterval(char[] tasks, int n)
        {
            var count = new int[26];
            foreach(var t in tasks)
            {
                count[t - 'A']++;
            }

            var pq = new PriorityQueue<int, int>(Comparer<int>.Create((a, b) => b - a));
            foreach(var c in count)
            {
                if (c > 0)
                {
                    pq.Enqueue(c, c);
                }
            }

            int time = 0;
            while (pq.Count > 0)
            {
                var tmp = new List<int>();
                int cycle = n + 1;

                while (cycle-- > 0 && pq.Count > 0)
                {
                    int cur = pq.Dequeue();
                    if (cur > 1)
                    {
                        tmp.Add(cur - 1);
                    }

                    time++;
                }

                foreach(var t in tmp)
                {
                    pq.Enqueue(t, t);
                }

                if (pq.Count > 0)
                {
                    time += cycle + 1; // idle time
                }
            }

            return time;
        }

        public static int[][] KCloset(int[][] points, int k)
        {
            var pq = new PriorityQueue<int[], int>(Comparer<int>.Create((x, y) => y - x));

            foreach(var p in points)
            {
                int dist = p[0] * p[0] + p[1] * p[1];
                pq.Enqueue(p, dist);

                if (pq.Count > k)
                {
                    pq.Dequeue();
                }
            }

            return pq.UnorderedItems.Select(x => x.Element).ToArray();
        }
    }
}
