using NUnit.Framework;
using StringInActions.src;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StringInActions.UnitTests
{
    [TestFixture]
    public class DecodeStringOpsTests
    {
        [Test]
        public void DecodeString_Test()
        {
            // arrange
            string s = "3[a2[c]]";

            // act
            string result = DecodeStringOps.DecodeString(s);

            // assert
            Assert.That(result, Is.EqualTo("accaccacc"));
        }
    }
}
