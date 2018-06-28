using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectEuler.Problems
{
    public class ThreeFiftySeven
    {
        public static long Go()
        {
            long n = 30;
            var limit = 100000000;
            var s = GetSieve(limit);
            var list = new List<long>();
            do
            {
                if (n % 2 == 0) {
                    if (Helpers.IsPrimeGenerating(n, s))
                    {
                        Console.WriteLine($"Found: {n}");
                        list.Add(n);
                    }
                }
                n++;
            } while (n < 100000000);

            return list.Sum();
        }

        private static bool[] GetSieve(long limit)
        {
            // var list = new List<bool>();
            bool[] primes = new bool[limit];
            primes = PrepopulateList(primes);

            for(var i = 3; i < limit; i++)
            {
                if (primes[i])
                {
                    var n = 2;
                    while(n * i < limit)
                    {
                        primes[n * i] = false;
                        n++;
                    } 
                }
            }

            return primes;
        }

        private static bool[] PrepopulateList(bool[] arr)
        {
            var len = arr.Length;
            arr[2] = true;
            for(var i = 3; i < len; i++)
            {
                arr[i] = i % 2 != 0;
            }
            return arr;
        }
    }
}
