using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectEuler.Problems
{
    public class ThirtyFive
    {
        public static long Go()
        {

            var primes = Helpers.GetPrimesBelowN(1000000);
            var circulars = new List<long>();
            var counter = 1;
            foreach(var prime in primes)
            {
                var perms = Helpers.GetAllRotationsOfDigits((int)prime);
                // var perms = Helpers.GetAllRotationsOfDigits(5701);

                var allPermsArePrime = true;
                foreach(var perm in perms)
                {
                    var n = Helpers.GetCombinedDigitsFromList(perm, 0, perm.Count);
                    if (!Helpers.IsPrime(n))
                    {
                        allPermsArePrime = false;
                        break;
                    }
                }

                if (allPermsArePrime) circulars.Add(prime);
                Console.WriteLine(counter);
                counter++;
            }


            return circulars.Count;
        }
    }
}
