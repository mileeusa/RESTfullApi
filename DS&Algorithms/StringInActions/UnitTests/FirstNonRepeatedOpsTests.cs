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
    public class FirstNonRepeatedOpsTests
    {
        [Test]
        public void FirstNonRepeated_Test1()
        {
            // arrange
            string input = "Swiss";
            // act
            char result = FirstNonRepeatedOps.FirstNonRepeated(input);
            // assert
            Assert.That(result, Is.EqualTo('w'));
        }

        [Test]
        public void FirstNonRepeated_Test2()
        {
            // arrange
            string input = "repeated";
            // act
            char result = FirstNonRepeatedOps.FirstNonRepeated_UsingLINQ(input);

            // assert
            Assert.That(result, Is.EqualTo('r'));
        }
    }
}
