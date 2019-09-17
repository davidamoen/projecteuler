using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectEuler.Problems
{
    public class OneHundredTwentyFour
    {
        public static long Go()
        {
            var list = Helpers.GetOrderedRadicals(100000);
            var result = list[10000 - 1].N;
            return result;
        }
    }

    public class OrderedRadical
    {
        public int N { get; set; }
        public long RadN { get; set; }
    }
}
