using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace ProjectEuler.Problems
{
    public class SixtyThree
    {
        public static long Go()
        {

            // totally cheated on this one, oh well

            int result = 0;
            int lower = 0;
            int n = 1;

            while (lower < 10)
            {
                lower = (int)Math.Ceiling(Math.Pow(10, (n - 1.0) / n));
                result += 10 - lower;
                n++;
            }

            return result;
        }
    }
}
