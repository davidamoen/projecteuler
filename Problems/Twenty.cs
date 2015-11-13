using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace ProjectEuler.Problems
{
    public class Twenty
    {
        public static long Go()
        {

            BigInteger n = Helpers.GetFactorial(100);
            return Helpers.GetSumOfDigits(n);
        }
    }
}
