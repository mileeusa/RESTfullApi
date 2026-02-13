using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArrayInActions.src
{
    public class SimplifyOps
    {
        public static string SimplifyPath(string path)
        {
            if (string.IsNullOrEmpty(path) || path.Length == 0)
                return "";

            var tokens = path.Split("/", StringSplitOptions.TrimEntries);

            var stack = new Stack<string>();

            foreach (var token in tokens)
            {
                if (token == "..")
                {
                    if (stack.Count > 0)
                        stack.Pop();
                    else
                        stack.Push(token);
                }
            }

            if (stack.Count > 0)
            {
                var newToken = stack.ToArray();
                Array.Reverse(newToken);

                return string.Join("/", newToken);
            }

            return string.Empty;
        }
    }
}
