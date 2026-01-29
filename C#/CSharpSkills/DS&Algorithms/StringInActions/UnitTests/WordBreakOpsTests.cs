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
    public class WordBreakOpsTests
    {
        [Test]
        public void WordBreak_Test()
        {
            string s = "leetcode";
            var words = new List<string> { "leet", "code" };

            var isTrue = WordBreakOps.WordBreak(s, words);

            Assert.That(isTrue, Is.True);

        }

        [Test]
        public void WordBreakList_Test()
        {
            string s = "leetcode";
            var words = new List<string> { "leet", "code" };

            var list = WordBreakOps.WordBreakList(s, words);

            var str = (list != null) ? string.Join(", ", list) : " ";

            Console.WriteLine($"{str}");

        }
    }
}
