using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StringInActions.src
{
    //
    // LeetCode 271. Encode and Decode Strings
    //
    public class StringsCoder
    {
        //
        // Design an algorithm to encode a list of strings to a string. The encoded string is
        // then sent over the network and is decoded back to the original list of strings.
        //
        // Encodes a list of strings to a single string.
        //
        // Difficulty: Medium
        //
        public string encode(IList<string> strs)
        {
            var sb = new StringBuilder();
            foreach (var str in strs)
            {
                sb.Append(str.Length);
                sb.Append("#");
                sb.Append(str);
            }

            return sb.ToString();
        }

        // Decodes a single string to a list of strings.
        public IList<string> decode(string s)
        {
            var result = new List<string>();
            int i = 0;

            while (i < s.Length)
            {
                int j = i;
                while (s[j] != '#')
                    j++;

                int len = int.Parse(s.Substring(i, j - i));
                j++;
                result.Add(s.Substring(j, len));

                i = j + len;
            }

            return result;
        }
    }
}
