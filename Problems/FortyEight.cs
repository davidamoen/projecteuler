using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace ProjectEuler.Problems
{
    public class FortyEight
    {
        public static long Go()
        {
            BigInteger biggie = new BigInteger();
            for(int i = 1; i <= 1000; i++)
            {
                biggie = biggie + BigInteger.Pow(i, i);
            }

            var str = biggie.ToString();
            var lastTen = str.Substring(str.Length - 10);

            return long.Parse(lastTen);
        }
    }
}
