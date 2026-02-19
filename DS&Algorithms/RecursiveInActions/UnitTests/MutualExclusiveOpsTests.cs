using NUnit.Framework;
using RecursiveInActions.src;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecursiveInActions.UnitTests
{
    [TestFixture]
    public class Robbery
    {
        [TestCase(new int[] { 1, 2, 3, 1}, 4)]
        [TestCase(new int[] { 2, 1, 1, 2}, 4)]
        public void Rob_Test(int[] nums, int expected)
        {
            int result = RobberyOps.Rob(nums);

            Assert.That(result, Is.EqualTo(expected));
        }
    }
}
