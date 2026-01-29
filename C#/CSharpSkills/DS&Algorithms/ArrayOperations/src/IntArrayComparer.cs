using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArrayInActions.src
{
    public class IntArrayComparer : IEqualityComparer<int[]>
    {
        public bool Equals(int[]? x, int[]? y)
        {
            if (ReferenceEquals(x, y)) return true;

            if (x == null || y == null || x.Length != y.Length) return false;

            for (int i = 0; i < x.Length; i++)
            {
                if (x[i] != y[i])
                    return false;
            }

            return true;
        }

        public int GetHashCode(int[] arr)
        {
            if (arr == null) return 0;

            unchecked
            {
                int hash = 17;
                foreach(var x in arr)
                {
                    hash = hash * 31 + x;
                }

                return hash;
            }
        }
    }
}
