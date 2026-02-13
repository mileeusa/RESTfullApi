using NUnit.Framework;
using RecursiveInActions.src;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecursiveInActions.UnitTests
{
    [TestFixture]
    public class ParentheseOpsTests
    {
        [TestCase(1)]
        [TestCase(2)]
        [TestCase(3)]
        [TestCase(4)]
        [TestCase(5)]
        public void GenerateAllParentheses_Test(int n)
        {
            var result = ParentheseOps.GenerateAllParentheses(n);

            foreach(var p in result)
                Console.WriteLine(p);
        }
    }
}
