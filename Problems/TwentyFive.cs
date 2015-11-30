using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace ProjectEuler.Problems
{
    public class TwentyFive
    {
        public static long Go()
        {
            var list = new List<BigInteger>();
            var targetLength = 1000;

            list.Add(1);
            list.Add(1);

            while (list.Last().ToString().Length < targetLength)
            {
                var next2Last = list[list.Count - 2];
                var last = list.Last();

                list.Add(next2Last + last);
            }

            return list.Count;
        }
    }
}
