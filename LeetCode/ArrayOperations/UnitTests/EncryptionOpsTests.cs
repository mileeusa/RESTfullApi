using ArrayInActions.src;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArrayInActions.UnitTests
{
    [TestFixture]
    public class EncryptionOpsTests
    {
        [Test]
        public void GetEncryptionStatus_Test()
        {
            var nums = new int[] { 2, 4, 8, 2 };

            var result = EncryptionOps.GetEncryptionStatus(1000, 10000, nums);

            Assert.That(result.Length, Is.EqualTo(2));
            Assert.That(result[0], Is.EqualTo(1));
            Assert.That(result[1], Is.EqualTo(400000));
        }
    }
}
