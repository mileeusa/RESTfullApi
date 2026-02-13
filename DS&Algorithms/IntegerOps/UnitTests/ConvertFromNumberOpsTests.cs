using IntegerInActions.src;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IntegerInActions.UnitTests
{
    [TestFixture]
    public class ConvertFromNumberOpsTests
    {
        [TestCase(234)]
        [TestCase(12345)]
        public void NumberToWords_Test(int num)
        {
            var str = ConvertFromNumberOps.NumberToWords(num);
            Console.WriteLine($"{num} => {str}");
        }
    }
}
