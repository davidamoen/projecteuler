using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectEuler.Problems
{
    public class Seventeen
    {
        public static long Go()
        {

            long count = 0;

            for (var i = 1; i <= 1000; i++)
            {
                count = count + Helpers.GetNumberLetterCountforN(i);
            }

            return count;
        }
    }
}
