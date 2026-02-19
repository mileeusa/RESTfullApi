using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace PatternSearchInActions.src
{
    public class PatternSearchOps
    {
        //
        // The DNA sequence is composed of a series of nucleotides abbreviated as 'A', 'C', 'G', and 'T'.
        //
        // For example, "ACGAATTCCG" is a DNA sequence.
        //
        // When studying DNA, it is useful to identify repeated sequences within the DNA.
        //
        // Given a string s that represents a DNA sequence, return all the 10-letter-long
        // sequences (substrings) that occur more than once in a DNA molecule.You may
        // return the answer in any order.
        //
        // LeetCode 187. Repeated DNA Sequences
        //
        // Time complexity:  O(N)
        // Space complexity: O(N)
        //
        public static IList<string> FindRepeatedDnaSequences(string s)
        {
            if (string.IsNullOrEmpty(s) || s.Length < 10) return [];

            var result = new HashSet<string>();
            var seen = new HashSet<string>();
            
            for (int i = 0; i <= s.Length - 10; i++)
            {
                string str = s.Substring(i, 10);

                if (!seen.Add(str))
                    result.Add(str);
            }
            return result.ToList();
        }
    }
}
