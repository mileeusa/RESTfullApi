using NUnit.Framework;
using StringInActions.src;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StringInActions.UnitTests
{
    [TestFixture] class DeletionOpsTests
    {
        [TestCase ("aabaac", new int[] { 1, 2, 3, 4, 1, 10}, 11)]
        public void MinCost_Test(string s, int[] cost, int expected)
        {
            var result = DeletionOps.MinCost(s, cost);

            Assert.That(result, Is.EqualTo(expected));
        }
    }
}
