using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectEuler.Problems
{
    public class FiftyThree
    {
        public static long Go()
        {
            var count = 0;
            for (var n = 100; n > 0; n--)
            {
                for (var r = n - 1; r > 0; r--)
                {
                    if (Helpers.SelectRFromN(n, r) > 1000000) count++;
                }
            }

            return count;
        }
    }
}
