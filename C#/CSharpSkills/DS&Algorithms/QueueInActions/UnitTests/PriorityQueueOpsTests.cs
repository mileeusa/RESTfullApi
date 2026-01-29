using NUnit.Framework;
using QueueInActions.model;
using QueueInActions.src;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QueueInActions.UnitTests
{
    [TestFixture]
    public class PriorityQueueOpsTests
    {
        [Test]
        public void TopN_Test()
        {
            // arrange
            List<int> list = new List<int>()
            {
                1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 18, 19, 20, 21, 22
            };

            // 
            var result = PriorityQueueOps.TopN(list, 10);

            // assert
            Console.WriteLine($"Top 10 elements from \"{string.Join(", ", list)}\" are \"{string.Join(", ", result)}\".");
            Assert.That(result.Count, Is.EqualTo(10));
        }

        [Test]
        public void LeastInterval_TestOne()
        {
            var tasks = new char[] { 'A', 'A', 'A', 'B', 'B', 'B' };
            int n = 2;

            int result = PriorityQueueOps.LeastInterval(tasks, n);

            Assert.That(result, Is.EqualTo(8));
        }

        [Test]
        public void LeastInterval_TestTwo()
        {
            var tasks = new char[] { 'A', 'A', 'A', 'B', 'B', 'C' };
            int n = 0;

            int result = PriorityQueueOps.LeastInterval(tasks, n);

            Assert.That(result, Is.EqualTo(6));
        }

        [Test]
        public void LeastInterval_TestThree()
        {
            var tasks = new char[] { 'A', 'A', 'A', 'A' };
            int n = 3;

            int result = PriorityQueueOps.LeastInterval(tasks, n);

            Assert.That(result, Is.EqualTo(13));
        }

        [Test]
        public void LeastInterval_TestFour()
        {
            var tasks = new char[] { 'A', 'A', 'B', 'B', 'C', 'C' };
            int n = 2;

            int result = PriorityQueueOps.LeastInterval(tasks, n);

            Assert.That(result, Is.EqualTo(6)); // different types perfectly fill cooldown slots.
        }

        [Test]
        public void FindMedian_Test()
        {
            int[] nums = { 1, 2, 3, 4, 5, 6, 7 };
            var median = PriorityQueueOps.FindMedian(nums);

            Assert.That(median, Is.EqualTo(4));
        }

        [Test]
        public void TopKFrequentElements_Test()
        {
            // arrange
            int[] nums = { 1, 2, 3, 4, 5, 4, 3, 3, 7, 2 };
            int topK = 3;

            // act
            var result = PriorityQueueOps.TopKFrequent(nums, topK);
            Console.WriteLine($"Top {topK} frequent elements from array {string.Join(",", nums)} are {string.Join(", ", result)}");

            // assert
            Assert.That(result.Count(), Is.EqualTo(topK));
        }

        [Test]
        public void MergeLists_Test()
        {
            // act
            var result = PriorityQueueOps.MergeLists(BuildListNodeArray());

            Console.WriteLine($"Merged list:");
            ListNode current = result;

            while (current != null)
            {
                Console.Write($"{current.val} ");
                current = current.next;
            }
            Console.WriteLine();

            // assert
            Assert.That(result, Is.Not.Null);
        }

        private ListNode[] BuildListNodeArray()
        {
            // new List<int>() { 1, 4, 7, 10 },
            // new List<int>() { 2, 5, 8, 11 },
            // new List<int>() { 3, 6, 9, 12 }

            ListNode head1 = new ListNode(1);
            head1.next = new ListNode(4);
            head1.next.next = new ListNode(7);
            head1.next.next.next = new ListNode(10);

            ListNode head2 = new ListNode(2);
            head2.next = new ListNode(5);
            head2.next.next = new ListNode(8);
            head2.next.next.next = new ListNode(11);

            ListNode head3 = new ListNode(3);
            head3.next = new ListNode(6);
            head3.next.next = new ListNode(9);
            head3.next.next.next = new ListNode(12);

            return new ListNode[] { head1, head2, head3 };
        }
    }
}
