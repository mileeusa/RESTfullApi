using ArrayInActions.src;
using NUnit.Framework;
using NUnit.Framework.Legacy;

namespace ArrayInActions.UnitTests
{
    [TestFixture]
    public class SumOfArrayTests
    {
        [Test]
        public void TwoSum_UnsortedArray_Test()
        {
            // arrange
            int[] nums = { 2, 7, 11, 15 };
            int target = 9;

            // act
            Console.WriteLine();
            Console.WriteLine("SumOfArrayOps.TwoSum_UnsortedArray");
            Console.WriteLine("Original array: " + string.Join(", ", nums));
            int[] result = SumOfArrayOps.TwoSum_UnsortedArray(nums, target);
            Console.WriteLine($"Indices of numbers that add up to {target}: [{string.Join(", ", result)}]");

            // assert
            CollectionAssert.AreEquivalent(new int[] { 0, 1 }, result);
        }

        [Test]
        public static void MaxMin_Test()
        {
            int[] nums = { 1, 2, 3, 4, 5, 6, 7, 8 };

            (var max, var min) = SumOfArrayOps.MaxMin(nums);

            Console.WriteLine();
            Console.WriteLine($"The min and max for {string.Join(", ", nums)} is [{min}, {max}]");
        }

        [Test]
        public static void Sum_Test()
        {
            int[] nums = { 1, 2, 3, 4, 5 };
            int sum = SumOfArrayOps.Sum(nums);
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine("Sum of array: {0} is {1}", string.Join(",", nums), sum);
        }

        [Test]
        public void TwoSum_SortedArray_Test()
        {
            int[] nums = { 1, 2, 3, 4, 5, 6, 7, 8 };

            IList<int[]> result = SumOfArrayOps.TwoSum_SortedArray(nums, 10);

            // assert
            Assert.That(result.Count, Is.EqualTo(3));
        }

        [TestCase(new int[] { -1, 0, 1, 2, -1, -4 }, 0, 2)]
        [TestCase(new int[] { -1, 0, 1, 2, -1, -4 }, 2, 1)]
        public void ThreeSum_Test(int[] nums, int target, int expectCount)
        {
            // arrange

            // act
            IList<IList<int>> result = SumOfArrayOps.ThreeSum(nums, target);

            // assert
            Assert.That(result.Count, Is.EqualTo(expectCount));
        }

        [TestCase(new int[] { 1, 0, -1, 0, -2, 2 }, 0, 3)]
        [TestCase(new int[] { 2, 2, 2, 2 }, 8, 1)]
        [TestCase(new int[] { 2, 2, 2, 2, 2 }, 8, 1)]
        [TestCase(new int[] { 0, 0, 0, 1000000000, 1000000000, 1000000000, 1000000000 }, 1000000000, 1)]
        public void FourSum_Test(int[] nums, int target, int expected)
        {
            // arrange

            // act
            var result = SumOfArrayOps.FourSum(nums, target);

            // assert
            Assert.That(result.Count, Is.EqualTo(expected));
        }
    }
}
