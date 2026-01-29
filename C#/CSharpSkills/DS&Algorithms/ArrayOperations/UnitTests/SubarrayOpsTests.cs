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
    public class SubarrayOpsTests
    {
        [TestCase(new int[] { 2, 3, -2, 4 }, 6)]
        [TestCase(new int[] { -2, 3, -4 },  24)]
        [TestCase(new int[] { -2, 3, -1 },   6)]
        public void MaxProduct_Test(int[] nums, int expected)
        {
            int maxProduct = SubarrayOps.MaxProduct(nums);

            // assert
            Assert.That(maxProduct, Is.EqualTo(expected));
        }
    }
}
