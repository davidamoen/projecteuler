using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace ProjectEuler.Problems
{
    public class TwentySix
    {
        public static long Go()
        {
            var limit = 1000;
            var largestCycle = string.Empty;
            long largestDenominator = 0;

            var list = Helpers.GetPrimesBelowN(limit);


            for (var i = 0; i < list.Count; i ++ )
            {
                var d = list[i];

                var result = Helpers.FindDecimalsAsStringForD(d);

                if (result != string.Empty)
                {
                    var pattern = Helpers.FindRecurringCycle(result);

                    if (pattern != "0" && pattern.Length >= largestCycle.Length)
                    {
                        largestCycle = pattern;
                        largestDenominator = d;
                    }
                }

            }

            return largestDenominator;
        }
    }
}
