using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StringInActions.UnitTests
{
    [TestFixture]
    public class TopTenMostAccessedTests
    {
        [Test]
        public void TopTenMostAccessed_Test()
        {
            // arrange
            var topTenIpAddress = MostAccessedOps.TopTenMostAccessedIPs(@"UnitTests\files\Ipaddress.txt");

            Assert.That(topTenIpAddress.Count, Is.EqualTo(10));

        }
    }
}
