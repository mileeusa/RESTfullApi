using ArrayInActions.src;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArrayInActions.UnitTests
{
    [TestFixture]
    public class MissingNumberOpsTests
    {
        [Test]
        public void FirstMissingPositive_Test()
        {
            // arrange
            int[] nums = { -1, 4, 2, 1, 9, 10 };

            // act
            int result = MissingNumberOps.FirstMissingPositive(nums);

            // assert
            Assert.That(result, Is.EqualTo(3));
        }
    }
}
