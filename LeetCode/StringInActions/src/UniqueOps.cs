using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StringInActions.src
{
    public class UniqueOps
    {
        //
        // Give the most efficient algorithm to determine if a string has all unique characters
        //
        // Assumption: the string consists of ASCII characters (128)
        //
        public static bool HasAllUniqueChars(string s)
        {
            if (string.IsNullOrEmpty(s)) return false;

            bool[] seen = new bool[128];

            foreach(var c in s)
            {
                if (seen[c]) return false;
                seen[c] = true;
            }

            return true;
        }
    }
}
