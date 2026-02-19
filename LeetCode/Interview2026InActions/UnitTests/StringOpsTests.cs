using NUnit.Framework;
using StringInActions.src;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interview2026InActions.UnitTests
{
    [TestFixture]
    public class StringOpsTests
    {
        [TestCase("aabcbba", 2, "aabcb")]
        public void LongestSubstring_Test(string str, int k, string expected)
        {
            // act
            var result = StringOps.LongestSubstring(str, k);

            Assert.That(result, Is.EqualTo(expected));
        }
    }
}
