using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectEuler.Problems
{
    public class Three
    {
        public static long Go()
        {

            var testNumber = 600851475143;

            var factors = Helpers.GetPrimeFactors(testNumber);

            return factors.Max();

        }
    }
}
