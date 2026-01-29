using IntegerInActions.src;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IntegerInActions.UnitTests
{
    [TestFixture]
    public class ReverseOpsTests
    {
        [Test]
        public void Reverse_Test()
        {
            // arrange
            int input = 12345;
            int expected = 54321;
            // act
            int result = ReverseOps.Reverse(input);
            // assert
            Assert.That(result, Is.EqualTo(expected));
        }
    }
}
