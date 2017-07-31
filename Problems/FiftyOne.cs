using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectEuler.Problems
{
    public class FiftyOne
    {
        public static long Go()
        {
            var notFound = true;
            long currentPrime = 56003;
            var digits = new List<string>() { "0", "1", "2", "3", "4", "5", "6", "7", "8", "9" };
            while (notFound)
            {
                currentPrime = Helpers.GetNextPrime(currentPrime);
                Console.WriteLine("CurrentPrime: {0}", currentPrime);
                var cpStr = currentPrime.ToString();
                var distinct = cpStr.Distinct().ToList();

                foreach (var ch in distinct)
                {
                    var misses = 0;
                    var chStr = ch.ToString();
                    var list = new List<long>() { currentPrime };

                    foreach (var digit in digits)
                    {
                        if (misses > 2) break;

                        if (chStr == digit) continue;

                        var replacement = long.Parse(cpStr.Replace(chStr, digit));

                        if (replacement.ToString().Length != cpStr.Length) continue;

                        if (Helpers.IsPrime(replacement))
                        {
                            list.Add(replacement);
                            Console.WriteLine("Replacement: {0}", replacement);
                        }
                        else misses++;
                    }
                    Console.WriteLine("List length: {0}", list.Count);
                    if (list.Count == 8)
                    {
                        Console.WriteLine("List length: {0}", list.Count);
                        return list[0];
                    }
                }
            }

            return 0;
        }
    }
}
