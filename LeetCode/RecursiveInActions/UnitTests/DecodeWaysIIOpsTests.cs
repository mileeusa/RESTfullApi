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
    public class DecodeWaysIIOpsTests
    {
        [TestCase("12", 2)]
        [TestCase("226", 3)]
        [TestCase("*", 9)]
        [TestCase("1*", 18)]
        [TestCase("2*", 15)]
        public void NumDecodingsII_Test(string s, int expected)
        {
            var result = DecodeWaysIIOps.NumDecodingsII(s);

            Assert.That(result, Is.EqualTo(expected));
        }
    }
}
