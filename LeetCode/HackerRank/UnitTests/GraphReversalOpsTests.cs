using HackerRank.src;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HackerRank.UnitTests
{
    [TestFixture]
    public class GraphReversalOpsTests
    {
        [Test]
        public void CountReverseEdges_Test()
        {
            int gNodes = 5;
            int[] gFrom = new int[] { 1, 2, 2, 4 };
            int[] gTo = new int[] { 2, 3, 4, 5 };

            var result = GraphReversalOps.CountReverseEdges(gNodes, gFrom.ToList(), gTo.ToList());

            Assert.That(result, Is.EqualTo((new int[] { 0, 1, 2, 2, 3 }).ToList()));
        }
    }
}
