using Microsoft.VisualStudio.TestPlatform.PlatformAbstractions.Interfaces;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IntegerInActions.src
{
    public class ReverseOps
    {
        // 
        // LeetCode 7.
        //   Reverse Integer
        //
        // Given a signed 32-bit integer x, return x with its digits reversed. If reversing x
        // causes the value to go outside the signed 32-bit integer range [-231, 231 - 1],
        // then return 0.
        //
        // Assume the environment does not allow you to store 64-bit integers(signed or unsigned).
        //
        // Time complexity:  O(logX)
        // Space complexity: O(1)
        //
        // Difficulty: Medium
        //
        public static int Reverse(int x)
        {
            int result = 0;

            while (x != 0)
            {
                int digit = x % 10;
                x /= 10;

                // check overflow
                //  2^31 - 1 =  2147483647 -- ending with 7;
                // -2^31     = -2147483648 -- ending with 8.
                //
                if (result > int.MaxValue / 10 ||
                    (result == int.MaxValue / 10 && digit > 7))
                {
                    return 0;
                }

                if (result < int.MinValue / 10 || 
                    (result == int.MinValue / 10 && digit < -8))
                {
                    return 0;
                }

                result = result * 10 + digit;
            }

            return result;

        }
    }
}
