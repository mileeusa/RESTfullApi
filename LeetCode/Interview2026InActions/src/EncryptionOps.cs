namespace Interview2026InActions.src
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
        //
        //   Hijacker’s capacity = 1000 * 10000 = 10,000,000.
        //   Since 10,000,000 ≥ 400,000, encryption can be cracked.
        //
        // Output
        //   1 400000
        //
        public static int[] GetEncryptionStatus(
            int instructionCount,
            int validityPeriod,
            int[] keys)
        {
            var map = new Dictionary<int, int>();
            foreach (var key in keys)
            {
                map[key] = map.GetValueOrDefault(key, 0) + 1;
            }

            int maxDivisibility = 0;

            foreach (var key in map.Keys)
            {
                int currentDivisibility = 0;
                for (int d = 1; d * d <= key; d++) 
                {
                    if (key % d == 0) 
                    {
                        // divisor d
                        if (map.ContainsKey(d)) {
                            currentDivisibility += map[d];
                        }

                        // other divisor
                        int other = key / d;

                        if (d != other && map.ContainsKey(other)) {
                            currentDivisibility += map[other];
                        }
                    }
                }

                maxDivisibility = Math.Max(maxDivisibility, currentDivisibility);
            }

            long strength = (long)maxDivisibility * 100000;
            long hjackerCapacity = (long)instructionCount * validityPeriod;

            int canCrack = hjackerCapacity >= strength ? 1 : 0;

            return new int[] { canCrack, (int)strength };
        }
    }
}
