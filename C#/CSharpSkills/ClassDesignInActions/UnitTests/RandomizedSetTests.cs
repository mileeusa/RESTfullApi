using ClassDesignInActions.src;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassDesignInActions.UnitTests
{
    [TestFixture]
    public class RandomizedSetTests
    {
        [Test]
        public void RandomizedSet_Tests()
        {
            var randomizedSet = new RandomizedSet();
            
            var success = randomizedSet.Insert(10);
            Assert.That(success, Is.True);
         
            success = randomizedSet.Remove(12);
            Assert.That(success, Is.False);
        }
    }
}
