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
    public class DistanceOpsTests
    {
        [TestCase("horse", "ros", 3)]
        public void MinDistance_Test(string w1, string w2, int expected)
        {
            var minDist = DistanceOps.MinDistance(w1, w2);

            Assert.That(minDist, Is.EqualTo(expected));
        }

        [TestCase("abc", "adc", true)]
        [TestCase("abc", "adbc", true)]
        public void IsOneEditDistance_Test(string s, string t, bool expected)
        {
            var result = DistanceOps.IsOneEditDistance(s, t);

            Assert.That(result, Is.EqualTo(expected));
        }
    }
}
