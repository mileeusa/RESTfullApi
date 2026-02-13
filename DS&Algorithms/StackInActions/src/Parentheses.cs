using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StackInActions
{
    public class Parentheses
    {

        public static bool IsValid(string s)
        {
            if (string.IsNullOrEmpty(s))
            {
                return true;
            }
            Dictionary<char, char> map = new Dictionary<char, char>
            {
                { '(', ')' },
                { '{', '}' },
                { '[', ']' }
            };
            Stack<char> stack = new Stack<char>();
            foreach (char c in s)
            {
                if (map.ContainsKey(c))
                {
                    // If it's an opening bracket, push the corresponding closing bracket onto the stack
                    stack.Push(map[c]);
                }
                else if (map.ContainsValue(c))
                {
                    // If it's a closing bracket, check if it matches the top of the stack
                    if (stack.Count == 0 || stack.Pop() != c)
                    {
                        return false; // Mismatched or unbalanced
                    }
                }
            }
            return stack.Count == 0; // If the stack is empty, all brackets were matched
        }

        public static int LongestValidParentheses(string s)
        {
            if (string.IsNullOrEmpty(s))
            {
                return 0;
            }
            int maxLength = 0;
            var stack = new Stack<int>();
            stack.Push(-1); // Base index for valid substring calculation

            for (int i = 0; i < s.Length; i++)
            {
                if (s[i] == '(')
                {
                    stack.Push(i);
                }
                else
                {
                    stack.Pop();
                    if (stack.Count == 0)
                    {
                        stack.Push(i); // Update base index
                    }
                    else
                    {
                        maxLength = Math.Max(maxLength, i - stack.Peek());
                    }
                }
            }
            return maxLength;
        }        
    }
}
