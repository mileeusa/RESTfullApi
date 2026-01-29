using ArrayInActions.src;
using NUnit.Framework;
using NUnit.Framework.Legacy;

namespace ArrayInActions.UnitTests
{
    [TestFixture]
    public class RemoveOpsTests
    {
        [Test]
        public static void RemoveElement_Test()
        {
            // arrange
            int[] arr = { 3, 2, 2, 3 };
            int target = 3;

            // act
            Console.WriteLine();
            Console.WriteLine("RemoveOps.RemoveElement(). Array: {0}, Target: {1}", string.Join(" ", arr), target);
            var size = RemoveOps.RemoveElement(arr, target);
            Console.WriteLine("==> {0}", string.Join(", ", arr.Take(size)));

            //assert
            Assert.That(size, Is.EqualTo(2));
        }

        [Test]
        public static void RemoveDuplicated_Test()
        {
            // arrange
            int[] arr = { 1, 2, 3, 3, 4, 4, 5 };

            // act
            Console.WriteLine();
            Console.WriteLine("Using RemoveOps.RemoveDuplicated()");
            var result = RemoveOps.RemoveDuplicated(arr);
            Console.WriteLine(string.Join(", ", result));

            // assert
            CollectionAssert.AreEquivalent(new int[] { 1, 2, 3, 4, 5 }, result);
        }

        [Test]
        public static void RemoveDuplicatedSortedArray1_Test()
        {
            // arrange
            int[] arr = { 1, 1, 2 };
            Console.WriteLine();
            Console.WriteLine("Using RemoveOps.RemoveDuplicatedSortedArray1()");
            Console.WriteLine(string.Join(", ", arr));

            // act
            var result = RemoveOps.RemoveDuplicatedFromSortedArray1(arr);

            // assert
            Console.WriteLine(string.Join(", ", result));
            Assert.That(result, Is.EqualTo(new int[] { 1, 2 }));
        }

        [Test]
        public static void RemoveDuplicatedSortedArray2_Test()
        {
            // arrange
            int[] arr = { 1, 1, 2 };
            Console.WriteLine();
            Console.WriteLine("Using RemoveOps.RemoveDuplicatedSortedArray2()");
            Console.WriteLine(string.Join(", ", arr));

            // act
            int size = RemoveOps.RemoveDuplicatedFromSortedArray2(arr);
            var result = arr.Take(size).ToArray();
            Console.WriteLine(string.Join(", ", result));

            // assert
            Assert.That(size, Is.EqualTo(2));
        }

        [Test]
        public static void RemoveMoreThanTwoDuplicates_Test()
        {
            int[] arr = { 1, 1, 2, 3, 3, 4, 5, 5, 6, 6, 6, 7 };
            Console.WriteLine();
            Console.WriteLine("Using RemoveOps.RemoveMoreThanTwoDuplicates()");
            Console.WriteLine(string.Join(", ", arr));
            var size = RemoveOps.RemoveMoreThanTwoDuplicates(arr);
            Console.WriteLine($"After removing more than 2 duplicates");
            Console.WriteLine(string.Join(", ", arr.Take(size)));
        }

        [Test]
        public void RemoveMoreThanThreeDuplicates_Test()
        {
            int[] arr = { 1, 1, 1, 1, 2, 2, 3, 3, 3, 3 };
            Console.WriteLine();
            Console.WriteLine();

            int result = RemoveOps.RemoveMoreThanThreeDuplicates(arr);

            // assert
            Assert.That(result, Is.EqualTo(8));
        }

        [Test]
        public void RemoveChars_Test()
        {
            // arrange
            char[] arr = { 'a', 'b', 'c', 'd', 'e', 'f', 'g' };
            char[] remove = { 'b', 'd', 'f' };

            Console.WriteLine();
            Console.WriteLine("Using RemoveOps.RemoveChars()");
            Console.WriteLine("Array: {0}, Remove: {1}", string.Join(" ", arr), string.Join(" ", remove));

            // act
            var result = RemoveOps.RemoveChars(arr, remove);

            // assert
            Console.WriteLine("==> {0}", string.Join(", ", result));
            Assert.That(result, Is.EqualTo(new char[] { 'a', 'c', 'e', 'g' }));
        }
    }
}
