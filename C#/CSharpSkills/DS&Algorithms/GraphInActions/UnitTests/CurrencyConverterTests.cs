using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraphInActions.UnitTests
{
    [TestFixture]
    public class CurrencyConverterTests
    {
        [Test]
        public void CurrencyConverter_Test()
        {
            var conversionList = new List<(string, string, double)>
            {
                ("A", "B", 1.10),
                ("A", "C", 2.10),
                ("A", "D", 2.64),
                ("B", "C", 2.00),
                ("B", "D", 2.40),
                ("B", "E", 4.00),
                ("C", "E", 2.10),
                ("C", "D", 1.26),
                ("F", "C", 3.00),
                ("D", "F", 2.70),
                ("F", "G", 2.00)
            };
            var result1 = CurrencyConverter.CalculateConversion("A", "E", conversionList);
            Console.WriteLine($"Path: {string.Join(" -> ", result1.path)}, Factor: {result1.factor}");

            var result2 = CurrencyConverter.CalculateConversion("F", "D", conversionList);
            Console.WriteLine($"Path: {string.Join(" -> ", result2.path)}, Factor: {result2.factor}");

            // assert
            Assert.That(result1.factor, Is.EqualTo(4.4).Within(0.0001));
            Assert.That(result2.factor, Is.EqualTo(3.78).Within(0.0001));
        }
    }
}
