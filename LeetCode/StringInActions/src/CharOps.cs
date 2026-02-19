using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StringInActions.src
{
    public class CharOps
    {
        public static string ToUpper(string s)
        {
            var chars = s.ToArray();
            for (int i = 0; i < chars.Length; i++)
            {
                char c = chars[i];

                if (c >= 'a' && c <= 'z')
                    chars[i] = (char)(c & ~0x20); // 0100 0001 ('A') => 0110 0001 ('a') // 0x20 = 0010 0000 => ~0x20 = 1101 1111
            }

            return new string(chars);
        }

        public static string ToUpper_II(string s)
        {
            var chars = s.ToArray();
            for (int i = 0; i < chars.Length; i++)
            {
                char c = chars[i];

                if (c >= 'a' && c <= 'z')
                    chars[i] = (char)(c - ('a' - 'A'));
            }

            return new string(chars);
        }
    }
}
