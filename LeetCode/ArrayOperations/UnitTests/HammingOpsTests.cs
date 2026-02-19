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
    public class HammingOpsTests
    {
        [TestCase(new int[] {4, 14, 2}, 6)]
        [TestCase(new int[] {4, 14, 4}, 4)]
        public void TotalHammingDistance_Test(int[] nums, int expected)
        {
            // arrange
            // act 
            int total = HammingOps.TotalHammingDistance(nums);

            //assert
            Assert.That(total, Is.EqualTo(expected));
        }

        [TestCase(1, 4, 2)]
        [TestCase(3, 1, 1)]
        public void HammingDistance_Test(int x, int y, int expected)
        {
            // arrange
            // act 
            int total = HammingOps.HammingDistance(x, y);

            //assert
            Assert.That(total, Is.EqualTo(expected));
        }
    }
}
