using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Drawing;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace StringInActions
{
    public class ValidateOps
    {
        public static bool IsValid(string s)
        {
            if (string.IsNullOrWhiteSpace(s))
                return false;

            Stack<char> stack = new Stack<char>();

            for (int i = 0; i < s.Length; i++)
            {
                char cur = s[i];

                if (stack.Count == 0)
                {
                    stack.Push(cur);
                }
                else
                {

                    if ((cur == ')' && stack.Peek() == '(')
                        || (cur == ']' && stack.Peek() == '[')
                        || (cur == '}' && stack.Peek() == '{'))
                    {
                        stack.Pop();
                    }
                    else
                    {
                        stack.Push(cur);
                    }
                }
            }

            return stack.Count == 0;
        }

        public static void ValidateOps_Test()
        {
            string s = "{[()]}";
            bool isValid = ValidateOps.IsValid(s);
            Console.WriteLine();
            Console.WriteLine($"Is the string \"{s}\" valid? {isValid}"); // Output: True
        }
    }
}
