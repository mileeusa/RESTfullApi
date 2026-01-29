using BacktrackingInActions.src;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace BacktrackingInActions.UnitTests
{
    [TestFixture]
    public class PhoneNumberCombinationsOpsTests
    {
        [Test]
        public void LetterCombinations_Test()
        {
            string digits = "23";

            var list = PhoneNumberCombinationsOps.LetterCombinations(digits);

            // assert
            Assert.That(list.Count, Is.EqualTo(9));

        }
    }
}
