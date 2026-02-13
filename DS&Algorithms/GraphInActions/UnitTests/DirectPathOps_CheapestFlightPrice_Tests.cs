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
    public class DirectPathOps_CheapestFlightPrice_Tests
    {
        [Test]
        public void FindCheapestPrice_BFS_Test()
        {
            var flights = new int[][]
            {
               [ 0, 1, 100 ],
               [ 1, 2, 100 ],
               [ 2, 0, 100 ],
               [ 1, 3, 600 ],
               [ 2, 3, 200 ]
            };

            // act
            int minCost = DirectedGraph_BFS_CheapestFlightPrice.FindCheapestPrice_BFS(4, flights, 0, 3, 1);

            // assert
            Assert.That(minCost, Is.EqualTo(700));
        }

        [Test]
        public void FindCheapestPrice_BellmanFord_Test()
        {
            var flights = new int[][]
            {
               [ 0, 1, 100 ],
               [ 1, 2, 100 ],
               [ 2, 0, 100 ],
               [ 1, 3, 600 ],
               [ 2, 3, 200 ]
            };

            // act
            int minCost = DirectedGraph_BFS_CheapestFlightPrice.FindCheapestPrice_BellmanFord(4, flights, 0, 3, 1);

            // assert
            Assert.That(minCost, Is.EqualTo(700));
        }
    }
}
