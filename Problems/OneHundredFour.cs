using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectEuler.Problems
{
    public class OneHundredFour
    {
        public static long Go()
        {
            var answerFound = false;
            var k = 576;

            while (!answerFound)
            {
                var fibo = Helpers.GetFibonacciValue(k);
                Console.WriteLine(fibo.ToString());
                if (Helpers.AreFirst9DigitsPanDigital(fibo) && Helpers.AreLast9DigitsPanDigital(fibo))
                {
                    answerFound = true;
                    return k;
                }

                k++;
            }

            return k;
        }
    }
}
