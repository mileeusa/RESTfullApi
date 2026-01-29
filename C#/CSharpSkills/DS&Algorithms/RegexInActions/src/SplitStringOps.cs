using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace RegexInActions.src
{
    public class SplitStringOps
    {
        //
        // Use Regex to split a string by commas, ignoring commas inside quotes
        //
        // Example:
        //   Input:  ["John, Smith",25,Developer]
        //   Output: ["John, Smith", "25", "Developer"]
        //
        //   Input:  ["John, Doe",28,"Engineer, Software","San Jose, CA","He said, ""Hello!"""]
        //   Output: [
        //             "John, Doe",
        //             "28",
        //             "Engineer, Software",
        //             "San Jose, CA",
        //             "He said, \"Hello!\""
        //           ]
        //
        public static string[] SplitByComma(string input)
        {
            if (string.IsNullOrEmpty(input))
            {
                return Array.Empty<string>();
            }

            // This regex effectively finds commas that are outside of quoted sections
            //
            // ,                 we are matching a comma - this is our potential split point
            // ?=                is a positive lookahead assertion
            // (?:...)           A lookahead checks what comes after the comma without consuming it.
            // (?:[^"]*"[^"]*")* matches zero or more pairs of quotes with any characters except quotes in between
            // [^\"]*$           matches remaining characters after the last quote, ensuring we end on an even number of quotes
            // 
            var parts = Regex.Split(input, ",(?=(?:[^\"]*\"[^\"]*\")*[^\"]*$)", RegexOptions.Compiled);

            return parts.ToArray();
        }
    }
}
