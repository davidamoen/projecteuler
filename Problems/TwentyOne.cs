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

                if (pair.b != 0 && pair.a < limit && pair.b < limit)
                {
                    list.Add(pair.a);
                    list.Add(pair.b);
                }
            }

            // dedupe
            list = list.Distinct().ToList();

            return Helpers.GetSumOfList(list);

        }


    }
}
