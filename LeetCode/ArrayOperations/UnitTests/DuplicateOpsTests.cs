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
    public class DuplicateOpsTests
    {
        [TestCase (new int[] { 1, 2, 3, 4, 5}, false)]
        [TestCase (new int[] { 1, 2, 2, 4, 5}, true)]
        public void HasDuplicates(int[] nums, bool expected)
        {
            var isTrue = DuplicateOps.HasDuplicates(nums);

            Assert.That(isTrue, Is.EqualTo(expected));
        }

        [TestCase(new int[] { 1, 2, 3, 4, 5, 5 }, 5)]
        public void FindDuplicate_Test(int[] nums, int expected)
        {
            var result = DuplicateOps.FindDuplicate(nums);

            Assert.That(result, Is.EqualTo(expected));
        }

        [TestCase(new int[] { 1, 2, 3, 4, 5, 5 }, 5)]
        public void FindDuplicate_II_Test(int[] nums, int expected)
        {
            var result = DuplicateOps.FindDuplicate_II(nums);

            Assert.That(result, Is.EqualTo(expected));
        }
    }
}
