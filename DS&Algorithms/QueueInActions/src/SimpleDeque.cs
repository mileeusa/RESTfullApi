namespace QueueInActions.src
{
    public class SimpleDequeue
    {
        private int[] arr;
        private int front;
        private int rear;
        private int size;

        public SimpleDequeue(int capacity)
        {
            arr = new int[capacity];
            front = -1;
            rear = -1;
            size = 0;
        }

        // Add to the front of the deque
        public void EnqueueFront(int value)
        {
            if (size == arr.Length)
            {
                Console.WriteLine("Queue is full");
                return;
            }

            if (front == -1) // If it's the first element
            {
                front = 0;
                rear = 0;
            }
            else if (front == 0) // Wrap around if front is at 0
            {
                front = arr.Length - 1;
            }
            else
            {
                front--;
            }
            arr[front] = value;
            size++;
        }

        // Add to the rear of the deque
        public void EnqueueRear(int value)
        {
            if (size == arr.Length)
            {
                Console.WriteLine("Queue is full");
                return;
            }
            // If it's the first element
            if (front == -1)
            {
                front = 0;
                rear = 0;
            }
            else
            {
                // Wrap around if rear is at the end
                rear = (rear + 1) % arr.Length;
            }
            arr[rear] = value;
            size++;
        }

        // Remove from the front of the deque
        public int DequeueFront()
        {
            if (size == 0)
            {
                Console.WriteLine("Queue is empty");
                return -1;
            }

            int removedValue = arr[front];
            // Only one element in the queue
            if (front == rear)
            {
                front = -1;
                rear = -1;
            }
            else
            {
                // Move the front pointer
                front = (front + 1) % arr.Length;
            }
            size--;
            return removedValue;
        }

        // Remove from the rear of the deque
        public int DequeueRear()
        {
            if (size == 0)
            {
                Console.WriteLine("Queue is empty");
                return -1;
            }

            int removedValue = arr[rear];
            // Only one element in the queue
            if (front == rear)
            {
                front = -1;
                rear = -1;
            }
            else
            {
                // Move the rear pointer
                rear = (rear - 1 + arr.Length) % arr.Length;
            }
            size--;
            return removedValue;
        }

        // Display the current elements in the deque
        public void Display()
        {
            if (size == 0)
            {
                Console.WriteLine("Queue is empty");
                return;
            }

            int i = front;
            for (int count = 0; count < size; count++)
            {
                Console.Write(arr[i] + " ");
                i = (i + 1) % arr.Length;
            }
            Console.WriteLine();
        }
    }
}
