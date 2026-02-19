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
    public class CompressOpsTests
    {
        [TestCase("abbbbbbbbbbbb", "ab12")]
        [TestCase("aabcccccaaa", "a2bc5a3")]
        [TestCase("aabbccc", "a2b2c3")]
        [TestCase("aa", "a2")]
        [TestCase("a", "a")]
        public void CompressString_Test(string input, string expected)
        {
            // arrange

            // act
            var size = CompressOps.Compress(input.ToCharArray());

            // assert
            Assert.That(size, Is.EqualTo(expected.Length));
        }
    }
}
