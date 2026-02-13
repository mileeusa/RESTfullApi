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
    public class DecodingOpsTests
    {
        [TestCase("12", 2)]
        [TestCase("06", 0)]
        public void NumDecodings_DP_Test(string str, int expected)
        {
            var result = DecodingOps.NumDecodings_DP(str);

            Assert.That(result, Is.EqualTo(expected));
        }

        [TestCase("12", 2)]
        [TestCase("06", 0)]
        [TestCase("10", 1)]
        public void NumDecodings_Iterative_Test(string str, int expected)
        {
            var result = DecodingOps.NumDecodings_Iterative(str);

            Assert.That(result, Is.EqualTo(expected));
        }
    }
}
