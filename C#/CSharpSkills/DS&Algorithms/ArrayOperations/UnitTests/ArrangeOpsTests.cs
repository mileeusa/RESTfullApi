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
    public class ArrangeOpsTests
    {
        [TestCase (new int[] { 1, 2, 3, 4, 5, 10, 6, 7, 8, 9}, 5, true)]
        public void CanArrangePairs_Test(int[] nums, int k, bool expected)
        {
            // act
            var result = ArrangeOps.CanArrangePairs(nums, k);

            Assert.That(result, Is.EqualTo(expected));
        }
    }
}
