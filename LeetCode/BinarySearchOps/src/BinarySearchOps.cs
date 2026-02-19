using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;
using static Microsoft.ApplicationInsights.MetricDimensionNames.TelemetryContext;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace BinarySearchInActions.src
{
    public class BinarySearchOps
    {
        //
        // Koko loves to eat bananas. There are n piles of bananas, the ith pile
        // has piles[i] bananas. The guards have gone and will come back
        // in h hours.
        //
        // Koko can decide her bananas-per-hour eating speed of k.Each hour,
        // she chooses some pile of bananas and eats k bananas from that
        // pile.If the pile has less than k bananas, she eats all of them
        // instead and will not eat any more bananas during this hour.
        //
        // Koko likes to eat slowly but still wants to finish eating all
        // the bananas before the guards return.
        //
        // Return the minimum integer k such that she can eat all the bananas within h hours.
        //
        // LeetCode 875. Koko Eating Bananas
        //
        //
        public int MinEatingSpeed(int[] piles, int h)
        {
            if (piles == null || piles.Length == 0 || h <= 0) return 0;

            int maxPile = piles[0];
            for (int i = 1; i < piles.Length; i++)
            {
                if (maxPile < piles[i])
                {
                    maxPile = piles[i];
                }
            }

            // start binary search

            int left = 1;
            int right = maxPile;

            while (left < right)
            {
                int mid = left + (right - left) / 2;
                long hoursToSpend = 0;

                foreach (var pile in piles)
                {
                    hoursToSpend += (pile + mid - 1) / mid; // pile/mid + ((pile % mid != 0) ? 1 : 0);
                    if (hoursToSpend > h) break;
                }

                // check if the current speend is workable
                if (hoursToSpend > h)
                {
                    left = mid + 1;
                }
                else
                {
                    right = mid;
                }
            }
            return right;
        }
    }
}
