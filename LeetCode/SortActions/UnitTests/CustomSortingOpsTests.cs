using FluentAssertions;
using NUnit.Framework;
using SortActions.src;
using SortActions.src.model;

namespace SortActions.UnitTests
{
    [TestFixture]
    public class CustomSortingOpsTests
    {
        [Test]
        public void SortingBasedOnWordFrequency_Test()
        {
            // arrange
            var list = new List<string>() { "apple", "banana", "apple", "dog", "banana", "apple" };

            // expected -> ["apple", "apple", "apple", "banana", "banana", "dog"]

            // act
            CustomSortingOps.SortingBasedOnWordFrequency(list);

            // assert
            Assert.That(list[3], Is.EqualTo("banana"));
        }

        [Test]
        public void SortNaturally_Test()
        {
            // arrange
            var list = new List<string>() { "file1", "file20", "file3", "file10" };

            // act
            CustomSortingOps.SortNaturally(list);

            // assert
            Assert.That(list[0], Is.EqualTo("file1"));
            Assert.That(list[1], Is.EqualTo("file3"));
            Assert.That(list[2], Is.EqualTo("file10"));
            Assert.That(list[3], Is.EqualTo("file20"));
        }

        [Test]
        public void SortLinkedList_Test()
        {
            // arrange
            List<ListNode> list = new List<ListNode>()
            {
                BuildList(5, 1, 2),    // Val = 5, length = 3
                BuildList(3),          // Val = 3, length = 1
                BuildList(5, 9),       // Val = 5, length = 2
                BuildList(3, 7, 8, 9), // Val = 3, length = 4
                BuildList(2, 4)        // Val = 2, length = 2
            };

            // act
            CustomSortingOps.SortLinkedList(list);

            Assert.That(list[0].Val, Is.EqualTo(2));
            Assert.That(list[1].Val, Is.EqualTo(3));
            Assert.That(list[2].Val, Is.EqualTo(3));
            Assert.That(list[3].Val, Is.EqualTo(5));
            Assert.That(list[4].Val, Is.EqualTo(5));

            // FluentAssertion
            list[0].Val.Should().Be(2);
        }

        private ListNode BuildList(params int[] values)
        {
            ListNode head = null;
            ListNode cur = null;

            foreach (var v in values)
            {
                if (head == null)
                {
                    head = new ListNode { Val = v };
                    cur = head;
                }
                else
                {
                    cur.Next = new ListNode { Val = v };
                    cur = cur.Next;
                }
            }

            return head;
        }
    }
}
