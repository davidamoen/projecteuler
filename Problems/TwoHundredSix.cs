using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace ProjectEuler.Problems
{
    public class TwoHundredSix
    {
        public static long Go()
        {
            //Find the unique positive integer whose square has the form 1_2_3_4_5_6_7_8_9_0,
            //where each “_” is a single digit.

            var max = 19293949596979899;

            var sqrtMax = Math.Sqrt(max);

            BigInteger top = (BigInteger)Math.Ceiling(sqrtMax);

            var match = false;
            var i = top;
            while (!match)
            {
                BigInteger sqr = BigInteger.Pow(i, 2);

                Console.WriteLine($"i = {i}, sqr = {sqr}");

                if (Helpers.IsCorrectForm_For_206(sqr))
                {
                    return (long)i * 10;
                }

                i = i - 2;
            }

            return 0;
        }


    }
}
