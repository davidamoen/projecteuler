using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectEuler.Problems
{
    public class FortySix
    {
        public static long Go()
        {

            var notFound = true;
            var n = 9;

            while (notFound)
            {
                n = n + 2;
                if (!Helpers.IsPrime(n))
                {
                    Console.WriteLine(n);
                    var primes = Helpers.GetPrimesBelowN(n);
                    primes.Remove(2);

                    var conjecturePasses = false;
                    foreach(var prime in primes)
                    {
                        var diff = n - prime;
                        var half = diff / 2;
                        if (Helpers.IsSquare(half))
                        {
                            conjecturePasses = true;
                            break;
                        }
                    }

                    if (!conjecturePasses)
                    {
                        return n;
                    }
                }
            }

            return 0;
        }
    }
}
