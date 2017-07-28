using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectEuler.Problems
{
    public class FortySeven
    {
        public static long Go()
        {
            //var pf = Helpers.GetPrimeFactors(14);
            //var pf2 = Helpers.GetPrimeFactors(15);
            //var pf3 = Helpers.GetPrimeFactors(644).Distinct().ToList();
            //var pf4 = Helpers.GetPrimeFactors(645);
            //var pf5 = Helpers.GetPrimeFactors(646);

            var notFound = true;
            int n = 647;
            var list = new List<int>();

            while (notFound)
            {
                n++;
                if (has4PrimeFactors(n))
                {
                    if (has4PrimeFactors(n+1) && has4PrimeFactors(n+2) && has4PrimeFactors(n+3))
                    {
                        notFound = false;
                    }
                }
            }
            return n;
        }

        private static bool has4PrimeFactors(int n)
        {
            return Helpers.GetPrimeFactors(n).Distinct().ToList().Count == 4;
        }
    }
}
