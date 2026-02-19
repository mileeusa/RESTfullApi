using ArrayInActions.src;
using NUnit.Framework;
using NUnit.Framework.Constraints;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArrayInActions.UnitTests
{
    [TestFixture]
    public class IntervalOpsTests
    {
        [Test]
        public void Insert_Test_1()
        {
            var intervals = new int[][] { [1, 3], [6, 9] };

            var newInterval = new int[] { 2, 5 };

            var result = IntervalOps.Insert(intervals, newInterval);
        }

        [Test]
        public void Insert_Test_2()
        {
            var intervals = new int[][] { [1, 2], [3, 5], [6, 7], [8, 10], [12, 16] };

            var newInterval = new int[] { 4, 8 };

            var result = IntervalOps.Insert(intervals, newInterval);
        }

        [Test]
        public void MergeArrays_Test()
        {
            // arrange
            var intervals = new int[][]
            {
                [1,3],
                [2,6],
                [8,10],
                [15,18]
            };

            // act
            var newIntervals = IntervalOps.Merge(intervals);

            // expected merged intervals:
            //
            //  [1,6],
            //  [8,10],
            //  [15,18]
            //
            // assert
            Assert.That(newIntervals.Length, Is.EqualTo(3));
        }

        [Test]
        public void EraseOverlapIntervals_Test()
        {
            // arrange
            var intervals = new int[][]
            {
                [1,2], [2,3], [3,4], [1,3]
            };

            // act
            var result = IntervalOps.EraseOverlapIntervals(intervals);

            Assert.That(result, Is.EqualTo(1));
        }
    }
}
