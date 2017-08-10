using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectEuler.Problems
{
    public class Sixty
    {
        public static long Go()
        {
            // slow, but this works.
            var primes = Helpers.GetPrimesBelowN(10000);
            var len = primes.Count;

            for(var a = 1; a < len; a++ )
            {
                for(var b = 2* (a + 1); b < len; b++)
                {
                    Console.WriteLine(string.Format("Now testing: a = {0}, b = {1}", primes[a], primes[b]));
                    if (PrimeBothWays(primes[a], primes[b]))
                    {
                        for(var c = b + 1; c < len; c++)
                        {
                            Console.WriteLine(string.Format("Now testing: a = {0}, b = {1}, c = {2}", primes[a], primes[b], primes[c]));

                            if (PrimeBothWays(primes[a], primes[c])
                                && PrimeBothWays(primes[b], primes[c]))
                            {
                                for(var d = c + 1; d < len; d++)
                                {
                                    Console.WriteLine(string.Format("Now testing: a = {0}, b = {1}, c = {2}, d = {3}", primes[a], primes[b], primes[c], primes[d]));

                                    if (PrimeBothWays(primes[a], primes[d])
                                        && PrimeBothWays(primes[b], primes[d])
                                        && PrimeBothWays(primes[c], primes[d]))
                                    {
                                        for (var e = d + 1; e < len; e++)
                                        {
                                            Console.WriteLine(string.Format("Now testing: a = {0}, b = {1}, c = {2}, d = {3}, e = {4}", primes[a], primes[b], primes[c], primes[d], primes[e]));
                                            if (PrimeBothWays(primes[a], primes[e])
                                                && PrimeBothWays(primes[b], primes[e])
                                                && PrimeBothWays(primes[c], primes[e])
                                                && PrimeBothWays(primes[d], primes[e])
                                                )
                                            {
                                                return primes[a] + primes[b] + primes[c] + primes[d] + primes[e];
                                            }
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
            }

            return 0;
        }

        private static bool PrimeBothWays(long a, long b)
        {
            var ab = string.Format("{0}{1}", a, b);
            var ba = string.Format("{0}{1}", b, a);
            return Helpers.IsPrime(long.Parse(ab)) && Helpers.IsPrime(long.Parse(ba));
        }

    }
}
