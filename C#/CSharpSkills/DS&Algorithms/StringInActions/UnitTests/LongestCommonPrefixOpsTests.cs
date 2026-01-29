using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StringInActions.UnitTests
{
    [TestFixture]
    public class LongestCommonPrefixOpsTests
    {
        [Test]
        public void LongestCommonPrefix_Test1()
        {
            // arrange
            string[] strs = { "flower", "flow", "flight" };

            // act
            string result = StringInActions.src.LongestCommonPrefixOps.LongestCommonPrefix(strs);

            // assert
            Assert.That(result, Is.EqualTo("fl"));
        }

        [Test]
        public void LongestCommonPrefix_Test2()
        {
            // arrange
            string[] strs = { "dog", "racecar", "car" };
            
            // act
            string result = StringInActions.src.LongestCommonPrefixOps.LongestCommonPrefix(strs);
            
            // assert
            Assert.That(result, Is.EqualTo(""));
        }
    }
}
