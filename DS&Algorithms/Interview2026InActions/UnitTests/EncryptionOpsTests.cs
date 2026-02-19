using Interview2026InActions.src;
using NUnit.Framework;
using NUnit.Framework.Legacy;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interview2026InActions.UnitTests
{
    [TestFixture]
    public class EncryptionOpsTests
    {
        [TestCase(new int[] { 2, 4, 8, 2 }, 1000, 10000, new int[] { 1, 400000 })]
        [TestCase(new int[] { 2, 4, 8, 5, 2 }, 1000, 10000, new int[] { 1, 400000 })]
        public void GetEncryptionStatus_Test(
            int[] keys, 
            int instructionCount, 
            int validityPeriod,
            int[] expoected)
        {
            var result = EncryptionOps.GetEncryptionStatus(instructionCount, validityPeriod, keys);

            Assert.That(result, Is.Not.Null);
            CollectionAssert.AreEqual(result, expoected);
        }
    }
}
