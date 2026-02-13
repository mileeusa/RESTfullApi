using Interview2026InActions.src;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interview2026InActions.UnitTests
{
    [TestFixture]
    public class SlidingWindowOpsTests
    {
        [Test]
        public void LongestSubstring_Test()
        {
            string s = "aabcbbc";
            int k = 2;

            var res = SlidingWindowOps.LongestSubstring(s, k);

            Assert.That(res, Is.EqualTo("aabcb"));
        }
    }
}
