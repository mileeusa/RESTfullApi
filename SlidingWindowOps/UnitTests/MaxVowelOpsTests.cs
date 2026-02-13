using NUnit.Framework;
using SlidingWindowInAction.src;
using System;
using System.Collections.Generic;
using System.Text;

namespace SlidingWindowInAction.UnitTests
{
    [TestFixture]
    public class MaxVowelOpsTests
    {
        [TestCase("abciiidef", 3, 3)]
        [TestCase("aeiou", 2, 2)]
        [TestCase("interprise", 4, 2)]
        public void MaxVowel_Test(string s, int k, int expected)
        {
            // arrange

            // act
            var result = MaxVowelOps.MaxVowels(s, k);

            // assert
            Assert.That(result, Is.EqualTo(expected));
        }

    }
}
