using ProjectEuler.Problems;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Numerics;

namespace ProjectEuler
{
    public class Helpers
    {

        public static List<long> GetPrimeFactors(long n)
        {

            var factors = new List<long>();
            var currentN = n;

            while (!IsPrime(currentN))
            {

                var smallestFactor = GetSmallestFactor(currentN);

                factors.Add(smallestFactor);

                currentN = currentN / smallestFactor;

            }

            if (currentN != n) factors.Add(currentN);

            return factors;

        }


        public static bool IsPrime(long n)
        {
            for (var i = 2; i <= Math.Sqrt(n); i++)
            {
                if (n % i == 0) return false;
            }
            return true;
        }

        private static long GetSmallestFactor(long n)
        {
            for (var i = 2; i <= n; i++)
            {
                if (n % i == 0) return i;
            }

            return n;
        }

        public static bool IsPalindrome(long n)
        {

            var nStr = n.ToString();
            var nStrRev = new string(nStr.Reverse().ToArray());

            return nStr == nStrRev;
        }

        public static bool IsMultipleOfAllNumbers(long n, List<int> numbers)
        {
            var rtn = true;
            foreach (var number in numbers)
            {
                if (n % number != 0)
                {
                    rtn = false;
                    break;
                }
            }

            return rtn;
        }

        public static long GetNthPrime(int n)
        {
            var primes = new List<long> { 2 };
            while (primes.Count < n)
            {
                var currentPrime = primes.Last();
                primes.Add(GetNextPrime(currentPrime));
            }
            return primes.Last();

        }

        public static long GetNextPrime(long n)
        {
            var current = n + 1;
            while (!IsPrime(current))
            {
                current++;
            }
            return current;
        }

        public static long GetProduct(List<int> list)
        {
            long product = 1;
            foreach (var i in list)
            {
                product = product * i;
            }

            return product;
        }

        public static bool IsPythagoreanTriplet(Triplet t)
        {
            return t.A * t.A + t.B * t.B == t.C * t.C;
        }

        public static long FindSumofPrimesBelowN(int n)
        {

            // my original solution

            //long p = 2;
            //long total = 0;
            //while (p < n)
            //{
            //    total = total + p;
            //    p = Helpers.GetNextPrime(p);

            //    Console.WriteLine(string.Format("p = {0}", p));
            //    Console.WriteLine(string.Format("total = {0}", total));
            //}

            //return total;

            // much faster solution using linq

            var result = Enumerable.Range(2, n - 3)
                .AsParallel()
                .Where(x => IsPrime(x))
                .Select<int, long>(x => x)
                .Sum();
            return result;
        }

        public static List<long> GetFactorsOfN(long n)
        {
            var list = new List<long>();
            for (var i = 1; i <= Math.Sqrt(n); i++)
            {
                if (n % i == 0)
                {
                    list.Add(i);
                    list.Add((long)n / i);
                }
            }

            // dedupe the list
            list = list.Distinct().ToList();
            return list;
        }

        public static List<long> GetCollatzSequence(int n)
        {
            var list = new List<long>();
            long current = n;

            while (current != 1)
            {
                list.Add(current);

                if (current % 2 == 0)
                {
                    current = current / 2;
                }
                else
                {
                    current = (3 * current) + 1;
                }

            }
            list.Add(1);

            return list;

        }


        public static BigInteger GetFactorial(int n)
        {
            BigInteger f = 1;
            for (var i = 1; i <= n; i++)
            {
                f = f * i;
            }

            return f;
        }

        public static long GetLatticePaths(int right, int down)
        {
            BigInteger topFactorial = GetFactorial(right + down);
            BigInteger rightFactorial = GetFactorial(right);
            BigInteger downFactorial = GetFactorial(down);
            var answer = topFactorial / (rightFactorial * downFactorial);
            return (long)answer;
        }

        public static BigInteger GetN2Power(int n, int power)
        {
            if (power == 0) return 1;
            BigInteger p = new BigInteger();
            p = n;

            for (int i = 1; i < power; i++)
            {
                p = p * n;
            }
            return p;
        }

        public static long GetSumOfDigits(BigInteger n)
        {
            var str = n.ToString();
            var arr = str.ToCharArray();
            long sum = 0;


            foreach (var s in arr)
            {
                sum = sum + int.Parse(s.ToString());
            }

            return sum;
        }
    }
}
