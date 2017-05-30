using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectEuler.Problems
{
    public class ThirtySeven
    {
        public static long Go()
        {
            var primes = Helpers.GetPrimesBelowNAsStrings(1000000);
            var truncatables = new List<string>();
            foreach (var prime in primes)
            {
                if (prime == "2" || prime == "3" || prime == "5" || prime == "7") continue;

                var firstDigit = prime.Substring(0, 1);
                var lastDigit = prime.Substring(prime.Length-1, 1);
                if (firstDigit != "1" && firstDigit != "2" && firstDigit != "5" && firstDigit != "3" && firstDigit != "7") continue;
                if (lastDigit != "1" && lastDigit != "3" && lastDigit != "7") continue;

                Console.WriteLine(string.Format("Prime: {0}", prime));

                var rStr = prime;
                var lStr = prime;
                var rTruncatableSoFar = true;
                var lTruncatableSoFar = true;

                while (rStr.Length > 1)
                {
                    rStr = rStr.Substring(0, rStr.Length - 1);
                    var newP = long.Parse(rStr);
                    if (!Helpers.IsPrime(newP))
                    {
                        rTruncatableSoFar = false;
                        break;
                    }
                }

                while (lStr.Length > 1)
                {
                    lStr = lStr.Substring(1);
                    var newP = long.Parse(lStr);
                    if (!Helpers.IsPrime(newP))
                    {
                        lTruncatableSoFar = false;
                        break;
                    }
                }

                if (rTruncatableSoFar && lTruncatableSoFar)
                {
                    Console.WriteLine("Adding truncatable prime: {0}", prime);
                    truncatables.Add(prime);
                }

            }

            long sum = 0;
            foreach (var tr in truncatables)
            {
                sum += long.Parse(tr);
            }

            return sum;
        }
    }
}
