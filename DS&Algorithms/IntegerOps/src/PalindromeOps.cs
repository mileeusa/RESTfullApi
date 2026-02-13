using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IntegerInActions.src
{
    public class PalindromeOps
    {
        public static bool IsPalindrome(int x)
        {
            if (x < 0 || (x % 10 == 0 && x != 0))
            {
                return false;                
            }

            int reversedHalf = 0;
            while ( x > reversedHalf)
            {
                reversedHalf = reversedHalf * 10 + x % 10;
                x = x / 10;
            }

            return x == reversedHalf || x == reversedHalf / 10;
        }

        public static void IsPalindrome_Test()
        {
            int num = 121;
            Console.WriteLine();
            Console.WriteLine($"Is {num} a palindrome? {IsPalindrome(num)}");
        }
    }
}
