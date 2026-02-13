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
    public class DirectPathOps_CheapestFlightPath_Tests()
    {
        [Test]
        public void FindCheapestFlightPath_BellmanFord_Test()
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
            var path = DirectPathOps_CheapestFlightPath.FindCheapestFlightPath_BellmanFord(4, flights, 0, 3, 1);

            Console.WriteLine();
            Console.WriteLine(string.Join(" -> ", path));

            // assert
            Assert.That(path.Count, Is.EqualTo(3));
        }
    }
}
