using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectEuler.Problems
{
    public class TwentyOne
    {

        public static long Go()
        {
            var list = new List<long>();

            var limit = 10000;

            // collect all amicable numbers
            for (var i = 1; i < limit; i++)
            {

                var pair = Helpers.GetAmicablePair(i);

                if (pair.B != 0 && pair.A < limit && pair.B < limit)
                {
                    list.Add(pair.A);
                    list.Add(pair.B);
                }
            }

            // dedupe
            list = list.Distinct().ToList();

            return Helpers.GetSumOfList(list);

        }


    }
}
