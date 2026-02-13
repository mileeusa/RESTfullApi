using ArrayInActions.src;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArrayInActions.UnitTests
{
    [TestFixture]
    public class SimplifyOpsTests
    {
        [TestCase("/home/", "/home")]
        public void SimplifyOps_Test(string str, string expected)
        {
            var result = SimplifyOps.SimplifyPath(str);

            Assert.That(result, Is.EqualTo(expected));
        }

    }
}
