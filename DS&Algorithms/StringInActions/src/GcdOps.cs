using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StringInActions.src
{
    public class GcdOps
    {
        public static string GcdOfStrings(string str1, string str2)
        {
            if (str1 + str2 != str2 + str1) return "";

            int gcdLen = Gcd(str1.Length, str2.Length);
            return str1.Substring(0, gcdLen);
        }

        public static int Gcd(int a, int b)
        {
            while (b != 0)
            {
                int tmp = b;
                b = a % b;
                a = tmp;
            }

            return a;
        }
    }
}
