using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArrayInActions.src
{
    public class ArrangeOps
    {
        public static bool CanArrangePairs(int[] arr, int k)
        {
            var freq = new Dictionary<int, int>();

            foreach (var i in arr)
            {
                int rem = (i % k + k) % k;
                freq[rem] = freq.GetValueOrDefault(rem, 0) + 1; ;
            }

            foreach (var i in arr)
            {
                int rem = (i % k + k) % k;

                if (rem == 0)
                {
                    if (freq[rem] % 2 == 1)
                        return false;
                }

                if (freq[rem] != freq[k - rem])
                    return false;
            }

            return true;
        }
    }
}
