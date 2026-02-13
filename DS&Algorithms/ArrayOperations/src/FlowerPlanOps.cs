using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArrayInActions.src
{
    public class FlowerPlanOps
    {
        //
        // You have a long flowerbed in which some of the plots are planted, and
        // some are not. However, flowers cannot be planted in adjacent plots.
        //
        // Given an integer array flowerbed containing 0's and 1's, where 0
        // means empty and 1 means not empty, and an integer n, return true
        // if n new flowers can be planted in the flowerbed without violating
        // the no-adjacent-flowers rule and false otherwise.
        //
        // LeetCode 75
        //      605 Can Place Flowers
        //
        // Difficulty: Easy
        //
        public static bool CanPlaceFlowers(int[] flowerbed, int n)
        {
            if (n == 0) return true;
            if (flowerbed == null || flowerbed.Length == 0) return false;

            int count = 0;

            for (int i = 0; i < flowerbed.Length; i++)
            {
                if (flowerbed[i] == 0)
                {
                    int left = (i == 0) ? 0 : flowerbed[i - 1];
                    int right = (i == flowerbed.Length - 1) ? 0 : flowerbed[i + 1];

                    if (left == 0 && right == 0)
                    {
                        flowerbed[i] = 1;
                        count++;

                        if (count >= n) return true;
                    }
                }
            }

            return false;
        }

        public static bool CanPlaceFlowers_NonIntrusive(int[] flowerbed, int n)
        {
            if (n == 0) return true;
            if (flowerbed == null || flowerbed.Length == 0) return false;

            int count = 0;
            int prev = 0;

            for (int i = 0; i < flowerbed.Length; i++)
            {
                int curr = flowerbed[i];
                int next = (i == flowerbed.Length - 1) ? 0 : flowerbed[i + 1];

                if (prev == 0 && curr == 0 && next == 0)
                {
                    prev = 1; // simulate the flower to be planned here
                    count++;

                    if (count >= n) return true;
                }
                else
                {
                    prev = flowerbed[i];
                }
            }

            return false;

        }
    }
}
