using NUnit.Framework;
using RecursiveInActions.src;

namespace RecursiveInActions.UnitTests
{
    [TestFixture]
    public class DecodingOpsTests
    {
        [TestCase("12", 2)]
        [TestCase("06", 0)]
        [TestCase("10", 1)]
        public void NumDecodings_Test(string str, int expected)
        {
            var result = DecodeWaysOps.NumDecodings(str);

            Assert.That(result, Is.EqualTo(expected));
        }
    }
}
