using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace ProjectEuler.Problems
{
    public class TwentyNine
    {
        public static long Go()
        {
            var list = new List<BigInteger>();

            var lowerBound = 2;
            var upperBound = 100;


            for (BigInteger a = lowerBound; a <= upperBound; a++)
            {

                for (int b = lowerBound; b <= upperBound; b++)
                {
                    var power = BigInteger.Pow(a, b);
                    list.Add(power);
                }
            }

            return list.Distinct().Count();
        }
    }
}
