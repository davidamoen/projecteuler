using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectEuler.Problems
{
    public class One
    {

        public static long Go()
        {

            int count = 0;

            for (var i = 0; i < 1000; i++)
            {

                if (i % 3 == 0 || i % 5 == 0)
                {
                    count = count + i;
                }

            }

           return count;
        }

    }
}
