using ArrayInActions.src;
using NUnit.Framework;
using NUnit.Framework.Legacy;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArrayInActions.UnitTests
{
    [TestFixture]
    public class EquilibriumIndexTests
    {
        [Test]
        public void FindEquilibriumIndex_Test()
        {
            // arrange
            int[] nums = { -7, 1, 5, 2, -4, 3, 0, 0 };

            // act
            var indexies = EquilibriumIndex.FindEquilibriumIndex(nums);

            // assert
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine("Find the equilibrium index for array: {0}", string.Join(",", nums));
            Console.WriteLine("Equilibrium index: {0}", string.Join(",", indexies));

            CollectionAssert.AreEquivalent(new List<int> { 3, 6, 7 }, indexies);
        }
    }
}
