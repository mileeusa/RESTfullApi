using GraphInActions.src;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraphInActions.UnitTests
{
    [TestFixture]
    public class DiameterOpsTests
    {
        [Test]
        public void TreeDiameterUndirected_Test()
        {
            var graph = new Dictionary<int, List<(int neighbor, int weight)>>()
            {
                [1] = new() { (2, 3), (3, 5) },
                [2] = new() { (1, 3), (4, 4), (5, 2) },
                [3] = new() { (1, 5) },
                [4] = new() { (2, 4) },
                [5] = new() { (2, 2), (6, 1) },
                [6] = new() { (5, 1) }
            };
            int diameter = DiameterOps.TreeDiameterUndirected(graph);
            // The longest path is 4 -> 2 -> 5 -> 6 with length 4 + 2 + 1 = 7
            Assert.That(diameter, Is.EqualTo(10));
        }

        [Test]
        public void TreeDiameterDirected_Test()
        {
            var graph = new Dictionary<int, List<(int, int)>>
            {
                { 1, new List<(int, int)> { (2, 2), (3, 10) } }, // 1 connects to 2 (w=2) and 3 (w=10)
                { 2, new List<(int, int)> { (4, 1), (5, 5) } },  // 2 connects to 4 (w=1) and 5 (w=5)
                                                                 // Nodes 3, 4, 5 are leaves (no entries or empty lists)
            };

            int diameter = DiameterOps.TreeDiameterDirected(graph);

            // A single node tree has a diameter of 0
            Assert.That(diameter, Is.EqualTo(17));
        }
    }
}
