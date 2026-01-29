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
    public class ParenthesisOpsTests
    {
        [TestCase("()", true)]
        [TestCase("(*)", true)]
        [TestCase("(*))", true)]
        public void CheckValidString_Test(string s, bool expected)
        {
            var res = ParenthesisOps.CheckValidString(s);

            // assert
            Assert.That(res, Is.EqualTo(expected));
        }
    }
}
