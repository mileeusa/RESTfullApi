using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace StringInActions.src
{
    public class LongestWordOps
    {
        public static string LongestWord(string[] words)
        {
            if (words == null || words.Length == 0)
            {
                return "";
            }

            // Note: First() return the string, instead Take(1) returns IEnumerable<string>
            string longest = words
                .Where(x => !string.IsNullOrWhiteSpace(x))
                .OrderByDescending(x => x.Length)
                .First();

            return longest;
        }

        //
        // Given an array of strings words representing an English Dictionary, return the longest word
        // in words that can be built one character at a time by other words in words.
        //
        // If there is more than one possible answer, return the longest word with the smallest
        // lexicographical order.If there is no answer, return the empty string.
        //
        // Note that the word should be built from left to right with each additional character being
        // added to the end of a previous word. 
        //
        // E.g. "a" -> "ap" -> "app" -> "appl" -> "apple" => "apple"
        //
        public static string LongestBuiltWord(string[] words)
        {
            var set = new HashSet<string>(words);

            string longest = "";

            foreach(var word in words)
            {
                if (word.Length < longest.Length ||
                    (word.Length == longest.Length && string.Compare(word, longest) > 0))
                {
                    continue;
                }

                bool canBeBuilt = true;

                for (int i = 1; i <= word.Length; i++)
                {
                    string prefix = word.Substring(0, i);
                    if (!set.Contains(prefix))
                    {
                        canBeBuilt = false;
                        break;
                    }
                }

                if (canBeBuilt)
                {
                    longest = word;
                }
            }

            return longest;
        }
    }
}
