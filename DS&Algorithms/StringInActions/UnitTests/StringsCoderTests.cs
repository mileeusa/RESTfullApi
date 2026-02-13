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
    public class StringsCoderTests
    {
        [Test]
        public void StringsCoder_Test()
        {
            var strs = new List<string>()
            {
                "Hello",
                "World"
            };

            var codec = new StringsCoder();
            var EncodeResult = codec.encode(strs);
            Assert.That(EncodeResult, Is.EqualTo("5#Hello5#World"));

            var decodeResult = codec.decode(EncodeResult);
            Assert.That(decodeResult, Is.EqualTo(strs));
        }
    }
}
