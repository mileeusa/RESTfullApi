using System;
using System.Collections.Generic;
using System.Text;

namespace SlidingWindowInAction.src
{
    public class SubsequenceOps
    {
        public static bool IsSubsequence(string s, string t)
        {
            if (string.IsNullOrEmpty(s))
                return true;

            if (string.IsNullOrEmpty(t) || s.Length > t.Length)
                return false;

            int first = 0;
            for (int second = 0; second < t.Length && first < s.Length; second++)
            {
                if (s[first] == t[second])
                {
                    first++;
                }
            }

            return first == s.Length;

        }
    }
}
