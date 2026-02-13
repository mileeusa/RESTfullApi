using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Net.Sockets;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace StringInActions.src
{
    public class MinimumBucketsOps
    {
        //
        // You are given a 0-indexed string hamsters where hamsters[i] is either:
        //
        //   'H' indicating that there is a hamster at index i, or
        //   '.' indicating that index i is empty.
        //
        // You will add some number of food buckets at the empty indices in order to feed
        // the hamsters.A hamster can be fed if there is at least one food bucket to its left
        // or to its right.More formally, a hamster at index i can be fed if you place a food bucket
        // at index i - 1 and/or at index i + 1.
        //
        // Return the minimum number of food buckets you should place at empty indices to feed
        // all the hamsters or -1 if it is impossible to feed all of them.
        //
        // LeetCode: 2086
        //
        // Here is the optimal greedy strategy:
        //   Always place a bucket on right side of a hamster if possible(i + 1 == '.').
        //   This is optimal because it might also serve the next hamster.
        //
        //   If not possible, place on the left(i - 1 == '.') — only if available.
        //
        //   If neither left nor right is '.', it's impossible.
        //
        public static int MinimumBuckets(string hamsters)
        {
            int n = hamsters.Length;
            int buckets = 0;
            int lastIndex = -2; // the index starts with 0, but we need to check i-1=-1

            for (int i = 0; i < n; i++)
            {
                if (hamsters[i] != 'H')
                    continue;

                if (lastIndex == i - 1) // This hamster is served by a bucket on the left
                {
                    continue;
                }

                if (i + 1 < n && hamsters[i + 1] == '.') // try right
                {
                    buckets++;
                    lastIndex = i + 1;

                    i += 1;
                }
                else if (i > 0 && hamsters[i - 1] == '.') // try left
                {
                    buckets++;
                    lastIndex = i - 1;
                }
                else
                {
                    // Strategy 3: Impossible to feed
                    return -1;
                }
            }

            return buckets;
        }
    }
}
