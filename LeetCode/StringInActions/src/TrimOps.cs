using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StringInActions
{
    public class TrimOps
    {
        public static string TrimExtraChar(string str, char[] chars)
        {
            if (chars == null || chars.Length == 0)
            {
                return str;
            }

            return str.Trim(chars);
        }

        public static void TrimExtraChar_Test()
        {
            string str = "***Hello, World!!!***";
            char[] charsToTrim = { '*', '!' };
            string trimmedStr = TrimExtraChar(str, charsToTrim);
            Console.WriteLine();
            Console.WriteLine($"Original: '{str}'");
            Console.WriteLine($"Trimmed: '{trimmedStr}'");
        }
    }
}
