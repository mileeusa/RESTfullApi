using ArrayInActions.src;
using NUnit.Framework;
using NUnit.Framework.Legacy;

namespace ArrayInActions.UnitTests
{
    [TestFixture]
    public class MergeSortedArrayOpsTests
    {
        [Test]
        public void MergeSortedArray_Test()
        {
            // arrange
            int[] first = new int[10] { 1, 3, 5, 7, 9, 0, 0, 0, 0, 0 }; // first has enough space
            int m = 5; // number of valid elements in first
            int[] second = new int[] { 2, 4, 6, 8, 10 };
            int n = second.Length;

            // act
            Console.WriteLine();
            Console.WriteLine("Before Merging:");
            Console.WriteLine("First: " + string.Join(", ", first));
            Console.WriteLine("Second: " + string.Join(", ", second));
            MergeSortedArrayOps.Merge(first, m, second, n);
            Console.WriteLine("After Merging:");
            Console.WriteLine("Merged: " + string.Join(", ", first));

            // assert
            CollectionAssert.AreEquivalent(new List<int> { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 }, first);
        }
    }
}
