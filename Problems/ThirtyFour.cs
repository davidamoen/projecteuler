using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace ProjectEuler.Problems
{
    public class ThirtyFour
    {
        public static long Go()
        {
            var list = new List<int>();
            var result = 0;
            for (var i = 3; i < 10000000; i++)
            {
                var digits = Helpers.GetDigits(i);
                BigInteger total = 0;
                foreach(var digit in digits)
                {
                    total += Helpers.GetFactorial(digit);
                }

                if (i == total)
                {
                    list.Add(i);
                    result += i;
                }
            }

            return result;
        }
    }
}
