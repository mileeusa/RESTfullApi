using BacktrackingInActions.src;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace BacktrackingInActions.UnitTests
{
    [TestFixture]
    public class ValidIpAddressOpsTests
    {
        [TestCase("25525511135", 2)]
        [TestCase("101023", 5)]
        [TestCase("0000", 1)]
        public void RestoreIpAddresses_Test(string s, int expectedAddressCount)
        {
            var list = ValidIpAddressOps.RestoreIpAddresses(s);

            Assert.That(list.Count, Is.EqualTo(expectedAddressCount));
        }
    }
}
