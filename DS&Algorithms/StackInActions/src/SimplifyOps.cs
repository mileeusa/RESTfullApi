using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StackInActions.src
{
    public class SimplifyOps
    {
        public static string SimplifyPath(string path)
        {
            if (string.IsNullOrEmpty(path) || path.Length == 0)
                return "";

            var tokens = path.Split("/", StringSplitOptions.RemoveEmptyEntries);

            var stack = new Stack<string>();

            StringBuilder sb = new StringBuilder();
            sb.Append("/");

            foreach (var token in tokens)
            {
                if (token == ".")
                    continue;

                if (token == "..")
                {
                    if (stack.Count > 0)
                        stack.Pop();
                }
                else
                {
                    stack.Push(token);
                }
            }

            if (stack.Count > 0)
            {
                var newToken = stack.ToArray();
                Array.Reverse(newToken);
                sb.Append(string.Join("/", newToken));
            }

            return sb.ToString();
        }
    }
}

