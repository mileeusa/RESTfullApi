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
    public class OrderlyOpsTests
    {
        [Test]
        public static void OrderlyQueue_Test()
        {
            string s = "baaca";
            int k = 3;

            var result = OrderlyOps.OrderlyQueue(s, k);
            Console.WriteLine("OrderlyQueue");
            Console.WriteLine($"Original: {s}, Orderly: {result}");

            Assert.That(result, Is.EqualTo("aaabc"));
        }
    }
}
