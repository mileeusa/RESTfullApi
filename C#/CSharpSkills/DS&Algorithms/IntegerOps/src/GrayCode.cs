using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IntegerInActions.src
{
    public class GrayCode
    {
        public static IList<int> GenerateGrayCode(int n)
        {
            int numCodes = 1 << n; // 2^n
            List<int> grayCodes = new(numCodes);

            for (int i = 0; i < numCodes; i++)
            {
                int grayCode = i ^ (i >> 1);
                grayCodes.Add(grayCode);
            }

            return grayCodes;
        }

        public static void GenerateGrayCode_Test()
        {
            int n = 3;
            Console.WriteLine();
            Console.WriteLine("GrayCode.GenerateGrayCode for {n}:");
            Console.WriteLine($"Gray code sequence for {n} bits: [{string.Join(", ", GenerateGrayCode(n))}]");
        }
    }
}
