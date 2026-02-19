using NUnit.Framework;
using StringInActions.src;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StringInActions.UnitTests.files
{
    [TestFixture]
    public class AnagramOpsTests
    {
        [TestCase("anagram", "nagaram", true)]
        [TestCase("rat", "car", false)]
        public void AreAnagrams_Test(string s1, string s2, bool expected)
        {
            // arrange

            // act
            bool actual = AnagramOps.AreAnagrams(s1, s2);

            // assert
            Assert.That(actual, Is.EqualTo(expected));
        }
    }
}
