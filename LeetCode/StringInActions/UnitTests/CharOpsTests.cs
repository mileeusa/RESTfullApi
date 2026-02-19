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
    public class CharOpsTests
    {
        [TestCase("abcdefg3456", "ABCDEFG3456")]
        public void ToUpper_Test(string s, string expected)
        {
            var result = CharOps.ToUpper(s);

            Assert.That(result, Is.EqualTo(expected));
        }

        [TestCase("abcdefg3456", "ABCDEFG3456")]
        public void ToUpper_II_Test(string s, string expected)
        {
            var result = CharOps.ToUpper_II(s);

            Assert.That(result, Is.EqualTo(expected));
        }
    }
}
