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
    public class CombinationSumOpsTests
    {
        [TestCase(3, 7, 1)]
        [TestCase(3, 9, 3)]
        [TestCase(4, 1, 0)]
        public void CombinationSum3_Test(int k, int n, int expectedCnt)
        {
            var result = CombinationSumOps.CombinationSum3(k, n);

            Assert.That(result.Count, Is.EqualTo(expectedCnt));
        }
    }
}
