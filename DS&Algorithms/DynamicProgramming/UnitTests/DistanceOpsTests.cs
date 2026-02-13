using DynamicProgrammingInActions.src;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DynamicProgrammingInActions.UnitTests
{
    [TestFixture]
    public class DistanceOpsTests
    {
        [TestCase("horse", "ros", 3)]
        [TestCase("intention", "execution", 5)]
        [TestCase("sea", "eat", 2)]
        public void MinDistance_Test_One(string w1, string w2, int expected)
        {
            var minDist = DistanceOps.MinDistance_DP(w1, w2);

            Assert.That(minDist, Is.EqualTo(expected));
        }
    }
}
