using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassDesignInActions.src
{
    public class RandomizedSet
    {
        private readonly Dictionary<int, int> indexMap;
        private readonly List<int> list;

        public RandomizedSet()
        {
            indexMap = new Dictionary<int, int>();
            list = new List<int>();
        }

        public bool Insert(int val)
        {
            if (indexMap.TryGetValue(val, out var index))
                return false;

            indexMap[val] = list.Count; // save the index for val
            list.Add(val);
            return true;
        }

        public bool Remove(int val)
        {
            if (!indexMap.TryGetValue(val, out var index))
                return false;

            // last index and value, need to swap to index position
            int lastIndex = list.Count - 1;
            int lastVal = list[lastIndex];

            list[index] = lastVal;
            indexMap[lastVal] = index;

            // update the list and map
            list.RemoveAt(lastIndex);
            indexMap.Remove(val);

            return true;
        }

        public int GetRandom()
        {
            int idx = Random.Shared.Next(0, list.Count);
            return list[idx];
        }
    }
}
