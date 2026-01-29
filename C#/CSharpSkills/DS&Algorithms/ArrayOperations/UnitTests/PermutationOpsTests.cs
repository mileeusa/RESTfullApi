using ArrayInActions.src;
using NUnit.Framework;

namespace ArrayInActions.UnitTests
{
    [TestFixture]
    public class PermutationOpsTests
    {
        [Test]
        public void Permutation_Test()
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
        public void Permute_Iterative_Test()
        {
            // arrange
            int[] s = { 1, 2, 3 };
            Console.WriteLine();
            Console.WriteLine("All the permutations of the array are: ");

            // act
            var results = PermutationOps.Permute_Iterative(s);

            // assert
            foreach (var item in results)
            {
                Console.WriteLine(string.Join(" ", item));
            }

            Console.WriteLine();

            Assert.That(results[0], Is.EqualTo([3, 2, 1]));
            Assert.That(results[results.Count - 1], Is.EqualTo([1, 2, 3]));
        }

        [Test]
        public void PermuteUnique_Iterative_Test()
        {
            // arrange
            int[] s = { 1, 1, 2 };
            Console.WriteLine();
            Console.WriteLine("All the permutations of the array are: ");

            // act
            var results = PermutationOps.PermuteUnique_Iterative(s);

            // assert
            foreach (var item in results)
            {
                Console.WriteLine(string.Join(" ", item));
            }

            Console.WriteLine();

            Assert.That(results[0], Is.EqualTo([2, 1, 1]));
        }
    }
}
