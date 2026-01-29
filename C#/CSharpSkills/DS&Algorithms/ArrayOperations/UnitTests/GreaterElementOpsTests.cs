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
    public class GreaterElementOpsTests
    {
        [Test]
        public void NextGreaterElement_Test()
        {
            var nums1 = new int[] { 4, 1, 2 };
            var nums2 = new int[] { 1, 3, 4, 2 };

            var result = GreaterElementOps.NextGreaterElement(nums1, nums2);

            Assert.That(result, Is.EqualTo(new int[] { -1, 3, -1 }));
        }
    }
}
