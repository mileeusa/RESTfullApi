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
    public class IntersectionOpsTests
    {
        [Test]
        public void InterSectStrings_Test()
        {
            string a = "hello";
            string b = "world";

            var result = IntersectionOps.IntersectStrings(a, b);

            Console.Write($"The intersecton of \"{a}\" and \"{b}\" is: {result}");

            // assert
            Assert.That(result.Contains("o"), Is.True);
            Assert.That(result.Contains("l"), Is.True);
            Assert.That(result.Contains("h"), Is.False);
        }

        [Test]
        public void IntersectStrings_PreserveOrder_Test()
        {
            string a = "hello";
            string b = "world";

            var result = IntersectionOps.IntersectStrings_PreserveOrder(a, b);

            Console.Write($"The intersecton of \"{a}\" and \"{b}\" is: {result}");

            // assert
            Assert.That(result.Contains("o"), Is.True);
            Assert.That(result.Contains("l"), Is.True);
            Assert.That(result.Contains("h"), Is.False);
        }
    }
}
