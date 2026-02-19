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
    public class DecodingWaysIIOpsTests
    {
        [TestCase("1*", 18)]
        [TestCase("3*", 9)]
        public void NumDecodingsII_Test(string s, int expected)
        {
            var result = DecodingWaysIIOps.NumDecodingsII(s);

            Assert.That(result, Is.EqualTo(expected));
        }

    }
}
