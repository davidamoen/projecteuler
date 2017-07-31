using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectEuler.Problems
{
    public class Fifty
    {
        public static long Go()
        {
            var limit = 1000000;
            var primes = Helpers.GetPrimesBelowN(limit);
            var len = primes.Count;
            var sequence = new List<long>();
            var largestSoFar = 0;

            for(var i = 0; i < 15; i++ )
            {
                for(var j = len / 10; j > 0; j--)
                {
                    Console.WriteLine(string.Format("i = {0}    j = {1}", i, j));

                    if (j < largestSoFar) continue;

                    // Console.WriteLine("j less than largestSoFar");

                    var list = primes.GetRange(i, j);
                    var sum = list.Sum();
                    //Console.WriteLine("sum = {0}", sum);
                    if (sum > limit) continue;

                    if (Helpers.IsPrime(sum))
                    {
                        sequence = list;
                        largestSoFar = j;
                    }

                }
            }


            return sequence.Sum();
        }
    }
}
