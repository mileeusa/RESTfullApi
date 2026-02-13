using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.ConstrainedExecution;
using System.Text;
using System.Threading.Tasks;

namespace GraphInActions.src
{
    public class WordsMessinessOps
    {
        //
        // Word Wrap / Text Justification (Minimum Raggedness)
        //
        // Given:
        //   words[]: an array of strings
        //   maxWidth: maximum characters per line
        //
        // Rules:
        //   Words cannot be split
        //   Words in a line are separated by one space
        //   The last line has zero messiness penalty
        //
        // Return the minimum total messiness, not the lines themselves
        //
        // Messiness of a line:
        //   (maxWidth - lineLength)²
        //
        // Time complexcity:  O(N^2)
        // Space complexcity: O(N)
        //
        public static int MinimizeMessiness(string[] words, int maxWidth)
        {
            int n = words.Length;
            var dp = new int[n + 1]; // dp[i] - minimum messiness for words from index i to the end
            Array.Fill(dp, int.MaxValue);

            for (int i = n - 1; i >= 0; i--)
            {
                int lineLength = 0;
                for (int j = i; j < n; j++)
                {
                    lineLength += words[j].Length;
                    if (j > i)
                        // append the tail space
                        lineLength++;

                    if (lineLength > maxWidth)
                        break;

                    int cost = (j == n - 1) ? 0 : (maxWidth - lineLength) * (maxWidth - lineLength);

                    // words[i], words[i+1], ..., words[j], so dp[j+1] is the possible cost of the remaining words
                    dp[i] = Math.Min(dp[i], dp[j + 1] + cost);
                }
            }

            return dp[0];
        }
    }
}
