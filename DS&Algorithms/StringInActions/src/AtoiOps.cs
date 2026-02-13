using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StringInActions
{
    public class AtoiOps
    {
        public static int MyAtoi(string str)
        {
            if (string.IsNullOrWhiteSpace(str))
            {
                return 0;
            }

            int i = 0;
            int n = str.Length;
            int sign = 1;

            // skip the leading spaces
            while (i < n && str[i] == ' ')
            {
                i++;
            }

            if (i == n)
            {
                return 0;
            }

            // check the optional sign
            if (str[i] == '+' || str[i] == '-')
            {
                sign = (str[i] == '-') ? -1 : 1;
                i++;
            }

            // parse the digits
            long result = 0;
            while (i < n && char.IsDigit(str[i]))
            {
                result = result * 10 + (str[i] - '0');

                if (result * sign > int.MaxValue)
                {
                    return int.MaxValue;
                }
                if (result * sign < int.MinValue)
                {
                    return int.MinValue;
                }
                i++;
            }

            return (int)(result * sign);
        }

        public static void MyAtoi_Test()
        {
            var str = "   -42";
            Console.WriteLine();
            Console.WriteLine("AtoiOps.MyAtoi");
            Console.WriteLine($"String to Integer conversion of \"{str}\": {MyAtoi(str)}");
        }
    }
}
