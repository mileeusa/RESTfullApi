using System;
using System.Collections.Generic;
using System.Text;

namespace SlidingWindowInAction.src
{
    public class MaxVowelOps
    {
        public static int MaxVowels(string s, int k)
        {
            var isVowels = new bool[128];

            foreach (var c in "aeiouAEIOU")
            {
                isVowels[c] = true;
            }

            int max = 0;
            int count = 0;

            for (int i = 0; i < s.Length; i++)
            {
                if (isVowels[s[i]]) count++;

                if (i >= k && isVowels[s[i - k]]) count--; // remove leftmost char

                if (i >= k - 1) max = Math.Max(max, count);
            }

            return max;
        }
    }
}
