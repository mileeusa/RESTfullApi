using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArrayInActions.src
{
    public class SlidingWindowOps
    {
        //
        // You are given an array of integers nums, there is a sliding window of size k
        // which is moving from the very left of the array to the very right. You can
        // only see the k numbers in the window. Each time the sliding window
        // moves right by one position.
        //
        // Return the max sliding window.
        //
        // LeetCode: 239. Sliding Window Maximum
        //
        // Difficulty: Hard
        //
        public static int[] MaxSlidingWindow_Dequeue(int[] nums, int k)
        {
            if (nums == null || nums.Length == 0 || k == 0)
                return Array.Empty<int>();

            int n = nums.Length;
            int[] result = new int[n - k + 1];
            var deque = new LinkedList<int>(); // store indices

            for (int i = 0; i < n; i++)
            {
                // Remove indices outside the window
                if (deque.Count > 0 && deque.First!.Value <= i - k)
                {
                    deque.RemoveFirst();
                }

                // Maintain decreasing order
                while (deque.Count > 0 && nums[deque.Last!.Value] < nums[i])
                {
                    deque.RemoveLast();
                }

                deque.AddLast(i);

                if (i >= k - 1)
                    result[i - k + 1] = nums[deque.First!.Value];
            }

            return result;
        }

        //
        // You are given an array of integers nums, there is a sliding window of size k
        // which is moving from the very left of the array to the very right. You can
        // only see the k numbers in the window. Each time the sliding window
        // moves right by one position.
        //
        // Return the max sliding window.
        //
        // LeetCode: 239. Sliding Window Maximum
        //
        // Difficulty: Hard
        //
        public static int[] MaxSlidingWindow(int[] nums, int k)
        {
            if (nums == null || nums.Length == 0 || k == 0) return [];

            int n = nums.Length;
            int[] result = new int[n - k + 1];

            for (int i = 0; i < n - k + 1; i++)
            {
                int max = nums[i];
                for (int j = 0; j < k; j++)
                {
                    max = Math.Max(max, nums[i + j]);
                }

                result[i] = max;
            }            

            return result;
        }
    }
}
