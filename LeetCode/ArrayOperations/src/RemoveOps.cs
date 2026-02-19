using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArrayInActions.src
{
    public class RemoveOps
    {
        public static int RemoveElement(int[] numbers, int target)
        {
            if (numbers == null || numbers.Length == 0)
            {
                return 0;
            }
            
            int idx = 0;
            for (int i = 0; i < numbers.Length; i++)
            {
                if (numbers[i] != target)
                {
                    numbers[idx++] = numbers[i];
                }
            }

            return idx;
        }        

        public static int[] RemoveDuplicated(int[] arr)
        {
            if (arr == null || arr.Length == 0)
            {
                return [];
            }

            return arr.Distinct().ToArray();
        }

        public static int[] RemoveDuplicated_2(int[] arr)
        {
            if (arr == null || arr.Length == 0)
            {
                //return new int[] { };
                return [];
            }

            var set = new HashSet<int>(arr);

            return set.ToArray();
        }

        // 
        // write efficient cpe to extract unique elements from a sorted list of array
        // e.g. (1, 1, 3, 3, 3, 5, 5, 5, 9, 9, 9) -> (1, 3, 5, 9)
        //
        public static int[] RemoveDuplicatedFromSortedArray1(int[] arr)
        {
            if (arr == null || arr.Length == 0)
            {
                return [];
            }

            int index = 0;
            for (int i = 1; i < arr.Length; i++)
            {
                if (arr[i] != arr[index])
                {
                    arr[++index] = arr[i];
                }
            }

            int[] result = new int[index + 1];
            Array.Copy(arr, result, index + 1);

            return result; // arr.Take(index + 1).ToArray();
        }

        public static int RemoveDuplicatedFromSortedArray2(int[] arr)
        {
            if (arr == null || arr.Length == 0)
            {
                return 0;
            }

            int index = 0;
            for (int i = 1; i < arr.Length; i++)
            {
                if (arr[i] != arr[index])
                {
                    arr[++index] = arr[i];
                }
            }

            return index + 1;
        }

        public static int RemoveMoreThanTwoDuplicates(int[] arr)
        {
            if (arr == null)
            {
                return 0;
            }

            if (arr.Length <= 2)
            {
                return arr.Length;
            }

            int index = 1;
            for (int i = 2; i < arr.Length; i++)
            {
                if (arr[i] != arr[index - 1])
                {
                    arr[++index] = arr[i];
                }
            }

            return index + 1;
        }

        public static int RemoveMoreThanThreeDuplicates(int[] arr)
        {

            if (arr == null || arr.Length == 0)
            {
                return 0;
            }

            int index = 2;
            for (int i = 3; i < arr.Length; i++)
            {
                if (arr[i] != arr[i - 2])
                {
                    arr[++index] = arr[i];
                }
            }

            return index + 3;
        }

        public static char[] RemoveChars(char[] arr, char[] remove)
        {
            if (arr == null || arr.Length == 0)
            {   
                return []; //return new char[] { };
            }

            if (remove == null || remove.Length == 0)
            {
                return arr;
            }

            var set = new HashSet<char>(remove);

            return arr.Where(x => !set.Contains(x)).ToArray();
        }
    }
}
