using BacktrackingInActions.src;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace BacktrackingInActions.UnitTests
{
    [TestFixture]
    public class WordSearchFromMatrixIIOpsTests
    {
        [Test]
        public void FindWords_Test_One()
        {
            var input = new char[][]
            {
                ['o', 'a', 'a', 'n'],
                ['e', 't', 'a', 'e'],
                ['i', 'h', 'k', 'r'],
                ['i', 'f', 'l', 'v']
            };

            var words = new string[]
            {
                "oath",
                "pea",
                "eat",
                "rain" };

            var expected = new string[] { "oath", "eat" };

            var result = WordSearchFromMatrixIIOps.FindWords(input, words);

            Assert.That(result, Is.EqualTo(expected));
        }

        [Test]
        public void FindWords_Test_Two()
        {
            var input = new char[][]
            {
                ['a', 'b'],
                ['c', 'd']
            };

            var words = new string[] { "abcb" };

            var expected = new string[] { };

            var result = WordSearchFromMatrixIIOps.FindWords(input, words);

            Assert.That(result, Is.EqualTo(expected));
        }
    }
}
