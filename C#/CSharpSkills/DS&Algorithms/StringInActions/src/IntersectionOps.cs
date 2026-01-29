using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StringInActions.src
{
    public class IntersectionOps
    {
        //
        // Implement an algorithm that takes two strings as input, and returns
        // the intersection of the two, with each letter represented at most once.
        //
        // Time:
        //   Build sets: O(M+N)
        //   Intersect:  O(min(M, N))
        //   Overall:    O(M+N)
        //
        // Space: 
        //   Two hash sets: O(M+N)
        //
        public static string? IntersectStrings(string a, string b)
        {
            if (string.IsNullOrEmpty(a) || string.IsNullOrEmpty(b))
                return string.Empty;

            var setA = new HashSet<char>(a);
            var setB = new HashSet<char>(b);

            return new string(setA.Intersect(setB).ToArray());
        }

        //
        // This version keeps characters in the order they appear in a
        //
        public static string IntersectStrings_PreserveOrder(string a, string b)
        {
            if (string.IsNullOrEmpty(a) || string.IsNullOrEmpty(b))
                return string.Empty;

            var setB = new HashSet<char>(b);
            var seen = new HashSet<char>();

            var result = new List<char>();

            foreach (char c in a)
            {
                if (setB.Contains(c) && seen.Add(c))
                {
                    result.Add(c);
                }
            }

            return new string(result.ToArray());
        }
    }
}
