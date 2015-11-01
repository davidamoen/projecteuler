using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectEuler.Problems
{
    public class Six
    {
        public static long Go()
        {

            long sum = 0;
            long sumOfSquares = 0;

            for (var i = 1; i <= 100; i++)
            {
                sum = sum + i;
                sumOfSquares = sumOfSquares + (i * i);
            }

            return (sum * sum) - sumOfSquares;
        }
    }
}
