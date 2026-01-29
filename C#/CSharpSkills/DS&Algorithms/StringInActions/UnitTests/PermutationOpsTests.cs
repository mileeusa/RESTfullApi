using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StringInActions.UnitTests
{
    [TestFixture]
    public  class PermutationOpsTests
    {
        [Test]
        public void Permutation_Test()
        {
            string s = "abc";
            List<string> p = new List<string>();
            PermutationOps.Permutation(s, "", p);
            
            Console.WriteLine($"All the permutations of string \"{s}\" are: ");
            foreach (var item in p)
            {
                Console.WriteLine(item);
            }
        }

        [TestCase("ab", "ab", true)]
        [TestCase("ab", "eidbaooo", true)]
        [TestCase("ab", "eidboaoo", false)]
        [TestCase("hello", "ooolleoooleh", false)]
        public void CheckInclusion_Test(string s1, string s2, bool isTrue)
        {
            // act
            var res = PermutationOps.CheckInclusion(s1, s2);

            Assert.That(res, Is.EqualTo(isTrue));
        }

        [TestCase("ab", "ab", true)]
        [TestCase("ab", "eidbaooo", true)]
        [TestCase("ab", "eidboaoo", false)]
        [TestCase("hello", "ooolleoooleh", false)]
        public void CheckInclusion_SlidingWindow_Test(string s1, string s2, bool isTrue)
        {
            // act
            var res = PermutationOps.CheckInclusion_SlidingWindow(s1, s2);

            Assert.That(res, Is.EqualTo(isTrue));
        }
    }
}
