using NUnit.Framework;
using NUnit.Framework.Legacy;
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
        [TestCase("ABC", "ACB")]
        [TestCase("ACB", "BAC")]
        [TestCase("CBA", "ABC")]
        [TestCase("AAB", "ABA")]
        public void NextPermutation_Test(string str, string expected)
        {
            // act
            var result = PermutationOps.NextPermutation(str);

            // assert
            Assert.That(result, Is.EqualTo(expected));
        }

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
        
        [TestCase("abc", new string[] {})]
        [TestCase("aabb", new string[] { "abba", "baab"})]
        public void GeneratePalindromes_Test(string s, string[] expected)
        {
            var result = PermutationOps.GeneratePalindromes(s);

            // assert
            CollectionAssert.AreEqual(expected, result);
        }
    }
}
