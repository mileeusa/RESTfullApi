using MemMgr.src;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace MemMgr.UnitTests
{
    [TestFixture]
    public class MemoryManagerTests
    {
        [Test]
        public void AllocationTest()
        {
            var mm = new MemoryManager();
            mm.Initialize(1000);

            int a = mm.Allocate(100);
            int b = mm.Allocate(200);
            int c = mm.Allocate(900);

            Assert.That(a, Is.EqualTo(0));
            Assert.That(b, Is.EqualTo(100));
            Assert.That(c, Is.EqualTo(-1));
        }
    }
}
