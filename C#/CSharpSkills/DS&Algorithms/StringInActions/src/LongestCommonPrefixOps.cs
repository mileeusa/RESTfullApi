using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StringInActions.src
{
    public class LongestCommonPrefixOps
    {
        public static string LongestCommonPrefix(string[] strs)
        {
            if (strs == null || strs.Length == 0)
            {
                return "";
            }

            string shortest = strs
                .Where(x => !string.IsNullOrWhiteSpace(x))
                .OrderBy(x => x.Length)
                .First();

            for (int i = 0; i < shortest.Length; i++)
            {
                char c = shortest[i];

                foreach (var s in strs)
                {
                    if (s[i] != c)
                    {
                        return shortest.Substring(0, i);
                    }
                }
            }

            return shortest;
        }
    }
}
