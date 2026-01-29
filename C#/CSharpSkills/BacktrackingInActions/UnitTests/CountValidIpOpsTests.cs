using BacktrackingInActions.src;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace BacktrackingInActions.UnitTests
{
    [TestFixture]
    public class CountValidIpOpsTests
    {
        [TestCase("25525511135", 2)]
        [TestCase("101023", 5)]
        [TestCase("0000", 1)]
        public void CountValidIPs_Test(string s, int expectedAddressCount)
        {
            var cnt = CountValidIpOps.CountValidIPs(s);

            // assert
            Assert.That(cnt, Is.EqualTo(expectedAddressCount));
        }
    }
}
