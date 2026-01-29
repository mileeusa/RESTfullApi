using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StringInActions.src
{
    public class FirstNonRepeatedOps
    {
        //
        // Find the first non-repeated character in a string
        //
        // Example:
        //   Input: "Swiss"
        //   Output: "w"
        //
        // Explanation: 's' is repeated, 'w' is the first non-repeated character.
        //
        // Time:  O(N)
        // Space: O(1) <-- since the dictionary will contain at most 26 letters
        //
        public static char FirstNonRepeated(string s)
        {
            Dictionary<char, int> cnt = new Dictionary<char, int>();

            foreach (var c in s.ToLower())
            {
                if (!cnt.TryGetValue(c, out int value))
                {
                    cnt[c] = 1;
                }
                else
                {
                    cnt[c] = ++value;
                }
            }

            foreach (var c in s.ToLower())
            {
                if (cnt.TryGetValue(c, out int f) && f == 1)
                {
                    return c;
                }
            }

            return ' ';
        }

        public static char FirstNonRepeated_UsingLINQ(string s)
        {
            return s.ToLower()
                    .GroupBy(c => c)
                    .Where(g => g.Count() == 1)
                    .Select(g => g.Key)
                    .FirstOrDefault( ' ');
        }
    }
}
