using ArrayInActions.src;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArrayInActions.UnitTests
{
    [TestFixture]
    public class SlidingWindowOpsTests
    {
        [Test]
        public void MaxSlidingWindow_Dequeue_Test()
        {
            var nums = new int[] { 1, 3, -1, -3, 5, 3, 6, 7 };
            int k = 3;
            Console.WriteLine($"MaxSlidingWindow: {string.Join(", ", nums)}, k = {k}");

            var list = SlidingWindowOps.MaxSlidingWindow_Dequeue(nums, 3);

            Console.WriteLine($"MaxSlidingWindow: {string.Join(", ", list)}");
            Assert.That(list.Count, Is.EqualTo(6));
        }

        [TestCase(new int[] { 1, 3, -1, -3, 5, 3, 6, 7 }, 3)]
        public void MaxSlidingWindow_Test(int[] nums, int k)
        {
            //var nums = new int[] { 1, 3, -1, -3, 5, 3, 6, 7 };
            //int k = 3;
            Console.WriteLine($"MaxSlidingWindow: {string.Join(", ", nums)}, k = {k}");

            // act
            var list = SlidingWindowOps.MaxSlidingWindow(nums, k);

            Console.WriteLine($"MaxSlidingWindow: {string.Join(", ", list)}");
            Assert.That(list.Count, Is.EqualTo(6));
        }
    }
}
