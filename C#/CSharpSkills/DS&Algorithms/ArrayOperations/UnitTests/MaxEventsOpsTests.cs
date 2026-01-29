using ArrayInActions.src;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArrayInActions.UnitTests
{
    [TestFixture]
    public class MaxEventsOpsTests
    {
        [Test]
        public void MaxEvents_PQImpl_TestOne()
        {
            var events = new int[][]
            {
                [ 1, 2 ], // new int[] { 1, 2 },
                [ 3, 4 ], // new int[] { 3, 4 },
                [ 5, 6 ], // new int[] { 5, 6 }
            };

            int totalEvents = MaxEventsOps.MaxEvents_PQImpl(events);

            Console.WriteLine($"Maximum events: {totalEvents}");

            Assert.That(totalEvents, Is.EqualTo(3));
        }

        [Test]
        public void MaxEvents_PQImpl_TestTwo()
        {
            var events = new int[][]
            {
                [ 1, 2 ], // new int[] { 1, 2 },
                [ 2, 3 ], // new int[] { 2, 3 },
                [ 3, 4 ], // new int[] { 3, 4 }
            };

            int totalEvents = MaxEventsOps.MaxEvents_PQImpl(events);

            Console.WriteLine($"Maximum events: {totalEvents}");

            Assert.That(totalEvents, Is.EqualTo(3));
        }

        [Test]
        public void MaxEvents_PQImpl_TestThree()
        {
            var events = new int[][]
            {
                [ 1, 2 ], //new int[] { 1, 2 }
                [ 2, 3 ], //new int[] { 2, 3 }
                [ 3, 4 ], //new int[] { 3, 4 }
                [ 1, 2 ], //new int[] { 1, 2 }
            };

            int totalEvents = MaxEventsOps.MaxEvents_PQImpl(events);

            Console.WriteLine($"Maximum events: {totalEvents}");

            Assert.That(totalEvents, Is.EqualTo(4));
        }

        [Test]
        public void MaxEvents_PQImpl_TestFour()
        {
            var events = new int[][]
            {
                [ 1, 2 ], //new int[] { 1, 2 }
                [ 1, 2 ], //new int[] { 1, 2 }
                [ 2, 3 ], //new int[] { 2, 3 }
                [ 3, 4 ], //new int[] { 3, 4 }
            };

            int totalEvents = MaxEventsOps.MaxEvents_PQImpl(events);

            Console.WriteLine($"Maximum events: {totalEvents}");

            Assert.That(totalEvents, Is.EqualTo(4));
        }

        [Test]
        public void MaxEvents_PQImpl_TestFive()
        {
            var events = new int[][]
            {
                [ 1, 2 ],
                [ 1, 2 ],
                [ 3, 3 ],
                [ 1, 5 ],
                [ 1, 5 ],
            };

            int totalEvents = MaxEventsOps.MaxEvents_PQImpl(events);

            Console.WriteLine($"Maximum events: {totalEvents}");

            Assert.That(totalEvents, Is.EqualTo(5));
        }

        [Test]
        public void MaxEvents_PQImpl_TestSix()
        {
            var events = new int[][]
            {
                [ 1, 4 ],
                [ 4, 4 ],
                [ 2, 2 ],
                [ 3, 4 ],
                [ 1, 1 ],
            };

            int totalEvents = MaxEventsOps.MaxEvents_PQImpl(events);

            Console.WriteLine($"Maximum events: {totalEvents}");

            Assert.That(totalEvents, Is.EqualTo(4));
        }

        [Test]
        public void MaxEventsWithValue_Test()
        {
            //   Input: events = [[1,2,4],[3,4,3],[2,3,1]], k = 2
            //   Output: 7

            var events = new int[][]
            {
                [ 1, 2, 4 ],
                [ 3, 4, 3 ],
                [ 2, 3, 1 ],
            };

            int maxValue = MaxEventsOps.MaxEventsWithValue(events, 2);

            Assert.That(maxValue, Is.EqualTo(7));
        }

        [Test]
        public void MaxEventsWithValue_TestTwo()
        {
            //   Input: events =[[1,2,4],[3,4,3],[2,3,10]], k = 2
            //   Output: 10
            var events = new int[][]
            {
                [ 1, 2, 4 ],
                [ 3, 4, 3 ],
                [ 2, 3, 10 ],
            };
            
            int maxValue = MaxEventsOps.MaxEventsWithValue(events, 2);

            Assert.That(maxValue, Is.EqualTo(10));
        }

        [Test]
        public void MaxEventsWithValue_TestThree()
        {
            //   Input: events =[[1,3,4],[2,4,3],[3,5,10],[6,6,1]], k = 2
            //   Output: 11
            var events = new int[][]
            {
                [ 1, 3, 4 ],
                [ 2, 4, 3 ],
                [ 3, 5, 10 ],
                [ 6, 6, 1 ],
            };

            int maxValue = MaxEventsOps.MaxEventsWithValue(events, 2);

            Assert.That(maxValue, Is.EqualTo(11));
        }
    }
}
