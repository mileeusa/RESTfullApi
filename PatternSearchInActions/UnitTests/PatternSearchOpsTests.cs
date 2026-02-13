using NUnit.Framework;
using PatternSearchInActions.src;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PatternSearchInActions.UnitTests
{
    [TestFixture]
    public class PatternSearchOpsTests
    {
        [Test]
        public void FindRepeatedDnaSequences_Test()
        {
            string s = "AAAAACCCCCAAAAACCCCCCAAAAAGGGTTT";
            var expected = new List<string> { "AAAAACCCCC", "CCCCCAAAAA" };

            var result = PatternSearchOps.FindRepeatedDnaSequences(s);
            Assert.That(result, Is.EquivalentTo(expected));
        }
    }
}
