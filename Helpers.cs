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

        public static string ConvertN2BritishUsage(int n)
        {
            var list = GetNAsList(n);
            StringBuilder str = new StringBuilder();
            if (list.Count == 4)
            {
                return GetBritishUsageForThousands(list);
            }

            if (list.Count == 3)
            {
                return GetBritishUsageForHundreds(list);
            }

            if (list.Count == 2)
            {
                return GetBritishUsageForTens(list);
            }

            if (list.Count == 1)
            {
                return GetSingleDigitNumberAsString(list[0]);
            }

            return string.Empty;

        }

        private static string GetBritishUsageForThousands(List<int> list)
        {
            StringBuilder str = new StringBuilder();
            str.Append(GetSingleDigitNumberAsString(list[0]));
            str.Append(" thousand");

            if (list[1] > 0 || list[2] > 0 || list[3] > 0)
            {
                str.Append(" and ");
                var listForHundreds = list;
                listForHundreds.RemoveAt(0);
                str.Append(GetBritishUsageForHundreds(listForHundreds));
            }

            return str.ToString();
        }

        public static string GetBritishUsageForHundreds(List<int> list)
        {
            if (list[0] == 0) return GetBritishUsageForTens(list);


            StringBuilder str = new StringBuilder();
            str.Append(GetSingleDigitNumberAsString(list[0]));
            str.Append(" hundred");

            if (list[1] > 0 || list[2] > 0)
            {
                str.Append(" and ");
                var listForTens = list;
                listForTens.RemoveAt(0);
                str.Append(GetBritishUsageForTens(listForTens));
            }

            return str.ToString();
        }

        public static string GetBritishUsageForTens(List<int> list)
        {
            if (list[0] == 0) return GetSingleDigitNumberAsString(list[1]);

            if (list[0] == 1) return GetTeenNumberAsString(list[0], list[1]);

            var str = new StringBuilder();
            switch (list[0])
            {
                case 2:
                    str.Append("twenty");
                    break;
                case 3:
                    str.Append("thirty");
                    break;
                case 4:
                    str.Append("forty");
                    break;
                case 5:
                    str.Append("fifty");
                    break;
                case 6:
                    str.Append("sixty");
                    break;
                case 7:
                    str.Append("seventy");
                    break;
                case 8:
                    str.Append("eighty");
                    break;
                case 9:
                    str.Append("ninety");
                    break;
            }

            if (list[1] != 0)
            {
                str.Append("-");
                str.Append(GetSingleDigitNumberAsString(list[1]));

            }

            return str.ToString();
        }

        public static string GetTeenNumberAsString(int tenDigit, int onesDigit)
        {
            var teen = (tenDigit * 10) + onesDigit;
            switch (teen)
            {
                case 10:
                    return "ten";
                case 11:
                    return "eleven";
                case 12:
                    return "twelve";
                case 13:
                    return "thirteen";
                case 14:
                    return "fourteen";
                case 15:
                    return "fifteen";
                case 16:
                    return "sixteen";
                case 17:
                    return "seventeen";
                case 18:
                    return "eighteen";
                case 19:
                    return "nineteen";
                default:
                    return string.Empty;


            }

        }

        public static string GetSingleDigitNumberAsString(int n)
        {
            switch (n)
            {
                case 1:
                    return "one";
                case 2:
                    return "two";
                case 3:
                    return "three";
                case 4:
                    return "four";
                case 5:
                    return "five";
                case 6:
                    return "six";
                case 7:
                    return "seven";
                case 8:
                    return "eight";
                case 9:
                    return "nine";
                default:
                    return "";
            }
        }

        public static int GetNumberLetterCountforN(int n)
        {
            return ConvertN2BritishUsage(n).Replace(" ", "").Replace("-", "").Length;
        }

        private static List<int> GetNAsList(int n)
        {
            var list = new List<int>();
            var str = n.ToString();
            foreach (var c in str.ToCharArray()) {
                list.Add(int.Parse(c.ToString()));
            }
            return list;
        }

    }
}
