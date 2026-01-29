using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StringInActions
{
    public class BinaryStringOps
    {
        public string AddBinary(string a, string b)
        {
            string result = string.Empty;
            int n = a.Length > b.Length ? a.Length : b.Length;

            int carry = 0;
            string newA = new string(a.Reverse().ToArray());
            string newB = new string(b.Reverse().ToArray());

            for (int i = 0; i < n; i++)
            {
                int bitA = (i < a.Length) ? newA[i] - '0' : 0;
                int bitB = (i < b.Length) ? newB[i] - '0' : 0;
                
                int sum = bitA + bitB + carry;
                carry = sum / 2;
                int bit = sum % 2;
                string bitStr = bit.ToString();

                result = bitStr + result;
            }

            if (carry == 1)
            {
                result = "1" + result;
            }

            return result;
        }

        public static void AddBinary_Test()
        {
            string a = "11";
            string b = "1";
            string result = new BinaryStringOps().AddBinary(a, b);
            Console.WriteLine($"AddBinary({a}, {b}) = {result}"); // Output: "100"
            a = "1010";
            b = "1011";
            result = new BinaryStringOps().AddBinary(a, b);
            Console.WriteLine($"AddBinary({a}, {b}) = {result}"); // Output: "10101"
        }
    }
}
