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
        //   The last line has zero messiness penalty!!!
        //
        // Return the minimum total messiness, not the lines themselves
        //
        // Messiness of a line:
        //   (maxWidth - lineLength)²
        //
        // Time complexcity:  O(N^2)
        // Space complexcity: O(N)
        //
        public static int MinimizeMessinessLastLineNoPenalty(string[] words, int maxWidth)
        {
            int n = words.Length;
            var dp = new int[n + 1]; // dp[i] - minimum messiness for words from index i to the end
            Array.Fill(dp, int.MaxValue);

            dp[n] = 0;

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

        // 
        // <<<<<< classic word wrap / text justification with minimum messiness >>>>>>
        //
        // <<<<<<<<<<<<<<<<<<< DP word wrap minimizing raggedness >>>>>>>>>>>>>>>>>>>>
        //
        // Given text, i.e. a string of words separated by single blanks, decompose the text into
        // lines such that no words is split across lines, and the messiness of the decomposition
        // is minimized.
        //
        // Each line can hold no more than a specific number of characters. write a program to
        // break the text into lines with minimized messiness
        //
        public static IList<string> MinimizeMessiness(string text, int maxWidth)
        {
            var words = text.Split(' ');
            int n = words.Length;
            var dp = new int[n + 1]; // dp[i] - minimum messiness for words [0...i-1]
            Array.Fill(dp, int.MaxValue);

            var parent = new int[n + 1];

            dp[0] = 0;

            for (int i = 1; i <= n; i++)
            {
                int lineLength = 0;
                for (int j = i - 1; j >= 0; j--)
                {
                    lineLength += words[j].Length;

                    if (j < i - 1) lineLength++;

                    if (lineLength > maxWidth) break;

                    int messiness = (maxWidth - lineLength) * (maxWidth - lineLength);

                    if (dp[i] > dp[j] + messiness)
                    {
                        dp[i] = dp[j] + messiness;
                        parent[i] = j;
                    }
                }
            }

            // reconstruct lines
            var result = new List<string>();
            int index = n;

            while (index > 0)
            {
                int start = parent[index];
                result.Add(string.Join(" ", words, start, index - start));
                index = start;
            }

            result.Reverse();

            return result;
        }
    }
}
