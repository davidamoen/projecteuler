﻿using ProjectEuler.Problems;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Numerics;
using System.IO;
using System.Collections;

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
            if (n < 2) return false;

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

        public static bool IsPalindrome(BigInteger n)
        {
            var nStr = n.ToString();
            var nStrRev = new string(nStr.Reverse().ToArray());
            return nStr == nStrRev;
        }

        public static bool IsStringPalindrome(string n)
        {
            var nStr = n;
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

        public static bool IsPythagorean(double a, double b, double c)
        {
            return a * a + b * b == c * c;
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

        public static List<long> GetPrimesBelowN(int n)
        {
            var result = Enumerable.Range(2, n - 3)
                .AsParallel()
                .Where(x => IsPrime(x))
                .Select<int, long>(x => x).ToList();


            return result.OrderBy(x => x).ToList();
        }

        public static List<long> GetPrimesBetweenMandN(int m, int n)
        {
            var result = Enumerable.Range(2, n - 3)
                .AsParallel()
                .Where(x => IsPrime(x) && x > m)
                .Select<int, long>(x => x).ToList();


            return result.OrderBy(x => x).ToList();
        }

        public static List<string> GetPrimesBelowNAsStrings(int n)
        {
            var result = new List<string>();
            foreach(var prime in GetPrimesBelowN(n))
            {
                result.Add(prime.ToString());
            }
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

        public static long GetLargestCommonFactor(List<long> list)
        {
            var factorsList = new List<List<long>>();
            foreach (var n in list)
            {
                factorsList.Add(GetFactorsOfN(n));
            }

            //foreach(var factors in factorsList)
            //{
            //    foreach(var factor in factors)
            //    {


            //    }
            //}


            var commonFactors = new List<long>();

            return 0;
        }

        public static List<long> GetProperDivisorsOfN(long n)
        {

            var list = new List<long>();
            for (var i = 1; i <= Math.Sqrt(n); i++)
            {
                if (n % i == 0)
                {
                    if (i != n) list.Add(i);

                    var other = (long)n / i;
                    if (other != n) list.Add(other);
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

        public static BigInteger SelectRFromN(int n, int r)
        {
            return GetFactorial(n) / (GetFactorial(r) * GetFactorial(n - r));
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

        public static long GetSumOfList(List<long> list)
        {
            long sum = 0;

            foreach (var n in list)
            {
                sum = sum + n;
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

        public static long GetMaximumPathSum(List<List<long>> grid)
        {
            long sum = 0;
            while (grid.Count > 1)
            {
                var lastRow = grid[grid.Count - 1];
                var secondToLastRow = grid[grid.Count - 2];

                for (var i = 0; i < secondToLastRow.Count; i++)
                {

                    sum = secondToLastRow[i] + Math.Max(lastRow[i], lastRow[i + 1]);
                    secondToLastRow[i] = sum;

                }

                grid.Remove(lastRow);
            }
            return sum;
        }

        public static long AmicableD(long n)
        {
            var factors = GetProperDivisorsOfN(n);
            return GetSumOfList(factors);
        }

        public static AmicablePair GetAmicablePair(long n)
        {
            var pair = new AmicablePair();

            pair.a = n;


            long dOfA = AmicableD(pair.a);


            if (dOfA == pair.a) return pair;

            long dOfB = AmicableD(dOfA);

            if (pair.a == dOfB) pair.b = dOfA;

            return pair;
        }

        public static long GetWordScore(string word)
        {
            long score = 0;
            var arr = word.ToCharArray();
            foreach (var s in arr)
            {
                score = score + GetLetterScore(s.ToString());
            }
            return score;
        }

        public static int GetLetterScore(string l)
        {
            var alpha = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
            return alpha.IndexOf(l) + 1;
        }

        public static int GetPositionInStringList(string word, List<string> list)
        {
            return list.IndexOf(word) + 1;
        }

        public static List<string> GetNameListFor22()
        {
            var list = new List<string>();

            var txt = File.ReadAllText("C:\\projects\\ProjectEuler\\ProjectEuler\\Data\\p022_names.txt");

            txt = txt.Replace("\"", string.Empty);

            var arr = txt.Split(',');

            foreach (var name in arr)
            {
                list.Add(name);
            }

            return list.OrderBy(n => n).ToList();

        }

        public static List<PokerGame> GetPokerGamesFor54()
        {
            var list = new List<PokerGame>();

            //var txt = File.ReadAllText("C:\\projects\\ProjectEuler\\ProjectEuler\\Data\\p054_poker.txt");
            var txt = File.ReadAllText("C:\\Users\\a7031\\Source\\Repos\\projecteuler\\Data\\p054_poker.txt");

            string[] lines = txt.Split(new string[] { "\n" }, StringSplitOptions.None);

            foreach(var line in lines)
            {
                if (line == string.Empty) continue;

                string[] hands = line.Split(' ');
                var game = new PokerGame();
                for (var i = 0; i < 5; i++)
                {
                    game.Player1.Cards.Add(new Card(hands[i]));
                }
                for (var j = 5; j < 10; j++)
                {
                    game.Player2.Cards.Add(new Card(hands[j]));
                }
                list.Add(game);
            }

            return list;
        }

        public static List<int> GetIntegersFor59()
        {
            var list = new List<int>();

            // var txt = File.ReadAllText("C:\\projects\\ProjectEuler\\ProjectEuler\\Data\\p059_cipher.txt");
            var txt = File.ReadAllText("C:\\Users\\a7031\\Source\\Repos\\projecteuler\\Data\\p059_cipher.txt");
            var arr = txt.Split(',');

            foreach (var i in arr)
            {
                list.Add(int.Parse(i));
            }

            return list;
        }

        public static List<long> GetAbundantNumbersBelowN(long n) {

            List<long> list = new List<long>();

            for (var i = 12; i < n; i++)
            {
                if (IsAbundant(i))
                {
                    list.Add(i);
                }
            }
            return list;
        }

        public static bool IsAbundant(long n)
        {
            var factors = GetProperDivisorsOfN(n);
            var sum = factors.Sum();

            return sum > n;

        }

        public static List<string> GetLexigraphicPermutations(string digits)
        {
            var list = new List<string>();
            var digitList = digits.Split(',').Select(n => Convert.ToInt32(n)).ToList();
            digitList = digitList.OrderBy(d => d).ToList();

            var intLists = GetPermutations(digitList);

            foreach (var perm in intLists)
            {
                var str = string.Join("", perm.Select(x => x.ToString()).ToArray());
                list.Add(str);
            }

            return list;

        }

        private static List<List<int>> GetPermutations(List<int> list)
        {
            var returnList = new List<List<int>>();
            var listCopy = new List<int>(list);

            if (listCopy.Count == 1)
            {
                returnList.Add(listCopy);
            }
            else
            {
                foreach (var item in listCopy)
                {
                    var firstItem = listCopy.First();
                    var remainingList = RemoveItemFromList(item, listCopy);

                    var perms = GetPermutations(remainingList);

                    foreach (var perm in perms)
                    {
                        perm.Insert(0, item);
                        returnList.Add(perm);
                    }
                }
            }

            return returnList;

        }

        private static List<int> RemoveItemFromList(int item, List<int> list)
        {
            var listCopy = new List<int>(list);
            listCopy.Remove(item);
            return listCopy;
        }

        public static string FindDecimalsAsStringForD(long d)
        {
            BigInteger multiplier = new BigInteger(10000000000000000000);
            multiplier = BigInteger.Pow(multiplier, 200);
            BigInteger numerator = BigInteger.Pow(multiplier, 2);
            BigInteger denominator = BigInteger.Multiply(d, multiplier);
            BigInteger result = BigInteger.Divide(numerator, denominator);

            char[] trimChars = { '0', '.' };
            var dStr = result.ToString().TrimStart(trimChars);

            return dStr.ToString();
        }

        public static string FindRecurringCycle(string input)
        {
            var strLen = input.Length;

            for (var i = 1; i <= strLen; i++)
            {
                var str = input;
                var strLen2 = str.Length;
                for (var j = 1; j <= strLen2 /2; j++)
                {
                    if (j - 1 > str.Length) break;

                    str = str.Substring(j - 1);

                    if (str.Length == i) break;

                    var parts = SplitInPart(str, i);

                    if (parts.Count <= 1) break;

                    var allEqual = !parts.Any(p => p != parts[0]);

                    if (allEqual)
                    {
                        return parts[0];
                    }

                }
            }


            return string.Empty;
        }

        public static List<long> GetQuadraticPrimes(int a, int b)
        {
            double n = 0;
            var list = new List<long>();

            while (true)
            {
                double result = Math.Pow(n, 2) + (a * n) + b;
                var r = (long)result;
                if (Helpers.IsPrime(r))
                {
                    list.Add(r);
                }
                else
                {
                    return list;
                }

                n++;

            }
        }

        public static long GetNumberSpiralDiagonalSum(List<List<int>> grid)
        {
            long total = 0;

            // first do the diagonal from upper left to lower right
            for (var i = 0; i < grid.Count; i++)
            {
                total = total + grid[i][i];
            }

            // now do the diagonal from lower left to upper right
            for (var i = 0; i < grid.Count; i++)
            {
                var yCoord = grid.Count - 1 - i;
                total = total + grid[yCoord][i];
            }

            // substact 1 because the middle cell was counted twice
            total--;

            return total;
        }

        public static List<int> GetNumberSpiralDiagonalValues(List<List<int>> grid)
        {
            var list = new List<int>();
            // first do the diagonal from upper left to lower right
            for (var i = 0; i < grid.Count; i++)
            {
                list.Add(grid[i][i]);
            }

            // now do the diagonal from lower left to upper right
            for (var i = 0; i < grid.Count; i++)
            {
                var yCoord = grid.Count - 1 - i;
                list.Add(grid[yCoord][i]);
            }
            return list.Distinct().OrderBy(l => l).ToList();
        }

        public static List<int> GetNumberSpiralCornerValues(List<List<int>> grid)
        {
            var list = new List<int>();
            var dim = grid[0].Count;
            // first do the diagonal from upper left to lower right
            list.Add(grid[0][0]);
            list.Add(grid[0][dim - 1]);
            list.Add(grid[dim - 1][dim - 1]);
            list.Add(grid[dim - 1][0]);

            return list;
        }

        public static List<int> GetNewDiagonalValuesForGrid(int lastValue, int currentDimension)
        {
            var list = new List<int>();
            for(var i = 1; i < 5; i++)
            {
                list.Add(lastValue + (i * (currentDimension + 1)));
            }
            return list;
        }

        public static List<List<int>> GetNumberSpriralGrid(int dimension)
        {
            // build an empty grid
            var totalCells = 0;
            List<List<int>> grid = new List<List<int>>();
            for (int i = 0; i < dimension; i++)
            {
                List<int> row = new List<int>();
                for (var j= 0; j < dimension; j++)
                {
                    row.Add(0);
                    totalCells++;
                }
                grid.Add(row);
            }

            // get the mid point
            var mid = (dimension / 2) + 1;

            var currentCoordinates = new Coordinates { x = mid - 1, y = mid - 1 };
            var currentDirection = SpiralDirections.up;

            grid[currentCoordinates.x][currentCoordinates.y] = 1;

            var currentValue = 2;
            while (currentValue <= totalCells)
            {

                var desiredCoordinates = GetNextCoordinates(currentCoordinates, GetNextDirection(currentDirection));
                var currentCourseCooredinates = GetNextCoordinates(currentCoordinates, currentDirection);

                if (grid[desiredCoordinates.x][desiredCoordinates.y] == 0)
                {
                    grid[desiredCoordinates.x][desiredCoordinates.y] = currentValue;
                    currentCoordinates = desiredCoordinates;
                    currentDirection = GetNextDirection(currentDirection);
                }
                else
                {
                    grid[currentCourseCooredinates.x][currentCourseCooredinates.y] = currentValue;
                    currentCoordinates = currentCourseCooredinates;
                }
                currentValue++;
            }
            return grid;
        }

        public static List<long> GetDigits2Powers(int power)
        {
            var list = new List<long>();

            // build dictionary with the values for each digit
            var values = new Dictionary<string, long>();
            for (var i = 0; i < 10; i++) {
                values.Add(i.ToString(), (long)Math.Pow((double)i, (double)power));
            }

            // build the max value
            var sb = new StringBuilder();
            for (var i = 0; i < power; i++)
            {
                sb.Append("9");
            }

            int maxValue = int.Parse(sb.ToString())  * 2;

            for (var i = 2; i <= maxValue; i++)
            {
                long total = 0;
                var str = i.ToString();
                var arr = str.ToCharArray();

                foreach (var item in arr)
                {
                    total = total + values[item.ToString()];
                }

                if (total == i) list.Add(total);

            }

            return list;
        }

        public static List<int> GetDigits(int num)
        {
            var list = new List<int>();
            var numStr = num.ToString();
            char[] digits = numStr.ToCharArray();
            foreach (char c in digits)
            {
                list.Add(int.Parse(c.ToString()));
            }
            return list;
        }

        public static List<List<int>> GetAllPermutationsOfDigits(int num)
        {
            var list = GetDigits(num);
            return GetPermutations(list);
        }

        public static List<List<int>> GetAllRotationsOfDigits(int num)
        {
            var result = new List<List<int>>();
            var list = GetDigits(num);
            var len = list.Count;

            for (var i = 0; i < len; i++)
            {
                var clone = list.ConvertAll(x => x);
                result.Add(clone);

                // var newList = new List<int>();
                var lastItem = list.Last();
                list.Insert(0, lastItem);
                list.RemoveAt(len);

            }

            return result;
        }

        public static int GetCombinedDigitsFromList(List<int> list, int startIndex, int count)
        {
            var subList = list.GetRange(startIndex, count);
            var result = 0;
            var counter = 1;
            foreach(var item in subList)
            {
                var power = count - counter;
                result += item * (int)Math.Pow(10, power);
                counter++;
            }
            return result;
        }

        public static Tuple<bool, char> HaveLikeDigits(int a, int b)
        {
            char[] aChars = a.ToString().ToCharArray();
            char[] bChars = b.ToString().ToCharArray();

            foreach (char aChar in aChars)
            {
                foreach(char bChar in bChars)
                {
                    if (aChar.Equals(bChar)) return new Tuple<bool, char>(true, aChar);
                }
            }

            return new Tuple<bool, char>(false, new char());
        }

        public static List<List<int>> GetRightTriangleSolutionsForP(int p)
        {
            var result = new List<List<int>>();
            var low = p / 3;
            var high = low * 2;

            for(var c = low; c < high; c++)
            {
                var remaining = p - c;
                for (var b = 1; b < remaining; b++ )
                {
                    var a = remaining - b;
                    if (IsPythagorean(a, b, c))
                    {
                        try
                        {
                            var t = new Triplet() { A = a, B = b, C = c };
                            result.Add(new List<int>() { a, b, c });
                        }
                        catch { }
                    }
                }
            }


            return result;
        }

        public static string GetChampernownesConstantForNDigits(int n)
        {
            StringBuilder sb = new StringBuilder("123456789");
            var digits = new List<int>() { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9 };
            var counter = 1;
            var keepGoing = true;

            while (keepGoing)
            {
                foreach (var d in digits)
                {
                    sb.AppendFormat("{0}{1}", counter, d);

                    if (sb.Length >= n)
                    {
                        keepGoing = false;
                        break;
                    }
                }
                counter++;
            }
            return sb.ToString();
        }

        public static int GetValFromChampernownesConstant(string cham, int n)
        {
            return int.Parse(cham.Substring(n - 1, 1)); // should be 0
        }

        public static long GetIntFromIntList(List<int> list)
        {
            var sb = new StringBuilder();
            foreach(var item in list)
            {
                sb.Append(item);
            }
            return long.Parse(sb.ToString());
        }

        public static double GetTriangleNumberForN(int n)
        {
            return (.5) * n * ((double)n + 1);
        }

        public static List<string> GetWordListFor42()
        {
            var list = new List<string>();

            // var txt = File.ReadAllText("C:\\projects\\ProjectEuler\\ProjectEuler\\Data\\p042_words.txt");
            var txt = File.ReadAllText("C:\\Users\\a7031\\Source\\Repos\\projecteuler\\Data\\p042_words.txt");

            txt = txt.Replace("\"", string.Empty);

            var arr = txt.Split(',');

            foreach (var name in arr)
            {
                list.Add(name);
            }

            return list.OrderBy(n => n).ToList();

        }

        public static double GetPentagonForN(int n)
        {
            return (n * ((3 * n) - 1)) / 2;
        }

        public static bool IsTriangular(double n)
        {
            double test = (Math.Sqrt(1 + 8 * n) - 1) / 2;
            return test == ((int)test);
        }

        public static bool IsPentagonal(double n)
        {
            double test = (Math.Sqrt(1 + 24 * n) + 1) / 6;
            return test == ((int)test);
        }

        public static bool IsHexagonal(double n)
        {
            double test = (Math.Sqrt(1 + 8 * n) + 1) / 4;
            return test == ((int)test);
        }

        public static bool IsSquare(double n)
        {
            double test = Math.Sqrt(n);
            return test == ((int)test);
        }

        public static long GetNumberFromList(List<int> list)
        {
            var multiplier = 1;
            long result = 0;
            list.Reverse();
            foreach(var d in list)
            {
                result = result + (multiplier * d);
                multiplier = multiplier * 10;
            }
            return result;
        }

        public static bool ContainTheSameDigits(long n1, long n2)
        {
            return Alphabetize(n1.ToString()) == Alphabetize(n2.ToString());
        }

        public static string Alphabetize(string s)
        {
            char[] a = s.ToCharArray();
            Array.Sort(a);
            return new string(a);
        }

        public static bool Player1WinsPokerHand(PokerGame game)
        {
            var score1 = GetPokerScore(game.Player1);
            var score2 = GetPokerScore(game.Player2);

            if (score1 == score2)
            {
                if (game.Player1.RankedHighValue == game.Player2.RankedHighValue)
                {
                    return GetHighestCardValue(game.Player1) > GetHighestCardValue(game.Player2);
                }
                else
                {
                    return game.Player1.RankedHighValue > game.Player2.RankedHighValue;
                }
            }

            return score1 > score2;
        }

        public static int GetPokerScore(PokerHand hand)
        {
            if (IsRoyalStraightFlush(hand)) return 10;
            if (IsStraightFlush(hand)) return 9;
            if (IsFourOfAKind(hand)) return 8;
            if (IsFullHouse(hand)) return 7;
            if (IsFlush(hand)) return 6;
            if (IsStraight(hand)) return 5;
            if (IsThreeOfAKind(hand)) return 4;
            if (IsTwoPairs(hand)) return 3;
            if (IsTwoOfAKind(hand)) return 2;

            hand.RankedHighValue = GetHighestCardValue(hand);
            return 1;
        }

        public static bool IsFlush(PokerHand hand)
        {
            hand.RankedHighValue = GetHighestCardValue(hand);
            return hand.Cards.Select(c => c.Suit).Distinct().Count() == 1;
        }

        public static bool IsFullHouse(PokerHand hand)
        {
            hand.RankedHighValue = GetHighestCardValue(hand);
            return hand.Cards.Select(c => c.Value).Distinct().Count() == 2;
        }

        public static bool IsFourOfAKind(PokerHand hand)
        {
            var most = hand.Cards.GroupBy(c => c.Value).OrderByDescending(grp => grp.Count()).Select(grp => grp.Key).First();
            hand.RankedHighValue = (int)most;
            return hand.Cards.Where(c => c.Value == most).Count() == 4;
        }

        public static bool IsThreeOfAKind(PokerHand hand)
        {
            var most = hand.Cards.GroupBy(c => c.Value).OrderByDescending(grp => grp.Count()).Select(grp => grp.Key).First();
            hand.RankedHighValue = (int)most;
            return hand.Cards.Where(c => c.Value == most).Count() == 3;
        }

        public static bool IsTwoOfAKind(PokerHand hand)
        {
            var most = hand.Cards.GroupBy(c => c.Value).OrderByDescending(grp => grp.Count()).Select(grp => grp.Key).First();
            hand.RankedHighValue = (int)most;
            return hand.Cards.Where(c => c.Value == most).Count() == 2;
        }

        public static bool IsStraight(PokerHand hand)
        {
            var list = new List<int>();
            foreach(var card in hand.Cards)
            {
                list.Add((int)card.Value);
            }
            list = list.OrderBy(l => l).ToList();
            hand.RankedHighValue = GetHighestCardValue(hand);
            return !list.Select((i, j) => i - j).Distinct().Skip(1).Any();
        }

        public static bool IsTwoPairs(PokerHand hand)
        {
            var groups = hand.Cards.GroupBy(c => c.Value).OrderByDescending(grp => grp.Count()).Select(grp => grp.Key).ToList();
            var onePair = hand.Cards.Where(c => c.Value == groups[0]).Count() == 2;
            var twoPair = hand.Cards.Where(c => c.Value == groups[1]).Count() == 2;
            hand.RankedHighValue = GetHighestCardValue(hand);
            return onePair && twoPair;
        }

        public static bool IsStraightFlush(PokerHand hand)
        {
            hand.RankedHighValue = GetHighestCardValue(hand);
            return IsStraight(hand) && IsFlush(hand);
        }

        public static int GetHighestCardValue(PokerHand hand)
        {
            return (int)hand.Cards.OrderByDescending(c => c.Value).First().Value;
        }

        public static bool IsRoyalStraightFlush(PokerHand hand)
        {
            return IsStraight(hand) && IsFlush(hand) && GetHighestCardValue(hand) == (int)CardValue.Ace;
        }

        public static bool IsLychrel(long n)
        {
            var idx = 0;
            BigInteger bigN = new BigInteger(n);
            while (idx < 50)
            {
                BigInteger revN = BigInteger.Parse(new string(bigN.ToString().Reverse().ToArray()));
                bigN = bigN + revN;
                if (IsPalindrome(bigN)) return false;
                idx++;
            }
            return true;
        }

        public static long GetDigitalSum(BigInteger n)
        {
            long sum = 0;
            var arr = n.ToString().ToArray();

            foreach(var a in arr)
            {
                sum = sum + long.Parse(a.ToString());
            }
            return sum;
        }

        private static Coordinates GetNextCoordinates(Coordinates currentCoordinates, SpiralDirections currentDirection)
        {

            var newCoordinates = new Coordinates { x = currentCoordinates.x, y = currentCoordinates.y };
            switch (currentDirection)
            {
                case SpiralDirections.right:
                    newCoordinates.x++;
                    break;
                case SpiralDirections.down:
                    newCoordinates.y++;
                    break;
                case SpiralDirections.left:
                    newCoordinates.x--;
                    break;
                case SpiralDirections.up:
                    newCoordinates.y--;
                    break;
            }
            return newCoordinates;

        }

        private static SpiralDirections GetNextDirection(SpiralDirections currentDirection)
        {
            switch (currentDirection)
            {
                case SpiralDirections.right:
                    return SpiralDirections.down;
                case SpiralDirections.down:
                    return SpiralDirections.left;
                case SpiralDirections.left:
                    return SpiralDirections.up;
                case SpiralDirections.up:
                    return SpiralDirections.right;
            }

            return SpiralDirections.right; // should never be hit
        }

        public enum SpiralDirections
        {
            right,
            down,
            left,
            up
        }

        private static List<string> SplitInPart(string input, Int32 partLength)
        {
            var list = new List<String>();
            var len = input.Length;
            for (var i = 0; i < len; i += partLength)
            {
                if (input.Length - i <= partLength) break;

                var str = input.Substring(i, Math.Min(partLength, len - 1));
                list.Add(str);
            }

            return list;
        }
    }

    public class AmicablePair
    {
        public long a { get; set; }
        public long b { get; set; }
    }

    public class Coordinates
    {
        public int x { get; set; }
        public int y { get; set; }
    }

    public enum CardValue
    {
        Deuce = 2,
        Three = 3,
        Four = 4,
        Five = 5,
        Six = 6,
        Seven = 7,
        Eight = 8,
        Nine = 9,
        Ten = 10,
        Jack = 11,
        Queen = 12,
        King = 13,
        Ace = 14
    }

    public enum CardSuit
    {
        Hearts,
        Spades,
        Diamonds,
        Clubs
    }

    public enum PokerHands
    {
        None = 1,
        OnePair = 2,
        TwoPairs = 3,
        ThreeOfAKind = 4,
        Straight = 5,
        Flush = 6,
        FullHouse = 7,
        FourOfAKind = 8,
        StraightFlush = 9,
        RoyalFlush = 10
    }

    public class Card
    {
        public CardValue Value { get; set; }
        public CardSuit Suit { get; set; }

        public Card(string code)
        {
            switch (code.Substring(0,1))
            {
                case "2":
                    Value = CardValue.Deuce;
                    break;
                case "3":
                    Value = CardValue.Three;
                    break;
                case "4":
                    Value = CardValue.Four;
                    break;
                case "5":
                    Value = CardValue.Five;
                    break;
                case "6":
                    Value = CardValue.Six;
                    break;
                case "7":
                    Value = CardValue.Seven;
                    break;
                case "8":
                    Value = CardValue.Eight;
                    break;
                case "9":
                    Value = CardValue.Nine;
                    break;
                case "T":
                    Value = CardValue.Ten;
                    break;
                case "J":
                    Value = CardValue.Jack;
                    break;
                case "Q":
                    Value = CardValue.Queen;
                    break;
                case "K":
                    Value = CardValue.King;
                    break;
                case "A":
                    Value = CardValue.Ace;
                    break;
            }

            switch (code.Substring(1, 1))
            {
                case "S":
                    Suit = CardSuit.Spades;
                    break;
                case "H":
                    Suit = CardSuit.Hearts;
                    break;
                case "C":
                    Suit = CardSuit.Clubs;
                    break;
                case "D":
                    Suit = CardSuit.Diamonds;
                    break;
            }

        }
    }

    public class PokerHand
    {
        public List<Card> Cards { get; set; }

        public int RankedHighValue { get; set; }

        public PokerHand()
        {
            Cards = new List<Card>();
        }
    }

    public class PokerGame
    {
        public PokerHand Player1 { get; set; }
        public PokerHand Player2 { get; set; }

        public PokerGame()
        {
            Player1 = new PokerHand();
            Player2 = new PokerHand();
        }


    }
}
