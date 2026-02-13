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
    public class TinyUrlOpsTests
    {
        [Test]
        public void TinyUrl_Test()
        {
            var longUrl = "http://test/html/Documents/Reditect";

            var tinyUrlOps = new TinyUrlOps();

            var shortUrl = tinyUrlOps.Encode(longUrl);

            var targetLongUrl = tinyUrlOps.Decode(shortUrl);

            Console.WriteLine($"long url: {longUrl}");
            Console.WriteLine($"short url: {shortUrl}");
            Console.WriteLine($"short url after decoded: {targetLongUrl}");

            Assert.That(targetLongUrl, Is.EqualTo(longUrl));
        }
    }
}
