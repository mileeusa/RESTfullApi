using SlidingWindowInAction.src;
using NUnit.Framework;

namespace SlidingWindowInAction.UnitTests
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

        [TestCase("ab", "ab", true)]
        [TestCase("ab", "eidbaooo", true)]
        [TestCase("ab", "eidboaoo", false)]
        [TestCase("hello", "ooolleoooleh", false)]
        public void CheckInclusion_Test(string s1, string s2, bool isTrue)
        {
            // act
            var res = SlidingWindowOps.CheckInclusion(s1, s2);

            Assert.That(res, Is.EqualTo(isTrue));
        }

        [TestCase("ab", "ab", true)]
        [TestCase("ab", "eidbaooo", true)]
        [TestCase("ab", "eidboaoo", false)]
        [TestCase("hello", "ooolleoooleh", false)]
        public void CheckInclusion_SlidingWindow_Test(string s1, string s2, bool isTrue)
        {
            // act
            var res = SlidingWindowOps.CheckInclusion_SlidingWindow(s1, s2);

            Assert.That(res, Is.EqualTo(isTrue));
        }
    }
}
