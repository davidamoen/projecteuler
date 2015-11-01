using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectEuler.Problems
{
    public class Ten
    {
        public static long Go()
        {
            return Helpers.FindSumofPrimesBelowN(2000000);
        }
    }
}
