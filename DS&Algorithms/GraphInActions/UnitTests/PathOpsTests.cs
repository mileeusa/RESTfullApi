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
    public class PathOpsTests
    {
        [Test]
        public void ShortestPathUnweighted_Test()
        {
            var graph = new Dictionary<int, List<int>>()
            {
                { 1, new List<int> {2, 3} },
                { 2, new List<int> { 4 } },
                { 3, new List<int> { 4 } },
                { 4, [] }
            };

            var paths = PathOps.ShortestPathUnweighted(graph, 1, 4);

            Assert.That(paths.Count, Is.EqualTo(3));
        }

        [Test]
        public void DijkstraShortestPaths_Test()
        {
            var graph = new Dictionary<int, List<(int neighbor, int weight)>>()
            {
                [1] = new() { (2, 4), (3, 1) },
                [2] = new() { (3, 1) },
                [3] = new() { (2, 2), (4, 5) },
                [4] = new() { (5, 3) },
                [5] = new() { }
            };

            var paths = PathOps.DijkstraShortestPaths(graph, 1);

            foreach(var (key, value) in paths)
            {
                Console.WriteLine($"{key} -> {value}");
            }

            // assert
            Assert.That(paths[1], Is.EqualTo(0)); // 1->1: 0
            Assert.That(paths[2], Is.EqualTo(3)); // 1->2: 3
            Assert.That(paths[3], Is.EqualTo(1)); // 1->3: 1
            Assert.That(paths[4], Is.EqualTo(6)); // 1->4: 6
            Assert.That(paths[5], Is.EqualTo(9)); // 1->5: 9
        }

        [Test]
        public void ShortestPathWeighted_Test()
        {
            var graph = new Dictionary<int, List<(int neighbor, int weight)>>()
            {
                { 0, new List<(int, int)> { (1, 3) } },
                { 1, new List<(int, int)> { (2, 4), (3, 2) } }
            };
            var paths = PathOps.ShortestPathWeighted(graph, 0, 3);
            Assert.That(paths, Is.EqualTo(5));
        }
    }
}
