using StackInActions.src;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StackInActions.UnitTests
{
    [TestFixture]
    public class SimplifyOpsTests
    {
        [TestCase("/../", "/")]
        [TestCase("/home/", "/home")]
        [TestCase("//home/user/Documents/../Pictures", "/home/user/Pictures")]
        public void SimplifyOps_Test(string str, string expected)
        {
            var result = SimplifyOps.SimplifyPath(str);

            Assert.That(result, Is.EqualTo(expected));
        }

    }
}
