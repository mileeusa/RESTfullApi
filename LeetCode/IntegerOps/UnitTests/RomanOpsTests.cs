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
    public class RomanOpsTests
    {
        [TestCase(3749, "MMMDCCXLIX")]
        public void IntToRoman_Test(int num, string expected)
        {
            // arrange

            // act 
            var roman = RomanOps.IntToRoman(num);

            // assert
            Assert.That(roman, Is.EqualTo(expected));

        }

        [TestCase(3749, "MMMDCCXLIX")]
        public void IntToRoman_Table_Test(int num, string expected)
        {
            // arrange

            // act 
            var roman = RomanOps.IntToRoman_Table(num);

            // assert
            Assert.That(roman, Is.EqualTo(expected));

        }

        [TestCase("III", 3)]
        [TestCase("LVIII", 58)]
        [TestCase("MCMXCIV", 1994)]
        public void RomanToInt_Test(string s, int expected)
        {
            // arrange
            // act
            int result = RomanOps.RomanToInt(s);

            // assert
            Assert.That(result, Is.EqualTo(expected));
        }
    }
}
