using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Microsoft.ApplicationInsights.MetricDimensionNames.TelemetryContext;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace IntegerInActions.src
{
    public class RomanOps
    {
        //
        // Symbol Value:
        //
        // I	1
        // IV   4
        // V	5
        // IX   9
        // X	10
        // XL   40
        // L	50
        // XC   90
        // C	100
        // CD   400
        // D	500
        // CM   900
        // M	1000
        //
        public static string IntToRoman(int num)
        {
            int[] values =    { 1000, 900, 500, 400, 100,   90,  50,   40,  10,   9,    5,   4,    1 };
            string[] romans = { "M", "CM", "D", "CD", "C", "XC", "L", "XL", "X", "IX", "V", "IV", "I" };

            StringBuilder sb = new StringBuilder();

            for (int i = 0; i < values.Length; i++)
            {
                while (num >= values[i])
                {
                    num -= values[i];
                    sb.Append(romans[i]);
                }
            }

            return sb.ToString();
        }

        public static string IntToRoman_Table(int num)
        {
            string[] ones = { "", "I", "II", "III", "IV", "V", "VI", "VII", "VIII", "IX" };
            string[] tens = { "", "X", "XX", "XXX", "XL", "L", "LX", "LXX", "LXXX", "XC" };
            string[] hrds = { "", "C", "CC", "CCC", "CD", "D", "DC", "DCC", "DCCC", "CM" };
            string[] thus = { "", "M", "MM", "MMM" };

            return thus[num / 1000] + hrds[(num % 1000) / 100] + tens[(num % 100) / 10] + ones[(num % 10)];
        }

        // Roman numerals are represented by seven different symbols: I, V, X, L, C, D and M.
        //
        // Symbol Value
        //   I      1
        //   V      5
        //   X      10
        //   L      50
        //   C      100
        //   D      500
        //   M      1000
        //
        //   For example, 2 is written as II in Roman numeral, just two ones added together. 12 is
        //   written as XII, which is simply X + II.The number 27 is written as XXVII, which is XX + V + II.
        //
        //   Roman numerals are usually written largest to smallest from left to right. However, the
        //   numeral for four is not IIII. Instead, the number four is written as IV.Because the one is
        //   before the five we subtract it making four. The same principle applies to the number nine,
        //   which is written as IX.There are six instances where subtraction is used:
        //
        //     - I can be placed before V (5) and X(10) to make 4 and 9.
        //     - X can be placed before L(50) and C(100) to make 40 and 90.
        //     - C can be placed before D(500) and M(1000) to make 400 and 900.
        //
        //   Given a roman numeral, convert it to an integer.
        //
        public static int RomanToInt(string s)
        {
            int result = 0;
            Dictionary<char, int> map = new ()
            {
                { 'I', 1 },
                { 'V', 5 },
                { 'X', 10 },
                { 'L', 50 },
                { 'C', 100 },
                { 'D', 500 },
                { 'M', 1000 }
            };

            for (int i = 0; i < s.Length; i++)
            {
                if (i + 1 < s.Length && map[s[i]] < map[s[i+1]])
                {
                    result -= map[s[i]];
                }
                else
                {
                    result += map[s[i]];
                }
            }

            return result;
        }
    }
}
