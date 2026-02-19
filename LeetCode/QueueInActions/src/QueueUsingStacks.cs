using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QueueInActions.src
{
    public class QueueUsingStacks<T>
    {
        private readonly Stack<T> inStack = new Stack<T>();
        private readonly Stack<T> outStack = new Stack<T>();

        public void Enqueue(T item)
        { 
            inStack.Push(item);
        }

        public T Peek()
        {
            if (IsEmpty())
            {
                throw new InvalidOperationException("Queue is empty");
            }

            MoveIfNeeded();
            return outStack.Peek();
        }

        public bool IsEmpty()
        {
            return inStack.Count == 0 && outStack.Count == 0;
        }

        private void MoveIfNeeded()
        {
            if (outStack.Count == 0)
            {
                while (inStack.Count > 0)
                {
                    outStack.Push(inStack.Pop());
                }
            }
        }
    }
}
