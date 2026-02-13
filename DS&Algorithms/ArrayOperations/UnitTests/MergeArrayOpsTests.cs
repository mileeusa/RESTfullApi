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
    public class MergeArrayOpsTests
    {
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
            var newIntervals = MergeIntervalsOps.Merge(intervals);

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
            var result = MergeIntervalsOps.EraseOverlapIntervals(intervals);

            Assert.That(result, Is.EqualTo(1));
        }
    }
}
