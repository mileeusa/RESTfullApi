using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace StringInActions.src
{
    public class SubstringOps
    {
        //
        // You are given a string s and an array of strings words. All the strings of words
        // are of the same length.
        //
        // A concatenated string is a string that exactly contains all the strings of any
        // permutation of words concatenated.
        //
        // For example, if words = ["ab", "cd", "ef"], then "abcdef", "abefcd", "cdabef",
        // "cdefab", "efabcd", and "efcdab" are all concatenated strings. "acdbef" is not a
        // concatenated string because it is not the concatenation of any permutation of words.
        //
        // Return an array of the starting indices of all the concatenated substrings in s.
        // You can return the answer in any order.
        //
        // Input: s = "barfoothefoobarman", words = ["foo","bar"]
        // Output: [0,9]
        //
        public static IList<int> FindSubstring(string s, string[] words)
        {
            IList<int> result = new List<int>();
            if (string.IsNullOrEmpty(s) || words == null || words.Length == 0)
            {
                return result;
            }
            int wordLength = words[0].Length;
            int wordCount = words.Length;
            int substringLength = wordLength * wordCount;

            if (s.Length < substringLength) 
            {
                return result;
            }

            Dictionary<string, int> wordMap = [];
            foreach (var word in words)
            {
                if (wordMap.TryGetValue(word, out int cnt))
                {
                    wordMap[word] = ++cnt;
                }
                else
                {
                    wordMap[word] = 1;
                }
            }

            //// the complexity of this implementation is O(n * wordCount * wordLength), which may lead to Time Limited Exceeded (TLE)
            ////
            //for (int i = 0; i <= s.Length - substringLength; i++)
            //{
            //    string substring = s.Substring(i, substringLength);
            //    Dictionary<string, int> seenWords = [];

            //    for (int j = 0; j < wordCount; j++)
            //    {
            //        string word = substring.Substring(j * wordLength, wordLength);
            //        if (wordMap.ContainsKey(word))
            //        {
            //            if (seenWords.TryGetValue(word, out int value))
            //            {
            //                seenWords[word] = ++value;
            //            }
            //            else
            //            {
            //                seenWords[word] = 1;
            //            }

            //            if (seenWords[word] > wordMap[word])
            //            {
            //                break;
            //            }
            //        }
            //        else
            //        {
            //            break;
            //        }

            //        if (j + 1 == wordCount)
            //        {
            //            result.Add(i);
            //        }
            //    }
            //}

            // Optimized implementation with sliding window, the complexity is O(n * wordLength)
            for (int i = 0; i < wordLength; i++)
            {
                int left = i;
                int right = i;
                int count = 0;
                Dictionary<string, int> seenWords = [];

                while (right + wordLength <= s.Length)
                {
                    string word = s.Substring(right, wordLength);
                    right += wordLength;

                    if (wordMap.ContainsKey(word))
                    {
                        count++;

                        if (seenWords.TryGetValue(word, out int value))
                        {
                            seenWords[word] = ++value;
                        }
                        else
                        {
                            seenWords[word] = 1;
                        }

                        // If too many of this word, shrink the window
                        while (seenWords[word] > wordMap[word])
                        {
                            string leftWord = s.Substring(left, wordLength);
                            seenWords[leftWord]--;
                            count--;
                            left += wordLength;
                        }
                        if (count == wordCount)
                        {
                            result.Add(left);

                            // Move the left side forward to find next possible answer
                            string leftWord = s.Substring(left, wordLength);
                            seenWords[leftWord]--;                            
                            left += wordLength;
                            count--;
                        }
                    }
                    else
                    {
                        seenWords.Clear();
                        count = 0;
                        left = right;
                    }
                }
            }

            return result;
        }
    }
}
