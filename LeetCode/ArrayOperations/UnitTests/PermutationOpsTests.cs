using ArrayInActions.src;
using NUnit.Framework;
using NUnit.Framework.Legacy;

namespace ArrayInActions.UnitTests
{
    [TestFixture]
    public class PermutationOpsTests
    {
        [TestCase(new int[] { 1, 2, 3 }, new int[] { 1, 3, 2 })]
        [TestCase(new int[] { 1, 3, 2 }, new int[] { 2, 1, 3 })]
        [TestCase(new int[] { 3, 2, 1 }, new int[] { 1, 2, 3 })]
        [TestCase(new int[] { 1, 1, 5 }, new int[] { 1, 5, 1 })]
        public void NextPermutation_Test(int[] nums, int[] expected)
        {
            // act
            PermutationOps.NextPermutation(nums);

            // assert
            CollectionAssert.AreEqual(nums, expected);
        }

        [Test]
        public void Permutation_Test()
        {
            // arrange
            int[] s = { 1, 2, 3 };
            Console.WriteLine();
            Console.WriteLine("All the permutations of the array are: ");

            // act
            var results = PermutationOps.Permute_Recursive(s);

            // assert
            foreach (var item in results)
            {
                Console.WriteLine(string.Join(" ", item));
            }

            Console.WriteLine();

            Assert.That(results[0], Is.EqualTo([1, 2, 3]));
            Assert.That(results[results.Count - 1], Is.EqualTo([3, 2, 1]));
        }

        [Test]
        public void Permute_Test()
        {
            // arrange
            int[] s = { 1, 2, 3 };
            Console.WriteLine();
            Console.WriteLine("All the permutations of the array are: ");

            // act
            var results = PermutationOps.Permute(s);

            // assert
            foreach (var item in results)
            {
                Console.WriteLine(string.Join(" ", item));
            }
            Console.WriteLine();

            Assert.That(results[0], Is.EqualTo([1, 2, 3]));
            Assert.That(results[results.Count - 1], Is.EqualTo([3, 2, 1]));
        }

        [Test]
        public void Permute2_Test()
        {
            // arrange
            int[] s = { 1, 2, 3 };
            Console.WriteLine();
            Console.WriteLine("All the permutations of the array are: ");

            // act
            var results = PermutationOps.Permute_Backtrack(s);

            // assert
            foreach (var item in results)
            {
                Console.WriteLine(string.Join(" ", item));
            }
            Console.WriteLine();

            Assert.That(results[0], Is.EqualTo([1, 2, 3]));
            Assert.That(results[results.Count - 1], Is.EqualTo([3, 2, 1]));
        }

        [Test]
        public void PermuteUnique_Iterative_Test()
        {
            // arrange
            int[] s = { 1, 1, 2 };
            Console.WriteLine();
            Console.WriteLine("All the permutations of the array are: ");

            // act
            var results = PermutationOps.PermuteUnique(s);

            // assert
            foreach (var item in results)
            {
                Console.WriteLine(string.Join(" ", item));
            }

            Console.WriteLine();

            Assert.That(results[0], Is.EqualTo([1, 1, 2]));
        }
    }
}
