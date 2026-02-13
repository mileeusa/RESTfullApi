using NUnit.Framework;
using SlidingWindowInAction.src;
using System;
using System.Collections.Generic;
using System.Text;

namespace SlidingWindowInAction.UnitTests
{
    [TestFixture] 
    public class SubsequenceOpsTests
    {
        [TestCase ("abc", "ahbgdc", true)]
        [TestCase ("axc", "ahbgdc", false)]
        public void SubsequenceOps_Test(string s, string t, bool expected)
        {
            var result = SubsequenceOps.IsSubsequence(s, t);

            Assert.That(result, Is.EqualTo(expected));
        }
    }
}
