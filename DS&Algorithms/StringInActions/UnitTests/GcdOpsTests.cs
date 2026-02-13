using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StringInActions.UnitTests
{
    [TestFixture]
    public class GcdOpsTests
    {
        [TestCase("ABCABC", "ABC", "ABC")]
        [TestCase("ABABAB", "ABAB", "AB")]
        [TestCase("LEET", "CODE", "")]
        [TestCase("AAAAAB", "AAA", "")]
        public void GcdOfStrings_Test(string str1, string str2, string expectedGcd)
        {
            // act
            string result = StringInActions.src.GcdOps.GcdOfStrings(str1, str2);

            // assert
            Assert.That(result, Is.EqualTo(expectedGcd));
        }   
    }
}
