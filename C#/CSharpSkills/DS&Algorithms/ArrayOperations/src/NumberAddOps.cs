using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArrayInActions.src
{
    public class NumberAddOps
    {
        public static List<int> PlusOne(List<int> digits)
        {
            int n = digits.Count;

            // traverse the array from the last digit to the first
            for (int i = n - 1; i >= 0; i--)
            {
                // if the current digit is less than 9, simply increment it and return
                if (digits[i] < 9)
                {
                    digits[i]++;
                    return digits;
                }

                // if the current digit is 9, set it to 0 and continue to the next digit
                digits[i] = 0;
            }

            // if all digits were 9, we need to add a new leading 1
            digits.Insert(0, 1);

            return digits;
        } 
    }
}
