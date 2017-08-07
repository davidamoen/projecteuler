using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace ProjectEuler.Problems
{
    public class FiftySix
    {
        public static long Go()
        {
            long largestSum = 0;
            for (var a = 2; a < 100; a++)
            {
                if (a % 10 == 0) continue;
                for (var b = 0; b < 100; b++)
                {
                    Console.WriteLine(string.Format("a = {0}, b = {1}", a, b));
                    var p = BigInteger.Pow(a, b);
                    var sum = Helpers.GetDigitalSum(p);
                    if (sum > largestSum)
                    {
                        largestSum = sum;
                    }
                }
            }

            return largestSum;
        }
    }
}
