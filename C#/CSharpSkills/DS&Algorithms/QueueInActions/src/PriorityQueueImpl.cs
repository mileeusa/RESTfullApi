namespace QueueInActions.src
{
    public class PriorityQueueImpl<T> where T : IComparable<T>
    {
        private readonly List<T> heap = [];
        private readonly IComparer<T> comparer = Comparer<T>.Default;

        public PriorityQueueImpl() { }

        public PriorityQueueImpl(IComparer<T> comparer)
        {
            this.comparer = comparer ?? Comparer<T>.Default;
        }

        public int Count => heap.Count;

        public bool IsEmpty => heap.Count == 0;

        public void Enqueue(T item)
        {
            heap.Add(item);
            HeapifyUp(heap.Count - 1);
        }

        public T Dequeue()
        {
            if (IsEmpty)
            {
                throw new InvalidOperationException("The priority queue is empty");
            }

            T root = heap[0];
            heap[0] = heap[heap.Count - 1];
            heap.RemoveAt(heap.Count - 1);

            if (!IsEmpty)
            {
                HeapifyDown(0);
            }

            return root;
        }

        public T Peek()
        {
            if (IsEmpty)
            {
                throw new InvalidOperationException("The priority queue is empty");
            }

            return heap[0]; 
        }

        //
        // HeapifyUp (also called bubble up, sift up, percolate up) is used when you insert a new element into a heap
        // 
        // A min-heap must always satisfy the rule:
        //    Parent <= children
        //
        // When you insert a new value, it gets placed at the end of the array, but this might violate the heap rule.
        //
        // So we compare it with its parent, and if it's smaller, we swap them. We repeat this until the heap property is restored.
        //
        // 5 -> 3 -> 8 -> 2  ==> 2 -> 3 -> 5 -> 8
        //
        //   Here is the graphs to imagine adding 2:
        //
        //
        //        3                           3                         2
        //       / \                         / \                       /  \
        //     5     8   => 2 < 5 -> swap   2    8    2 < 3 -> swap   3     8
        //    /                            /                         / 
        //   2  <-- newly inserted        5                         5
        //
        private void HeapifyUp(int index)
        {
            while (index > 0)
            {
                int parent = (index - 1) / 2;
                if (comparer.Compare(heap[index], heap[parent]) >= 0)
                {
                    break;
                }

                Swap(index, parent);

                index = parent;
            }
        }

        //
        // Here are the steps to remove the root from a min-heap:
        //
        //   1. Move the last element in the heap to the root position.
        //   2. That element might be too large for the root.
        //   3. So you “push it down” the tree until the heap property is restored.
        //
        // A min-heap must always satisfy the rule:
        //    Parent <= children
        //
        // HeapifyDown ensures the parent is always smaller than its children by:
        //   - Comparing parent with its smallest child
        //   - If the parent is larger → swap them
        //   - Continue until no violations
        //
        // Let’s start with this heap (min-heap):
        //
        //          1
        //        /   \
        //       3     2
        //      / \   /
        //     5   4 6
        //
        //   Remove root (1)
        //
        //          6
        //        /   \
        //       3     2
        //      / \   
        //     5   4
        //
        //    Now run HeapifyDown(0) on 6:
        //
        //  Iteration 1
        //    Parent = 6
        //    Children = 3 (left), 2 (right)
        //    Smallest child = 2
        //
        //    Compare:
        //      6 > 2 → swap!
        //   
        //    Result:
        //
        //          2
        //        /   \
        //       3     6
        //      / \   
        //     5   4
        //
        //     New index = 2
        //
        //  Iteration 2
        //    Parent = 6
        //    Left child = (2 * 2 + 1) = 5 → does not exist
        //    Stop.
        //
        // Time: O(log n)
        //
        private void HeapifyDown(int index)
        {
            int lastIndex = heap.Count - 1;

            while (true)
            {
                int left  = index * 2 + 1;
                int right = index * 2 + 2;

                if (lastIndex < left)
                {
                    break;
                }

                // find the smallest child
                int smallest = left;
                if (right <= lastIndex && comparer.Compare(heap[right], heap[left]) < 0)
                {
                    smallest = right;
                }

                // if parent <= smallest child, stop
                if (comparer.Compare(heap[index], heap[smallest]) <= 0)
                {
                    break;
                }

                Swap(index, smallest);

                index = smallest;
            }

        }

        private void Swap(int i, int j)
        {
            T tmp = heap[i];
            heap[i] = heap[j];
            heap[j] = tmp;
        }
    }
}
