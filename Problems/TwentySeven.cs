using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectEuler.Problems
{
    public class TwentySeven
    {

        public static long Go()
        {
            var aUpperLimit = 1000;
            var bUpperLimit = 1000;
            var aLowerLimit = (aUpperLimit * -1) + 1;
            var bLowerLimit = (bUpperLimit * -1) + 1;

            var bestA = 0;
            var bestB = 0;
            var longestListCount = 0;

            for (var a = aLowerLimit; a < aUpperLimit; a++)
            {
                for (var b = bLowerLimit; b < bUpperLimit; b++)
                {
                    var list = Helpers.GetQuadraticPrimes(a, b);
                    if (list.Count > longestListCount)
                    {
                        bestA = a;
                        bestB = b;
                        longestListCount = list.Count;
                    }
                }
            }

            return bestA * bestB;
        }

    }
}
