using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectEuler.Problems
{
    public class FortyNine
    {
        public static long Go()
        {
            var bottomLimit = 1489;
            var topLimit = 10000;
            var primes = Helpers.GetPrimesBetweenMandN(bottomLimit, topLimit);
            var len = primes.Count;

            for(var i = 0; i < len; i++)
            {
                var primeI = primes[i];
                var perms = getPermsFromList(primeI);

                for (var j = i + 1; j < len; j++)
                {
                    var primeJ = primes[j];

                    // is it a permutation?
                    if (perms.IndexOf(primeJ) >= 0)
                    {
                        // get the spacing
                        var spacing = primeJ - primeI;

                        // what's the third one?
                        var third = primeJ + spacing;

                        // is it prime and a perm?
                        if (Helpers.IsPrime(third) & perms.IndexOf(third) >= 0)
                        {
                            return long.Parse(string.Format("{0}{1}{2}", primeI, primeJ, third));
                        }
                    }
                }
            }

            return 0;
        }

        private static List<long> getPermsFromList(long n)
        {
            var list = new List<long>();
            var perms = Helpers.GetAllPermutationsOfDigits((int)n);

            foreach(var p in perms)
            {
                var num = Helpers.GetNumberFromList(p);
                if (num >= 1000) list.Add(num);
            }
            return list.Distinct().OrderBy(x => x).ToList();
        }
    }
}
