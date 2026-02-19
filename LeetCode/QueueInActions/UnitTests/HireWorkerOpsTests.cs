using NUnit.Framework;
using QueueInActions.src;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QueueInActions.UnitTests
{
    [TestFixture]
    public class HireWorkerOpsTests
    {
        [Test]
        public void TotalCost_Test()
        {
            var costs = new int[] { 17, 12, 10, 2, 7, 2, 11, 20, 8 };
            int k = 3;
            int candidates = 4;

            var total = HireWorkerOps.TotalCost(costs, k, candidates);

            Assert.That(total, Is.EqualTo(11));
        }
    }
}
