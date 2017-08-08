using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace ProjectEuler.Problems
{
    public class FiftySeven
    {
        public static long Go()
        {
            BigInteger num = 3;
            BigInteger den = 2;
            BigInteger prevNum = 1;
            BigInteger prevDen = 1;
            var expansions = 2;
            var counter = 0;

            while (expansions < 1000)
            {
                BigInteger tmpNum = num;
                BigInteger tmpDen = den;
                num = (num * 2) + prevNum;
                den = (den * 2) + prevDen;
                // decimal ans = (decimal)num / (decimal)den;

                // Console.WriteLine(ans);

                prevNum = tmpNum;
                prevDen = tmpDen;

                if (num.ToString().Length > den.ToString().Length)
                {
                    counter++;
                }

                expansions++;
            }
            return counter;
        }
    }
}
