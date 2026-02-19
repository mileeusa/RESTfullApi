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
    public class PairOpsTests
    {
        [Test]
        public void MaxOperations_Test_One()
        {
            int[] nums = new int[] { 1, 2, 3, 4 };
            int k = 5;
            int expected = 2;
            int actual = PairOps.MaxOperations(nums, k);

            Assert.That(actual, Is.EqualTo(expected));
        }

        [Test]
        public void MaxOperations_Test_Two()
        {
            int[] nums = new int[] { 2, 2, 2, 3, 1, 1, 4, 1 };
            int k = 4;
            int expected = 2;
            int actual = ArrayInActions.src.PairOps.MaxOperations(nums, k);

            Assert.That(actual, Is.EqualTo(expected));
        }

        [Test]
        public void MaxOperations_Hashtable_Test_One()
        {
            int[] nums = new int[] { 1, 2, 3, 4 };
            int k = 5;
            int expected = 2;
            int actual = PairOps.MaxOperations_Hashtable(nums, k);

            Assert.That(actual, Is.EqualTo(expected));
        }

        [Test]
        public void MaxOperations_Hashtable_Test_Two()
        {
            int[] nums = new int[] { 2, 2, 2, 3, 1, 1, 4, 1 };
            int k = 4;
            int expected = 2;
            int actual = ArrayInActions.src.PairOps.MaxOperations(nums, k);

            Assert.That(actual, Is.EqualTo(expected));
        }
    }
}
