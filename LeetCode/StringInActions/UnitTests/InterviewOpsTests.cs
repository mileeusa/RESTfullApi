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
    public class InterviewOpsTests
    {
        [Test]
        public void LongestSubstring_Test()
        {
            string s = "aabcbbc";
            int k = 2;

            var res = InterviewOps.LongestSubstring(s, k);

            Assert.That(res, Is.EqualTo("aabcb"));
        }
    }
}
