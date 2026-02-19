using GreedyOps.src;
using NUnit.Framework;

namespace GreedyOps.UnitTests
{
    [TestFixture]
    class NumberSwapOpsTests
    {
        [TestCase("5489355142", 4, 2)]
        public void GetMinSwaps_Test(string s, int k, int expected)
        {
            var result = MinSwapOps.GetMinSwaps(s, k);

            Assert.That(result, Is.EqualTo(expected));
        }
    }
}
