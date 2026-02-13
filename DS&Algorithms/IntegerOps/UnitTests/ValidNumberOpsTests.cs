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
    public class ValidNumberOpsTests
    {
        [TestCase("2", true)]
        [TestCase("0089", true)]
        [TestCase("-0.1", true)]
        [TestCase("+3.14", true)]
        [TestCase("4.0", true)]
        [TestCase("-.9", true)]
        [TestCase("2e10", true)]
        [TestCase("-90E3", true)]
        [TestCase("3e+7", true)]
        [TestCase("+6e-1", true)]
        [TestCase("53.5e93", true)]
        [TestCase("-123.456e789", true)]
        [TestCase("abc", false)]
        [TestCase("1a", false)]
        [TestCase("1e", false)]
        [TestCase("e3", false)]
        [TestCase("99e2.5", false)]
        [TestCase("6e6.5", false)]
        [TestCase("--6", false)]
        [TestCase("-+3", false)]
        [TestCase("95a54e53", false)]
        public void IsNumber_Test(string s, bool expected)
        {
            var result = ValidNumberOps.IsNumber(s);

            Assert.That(result, Is.EqualTo(expected));

        }
    }
}
