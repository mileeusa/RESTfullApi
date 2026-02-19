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
    public class LongestCommonPrefixOpsTests
    {
        [Test]
        public void LongestCommonPrefix_Test1()
        {
            // arrange
            string[] strs = { "flower", "flow", "flight" };

            // act
            string result = LongestCommonPrefixOps.LongestCommonPrefix(strs);

            // assert
            Assert.That(result, Is.EqualTo("fl"));
        }

        [Test]
        public void LongestCommonPrefix_Test2()
        {
            // arrange
            string[] strs = { "dog", "racecar", "car" };
            
            // act
            string result = LongestCommonPrefixOps.LongestCommonPrefix(strs);
            
            // assert
            Assert.That(result, Is.EqualTo(""));
        }

        [Test]
        public void LongestCommonPrefix_VerticalScan_Test1()
        {
            // arrange
            string[] strs = { "flower", "flow", "flight" };

            // act
            string result = LongestCommonPrefixOps.LongestCommonPrefix_VerticalScan(strs);

            // assert
            Assert.That(result, Is.EqualTo("fl"));
        }

        [Test]
        public void LongestCommonPrefix_VerticalScan_Test2()
        {
            // arrange
            string[] strs = { "dog", "racecar", "car" };

            // act
            string result = LongestCommonPrefixOps.LongestCommonPrefix_VerticalScan(strs);

            // assert
            Assert.That(result, Is.EqualTo(""));
        }
    }
}
