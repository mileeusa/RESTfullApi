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
    public class IntersectArraysOpsTests
    {
        [TestCase (new int[] {2,3,3,5,5,6,7,7,8,12}, new int[] {5,5,6,8,8,9,10,10}, new int[] {5,6,8})]
        public void IntersectTwoSortedArrays_Test(int[] a, int[] b, int[] c)
        {
            var result = IntersectArraysOps.IntersectTwoSortedArrays(a, b);

            Assert.That(result, Is.EquivalentTo(c));
        }

        [TestCase(new int[] { 2, 3, 3, 5, 5, 6, 7, 7, 8, 12 }, new int[] { 5, 5, 6, 8, 8, 9, 10, 10 }, new int[] { 5, 6, 8 })]
        public void IntersectTwoUnsortedArrays_Test(int[] a, int[] b, int[] c)
        {
            var result = IntersectArraysOps.IntersectTwoUnsortedArrays(a, b);

            Assert.That(result, Is.EquivalentTo(c));
        }
    }
}
