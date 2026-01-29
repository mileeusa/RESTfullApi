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
    public class MinOpsTests
    {
        [TestCase(new int[] { 0, 1, 1, 1, 0, 0 }, 3)]
        [TestCase(new int[] { 0, 1, 1, 1 }, -1)]
        public void MinOperations_Test(int[] arr, int expected)
        {
            // arrange

            // act
            int result = MinOps.MinOperations(arr);

            // assert
            Assert.That(result, Is.EqualTo(expected));
        }
    }
}
