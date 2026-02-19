using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecursiveInActions.src
{
    public class ParentheseOps
    {
        // implement an algorithm to print all valid (properly opened and closed) combinations of n pairs of parentheses
        //
        public static IList<string> GenerateAllParentheses(int n)
        {
            char[] str = new char[n * 2]; // old the opened/closed parenthesis
            var result = new List<string>();
            AddParen(0, n, n, str, result);
            return result;
        }

        private static void AddParen(int index, int left /* '(' */, int right /* ')' */, char[] str, List<string> list)
        {
            if (left < 0 || right < left) return; // invalid state

            if (left == 0 && right == 0)
            {
                list.Add(new string(str));
            }
            else
            {
                str[index] = '(';
                AddParen(index + 1, left - 1, right, str, list);

                str[index] = ')';
                AddParen(index + 1, left, right - 1, str, list);
            }
        }
    }
}
