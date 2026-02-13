using FluentAssertions;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;
using static Microsoft.ApplicationInsights.MetricDimensionNames.TelemetryContext;
using static NUnit.Framework.Constraints.Tolerance;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace StringInActions.src
{
    public class ParenthesisOps
    {
        //
        // Given a string s containing only three types of characters: '(', ')' and '*',
        // return true if s is valid.
        //
        // The following rules define a valid string:
        //   Any left parenthesis '(' must have a corresponding right parenthesis ')'.
        //   Any right parenthesis ')' must have a corresponding left parenthesis '('.
        //   Left parenthesis '(' must go before the corresponding right parenthesis ')'.
        //   '*' could be treated as a single right parenthesis ')' or a single left
        //   parenthesis '(' or an empty string "".
        //
        // Key idea 💡
        // Track a range of possible open parentheses counts:
        //   low = minimum possible '(' count
        //   high = maximum possible '(' count
        //
        // Process characters:
        //   '(' → low++, high++
        //   ')' → low--, high--
        //   '*' → can be (, ) or empty → low--, high++
        //
        // Rules:
        //   high < 0 → invalid immediately
        //   low never goes below 0
        //   At the end, low == 0 → valid
        //
        // LeetCode 678. Valid Parenthesis String
        //
        // Difficulty: Medium
        //
        // 
        public static bool CheckValidString(string s)
        {
            if (string.IsNullOrEmpty(s) || s.Length == 0)
            {
                return false;
            }

            int low = 0;  // minimum ')' count
            int high = 0; // maximum '(' count

            foreach(char c in s)
            {
                if (c == '(')
                {
                    low++;
                    high++;
                }
                else if (c == ')')
                {
                    low--;
                    high--;
                }
                else // '*
                {
                    low--;  // treat '*' as ')'
                    high++; // treat '*' as '('
                }

                if (high < 0)
                    return false;

                if (low < 0)
                    low = 0;
            }

            return low == 0;
        }
    }
}
