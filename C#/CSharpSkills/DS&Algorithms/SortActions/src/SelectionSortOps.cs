using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SortActions.src
{
    public class SelectionSortOps
    {
        //
        // Selection Sort repeatedly selects the smallest element from the unsorted portion
        // and swaps it with the
        //
        // Time: O(N^2)
        // Space: O(1)
        //
        public static void SelectionSort(int[] nums)
        {
            int n = nums.Length;

            for (int i = 0; i < n - 1; i++)
            {
                int minIdx = i;

                for (int j = i + 1; j < n; j++)
                {
                    if (nums[j] < nums[minIdx])
                    {
                        minIdx = j;
                    }
                }

                if (minIdx != i)
                {
                    (nums[i], nums[minIdx]) = (nums[minIdx], nums[i]);
                }
            }
        }

        //
        // Complexity: O(NlogN) dure to full sort
        //
        // Pros: Easy, clean
        // Cons: O(NlogN) due to full sort.
        //
        public static List<int> RetrieveTopN(List<int> list, int n)
        {
            if (list == null || n == 0)
            {
                return [];
            }

            return list
                .Distinct() // this will return the top N distinct elements
                .OrderByDescending(x => x)
                .Take(n)
                .ToList();
        }

        //
        // Optimized version — Use Min-Heap for better performance (O(N log k))
        //
        // Best for large lists when n is much smaller than list size
        //
        // Pros: Faster for huge inputs
        // Cons: Slightly more code
        // Complexity: O(NlogK)
        //
        public static List<int> RetrieveTopN_PriorityQueue(List<int> list, int k)
        {
            if (list == null || k <= 0)
            {
                return [];
            }

            var heap = new PriorityQueue<int, int>();

            foreach (var item in list)
            {
                heap.Enqueue(item, item);

                if (heap.Count > k)
                {
                    heap.Dequeue();
                }
            }

            return heap
                .UnorderedItems
                .Select(x => x.Element)
                .OrderByDescending(x => x)
                .Take(k)
                .ToList();
        }

        // Selection sort is O(N^2), which makes it inefficient to fully sorting the list
        // However, if you just need the top N elements, you don't need to sort the 
        // entire list. when K is small, it's much faster than O(N^2)
        //
        // It's also called top-N selection, or partial selection sort
        // 
        // Time complexcity: O(N x K)
        //
        public static List<int> RetrieveTopN_SelectionSort(List<int> list, int k)
        {
            if (list == null || k <= 0)
            {
                return [];
            }

            var result = new List<int>();
            var temp = new List<int>(list);

            for(int i = 0; i < k && temp.Count > 0; i++)
            {
                int maxIndex = 0;

                // we loop the rest elements to perform "select max" operation K times
                for (int j = 1; j < temp.Count; j++)
                {
                    if (temp[j] > temp[maxIndex])
                    {
                        maxIndex = j;
                    }
                }

                result.Add(temp[maxIndex]);
                temp.RemoveAt(maxIndex);
            }

            return result;
        }
    }
}
