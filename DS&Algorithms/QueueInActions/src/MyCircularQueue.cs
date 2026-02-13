using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QueueInActions.src
{
    public class MyCircularQueue<T>
    {
        private readonly T[] data;
        private int head; // point to the front
        private int tail; // tail points to the next insertion slot.
        private int count;

        public int Capacity { get; }

        public MyCircularQueue(int size)
        {
            data = new T[size];
            Capacity = size;
            head = 0;
            tail = 0;
            count = 0;
        }

        public bool Enqueue(T item)
        {
            if (IsFull()) return false;

            data[tail] = item;
            tail = (tail + 1) % Capacity;
            count++;

            return true;
        }

        public bool Dequeue()
        {
            if (IsEmpty()) return false;

            head = (head + 1) % Capacity;
            count--;

            return true;
        }

        public T Front()
        {
            if (IsEmpty()) throw new InvalidOperationException("Queue is empty");

            return data[head];
        }

        public T Rear()
        {
            if (IsEmpty()) throw new InvalidOperationException("Queue is empty");

            return data[(tail - 1 + Capacity) % Capacity];
        }

        public bool IsEmpty() => count == 0;

        public bool IsFull()
        {
            return count == Capacity;
        }
    }
}
