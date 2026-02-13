using Interview2026InActions.src;
using NUnit.Framework;
using StringInActions.src;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interview2026InActions.UnitTests
{
    [TestFixture]
    public class RecursiveOpsTests
    {
        [TestCase("12", 2)]
        [TestCase("226", 3)]
        public void NumDecodings_RecursiveMemo_Test(string str, int expectedCount)
        {
            var result = RecursiveOps.NumDecodings(str);

            Assert.That(result, Is.EqualTo(expectedCount));
        }
    }
}
