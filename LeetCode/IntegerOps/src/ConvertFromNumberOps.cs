using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IntegerInActions.src
{
    public class ConvertFromNumberOps
    {
        public static Dictionary<int, string> s_NumbrtToWordMap = new ()
        {
            { 1000000000, "Billion" },
            { 1000000, "Million" },
            { 1000, "Thousand" },
            { 100, "Hundred" },
            {  90, "Ninety" },
            {  80, "Eighty" },
            {  70, "Seventy" },
            {  60, "Sixty" },
            {  50, "Fifty" },
            {  40, "Forty" },
            {  30, "Thirty" },
            {  20, "Twenty" },
            {  19, "Nineteen" },
            {  18, "Eighteen" },
            {  17, "Seventeen" },
            {  16, "Sixteen" },
            {  15, "Fifteen" },
            {  14, "Fourteen" },
            {  13, "Thirteen" },
            {  12, "Twelve" },
            {  11, "Eleven" },
            {  10, "Ten" },
            {  9, "Nine" },
            {  8, "Eight" },
            {  7, "Seven" },
            {  6, "Six" },
            {  5, "Five" },
            {  4, "Four" },
            {  3, "Three" },
            {  2, "Two" },
            {  1, "One" }
        };

        //
        // Convert a non-negative integer num to its English words representation.
        //
        // Time complexity:  O(K) <-- K the number of paires in hash table
        // Space complexity: O(logN)
        //
        // Example 1:
        //   Input: num = 123
        //   Output: "One Hundred Twenty Three"
        //
        public static string NumberToWords(int num)
        {
            if (num == 0) return "Zero";

            foreach (var (value, unit) in s_NumbrtToWordMap)
            {
                if (num >= value)
                {
                    string prefix = (value >= 100) ? NumberToWords(num / value) + " " : "";
                    string suffix = (num % value != 0) ? " " + NumberToWords(num % value) : "";

                    return prefix + unit + suffix;
                }
            }

            return "";
        }
    }
}
