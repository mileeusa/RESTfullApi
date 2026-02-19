using NUnit.Framework.Internal;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace ArrayInActions.src
{
    public class EncryptionOps
    {
        // Problem Description
        //
        // You are given:
        //   instructionCount: number of keys a hijacker can test per second
        //   validityPeriod: total time(in seconds) the encryption is valid
        //   keys[]: an array of positive integers
        //
        // You must compute:
        //   Whether a hijacker can crack the encryption within the validity period — return 1 if yes, otherwise 0.
        //   The strength of the encryption — defined as the number of keys that must be tested to break it.
        //
        // Encryption Strength Rules
        //   The degree of divisibility of an element x in keys[] is the number of elements in the
        //   array that divide x, including duplicates, and including 1 if present.
        //
        // Find the element m with the maximum degree of divisibility.
        //   Encryption strength = (degree of divisibility of m) * 100000.
        //   Suppose instructionCount * validityPeriod is totalTests.
        //
        // If totalTests >= strength, then the hijacker can crack it before expiry.
        //
        // Input
        //   instructionCount = 1000
        //   validityPeriod = 10000
        //   keys = [2, 4, 8, 2]
        //
        //   Explanation
        //     Degree of divisibility:
        //       2: divisible by[2, 2] → 2 divisors
        //       4: divisible by[2, 4, 2] → 3 divisors
        //       8: divisible by[2, 4, 8, 2] → 4 divisors
        //
        //     Max degree = 4 ⇒ strength = 4 * 100000 = 400000
        //   Hijacker’s capacity = 1000 * 10000 = 10,000,000.
        //   Since 10,000,000 ≥ 400,000, encryption can be cracked.
        // Output
        //   1 400000
        //
        public static int[] GetEncryptionStatus(int instructionCount, int validityPeriod, int[] keys)
        {
            var map = new Dictionary<int, int>();

            foreach (var key in keys)
            {
                map[key] = map.GetValueOrDefault(key, 0) + 1;
            }

            int maxDivisibility = 0;

            foreach (var key in keys)
            {
                int currentDivisibility = 0;

                for (int d = 1; d * d <= key; d++)
                {
                    if (key % d == 0)
                    {
                        if (map.ContainsKey(d))
                        {
                            currentDivisibility += 1;
                        }
                    }

                    int rem = key / d;
                    for (int k = rem; k <= key; k++)
                    {
                        if (key % k == 0)
                        {
                            if (map.ContainsKey(k))
                            {
                                currentDivisibility += map[k];
                            }
                        }
                    }
                }

                maxDivisibility = Math.Max(maxDivisibility, currentDivisibility);
            }

            int strength = maxDivisibility * 100000;
            int canCrack = (instructionCount * validityPeriod) >= strength ? 1 : 0;

            return [ canCrack, strength ];
        }
    }
}
