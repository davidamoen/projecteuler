using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectEuler.Problems
{
    public class Sixteen
    {

        public static long Go()
        {
            return Helpers.GetSumOfDigits(Helpers.GetN2Power(2, 1000));
        }

    }
}
