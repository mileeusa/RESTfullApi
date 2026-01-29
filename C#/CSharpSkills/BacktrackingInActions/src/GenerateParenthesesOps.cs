using System;
using System.Collections.Generic;
using System.Text;

namespace BacktrackingInActions.src
{
    public class GenerateParenthesesOps
    {
        //
        // Given n pairs of parentheses, write a function to generate all
        // combinations of well-formed parentheses.
        //
        // Example 1:
        //   Input: n = 3
        //   Output: ["((()))", "(()())", "(())()", "()(())", "()()()"]
        //
        // LeetCode 22. Generate Parentheses
        //
        // Time complexity is proportional to the Catalan number
        // 𝐶𝑛=1/(𝑛+1) * (2𝑛/𝑛), i.e. (2n)!/((n+1)! n!)
        //
        // Dificulties: Medium
        //
        public static IList<string> GenerateParenthesis(int n)
        {
            var result = new List<string>();
            Backtrack(0, 0, n, new StringBuilder(), result);

            return result;
        }

        private static void Backtrack(int open, int close, int n, StringBuilder path, IList<string> result)
        {
            if (path.Length == 2 * n)
            {
                result.Append(path.ToString());
                return;               
            }

            if (open < n)
            {
                path.Append("(");
                Backtrack(open + 1, close, n, path, result);
                path.Length--;
            }

            if (close < open)
            {
                path.Append(")");
                Backtrack(open, close + 1, n, path, result);
                path.Length--;
            }
        }

        public static IList<string> GenerateParenthesis_Iterative(int n)
        {
            var result = new List<string>();
            var stack = new Stack<(string str, int open, int close)>();
            stack.Push(("", 0, 0));

            while (stack.Count > 0)
            {
                var (str, open, close) = stack.Pop();
                if (str.Length == 2*n)
                {
                    result.Add(str);
                    continue;
                }

                if (close < open)
                {
                    stack.Push((str + ")", open, close + 1));
                }

                if (open < n)
                {
                    stack.Push((str + "(", open + 1, close));
                }
            }

            return result;
        }
    }
}
