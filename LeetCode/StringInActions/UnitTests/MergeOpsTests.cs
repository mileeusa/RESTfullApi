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
    public class MergeOpsTests
    {
        [TestCase("abc", "pqr", "apbqcr")]
        public void MergeAlternately_Test(string word1, string word2, string expected)
        {  
            string result = MergeOps.MergeAlternately(word1, word2);
            Assert.That(result, Is.EqualTo(expected));
        }

        [TestCase("abc", "pqr", "abcpqr")]
        [TestCase("abe", "cqrs", "abceqrs")]
        public void MergeStringInAlphabeta_Test(string word1, string word2, string expected)
        {  
            string result = MergeOps.MergeInAlphabeta(word1, word2);
            Assert.That(result, Is.EqualTo(expected));
        }
    }
}
