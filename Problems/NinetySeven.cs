using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace ProjectEuler.Problems
{
    public class NinetySeven
    {
        public static long Go()
        {
            long mod = 10000000000;
            BigInteger result = 28433 * BigInteger.ModPow(2, 7830457, mod) + 1;
            result %= mod;

            return (long)result;
        }
    }
}
