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
    public class SortOpsTests
    {
        [Test]
        public void SortArrayDescending_Test()
        {
            // arrange
            int[] numbers = { 5, 2, 9, 1, 7 };

            // act
            int[] sortedDescending = SortOps.SortArrayDescending(numbers);

            // assert
            int[] expected = { 9, 7, 5, 2, 1 };
           CollectionAssert.AreEquivalent(expected, sortedDescending);
        }
    }
}
