using NUnit.Framework;
using StringInActions.src;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StringInActions.UnitTests
{
    [TestFixture]
    public class MinimumBucketsOpsTests
    {
        [TestCase (".H.H.",  1)]
        [TestCase (".HH.",   2)]
        [TestCase (".H.HH.", 2)]
        [TestCase (".HHH.", -1)]
        [TestCase (".H.HHH", -1)]
        [TestCase ("H..H", 2)]
        public void MinimumBuckets_Test(string hamsters, int expectedBuckets)
        {
            // arrange
            // act
            int result = MinimumBucketsOps.MinimumBuckets(hamsters);

            // assert
            Assert.That(result, Is.EqualTo(expectedBuckets));
        }
    }
}
