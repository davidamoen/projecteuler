using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectEuler.Problems
{
    public class Two
    {

        public static long Go()
        {

            var limit = 4000000;
            var total = 0;

            var number1 = 1;
            var number2 = 2;


            while (number2 < limit)
            {

                if (number2 % 2 == 0)
                {
                    total = total + number2;
                }

                var next = number1 + number2;
                number1 = number2;
                number2 = next;
            }

            return total;
        }

    }
}
