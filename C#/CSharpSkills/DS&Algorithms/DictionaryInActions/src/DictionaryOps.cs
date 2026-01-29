using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DictionaryInActions.src
{
    public class DictionaryOps
    {
        //
        // Given an array of strings words representing an English Dictionary, return the longest word in words
        // that can be built one character at a time by other words in words.
        //
        // If there is more than one possible answer, return the longest word with the smallest lexicographical
        // order.If there is no answer, return the empty string.
        //
        // Note that the word should be built from left to right with each additional character being added to
        // the end of a previous word.
        // 
        // Input: words = ["a","banana","app","appl","ap","apply","apple"]
        // Output: "apple"
        //
        // Explanation: Both "apply" and "apple" can be built from other words in the dictionary.However,
        // "apple" is lexicographically smaller than "apply".
        //
        // LeetCode: 720. Longest Word in Dictionary
        //
        // Time:  O(N)
        // Space: O(N)
        //
        public static string LongestWord(string[] words)
        {
            var wordSet = new HashSet<string>(words);

            string longestWord = "";
            foreach (string word in words)
            {
                if (word.Length < longestWord.Length || (word.Length == longestWord.Length && string.Compare(word, longestWord) > 0))
                {
                    continue;
                }

                bool allPrefixesExist = true;
                for (int k = 1; k < word.Length; k++)
                {
                    string prefix = word[..k];

                    if (!wordSet.Contains(prefix))
                    {
                        allPrefixesExist = false;
                        break;
                    }
                }
                if (allPrefixesExist)
                {
                    longestWord = word;
                }
            }
            return longestWord;
        }       
    }
}
