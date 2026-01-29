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
    public class ReorgnizeOpsTests
    {
        [TestCase("aab", "aba")]
        [TestCase("aaab", "")]
        [TestCase("vvvlo", "vlvov")]
        public void ReorganizeString_Test(string s, string expected)
        {
            // arrange

            // act
            var res = ReorgnizeOps.ReorganizeString(s);

            Console.WriteLine($"{s} == > {res}");
            Assert.That(res, Is.EqualTo(expected));
        }
    }
}
