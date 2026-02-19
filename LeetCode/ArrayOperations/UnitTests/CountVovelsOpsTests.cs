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
    public class CountVovelsOpsTests
    {
        [TestCase("aeiouu", 2)]
        [TestCase("unicornarihan", 0)]
        [TestCase("cuaieuouac", 7)]
        public void CountVowelsSubstring_Test(string s, int k)
        {
            var restul = CountVovelsOps.CountVowelsSubstring(s);

            Assert.That(restul, Is.EqualTo(k));
        }

        [TestCase("lEetcOde", "lEOtcede")]
        [TestCase("lYmpH", "lYmpH")]
        public void SortVowels_Test(string s, string expected)
        {
            // act
            var result = CountVovelsOps.SortVowels(s);

            // assert
            Assert.That(result, Is.EqualTo(expected));
        }
    }
}
