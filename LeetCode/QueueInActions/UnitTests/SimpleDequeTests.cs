using NUnit.Framework;
using QueueInActions.src;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QueueInActions.UnitTests
{
    [TestFixture]
    public class SimpleDequeTests
    {
        [Test]
        public void SimpleDequeue_Test()
        {
            SimpleDequeue dq = new SimpleDequeue(5);

            // Adding elements to both ends
            dq.EnqueueRear(10);
            dq.EnqueueRear(20);
            dq.EnqueueFront(30);
            dq.EnqueueFront(40);
            dq.Display();

            // Removing elements from both ends
            Console.WriteLine("Dequeue from front: " + dq.DequeueFront());
            Console.WriteLine("Dequeue from rear: " + dq.DequeueRear());
            dq.Display();
        }
    }
}
