using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArrayInActions.src
{
    public class CandiesOps
    {
        //
        // Problem: Given the array candies and the integer extraCandies,
        // where candies[i] represents the number of candies that the ith kid has.
        // For each kid, check if there is a way to distribute extraCandies among
        // the kids such that he or she can have the greatest number of candies
        // among them.
        //
        // Notice that multiple kids can have the greatest number of candies.
        //
        // LeetCode 75:
        //     1431. Kids With the Greatest Number of Candies

        public static IList<bool> KidsWithCandies(int[] candies, int extraCandies)
        {
            if (candies == null || candies.Length < 1) return [];

            var list = new List<bool>(candies.Length);
            int max = candies.Max();

            for (int i = 0; i < candies.Length; i++)
            {
                if (candies[i] + extraCandies >= max)
                    list.Add(true);
                else
                    list.Add(false);
            }

            return list;
        }
    }
}
