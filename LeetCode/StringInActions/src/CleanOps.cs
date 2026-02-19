using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StringInActions.src
{
    public class CleanOps
    {
        //
        // given two strings s1 and s2. Delete from s2 all those characters
        // which occur in s1 also and finally create a clean s2 with
        // the relevant characters deleted
        //
        // Time complexity:  O(M+N)
        // Space complexity: O(|s1|)
        //
        public static string CleanString(string s1, string s2)
        {
            if (string.IsNullOrEmpty(s1)) return s2;
            if (string.IsNullOrEmpty(s2)) return s1;

            var charSet = new HashSet<char>(s1);

            var sb = new StringBuilder();

            foreach (var c in s2)
            {
                if (!charSet.Contains(c))
                {
                    sb.Append(c);
                }
            }

            return sb.ToString();
        }

    }
}
