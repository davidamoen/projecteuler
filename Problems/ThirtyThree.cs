using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace ProjectEuler.Problems
{
    public class ThirtyThree
    {
        public static long Go()
        {
            var d = new List<Tuple<decimal, decimal, char>>();
            for (var i = 10; i < 100; i++)
            {
                for (var j = 10; j < 100; j++)
                {
                    var checkLikeDigits = Helpers.HaveLikeDigits(i, j);
                    if (i < j && checkLikeDigits.Item1)
                    {
                        d.Add(new Tuple<decimal, decimal, char>(i, j, checkLikeDigits.Item2));
                    }
                }
            }

            var results = new List<Tuple<decimal, decimal>>();
            foreach(var t in d)
            {
                if (t.Item1 % 10 == 0 && t.Item2 % 10 == 0) continue;

                var r = new Regex(Regex.Escape(t.Item3.ToString()));
                var numeratorStr = t.Item1.ToString();
                var denominatorStr = t.Item2.ToString();

                var shortendNumStr = r.Replace(numeratorStr, string.Empty, 1);
                var shortendDenStr = r.Replace(denominatorStr, string.Empty, 1);

                if (shortendNumStr != "0" && shortendDenStr != "0")
                {
                    var shortenedNum = decimal.Parse(shortendNumStr);
                    var shortenedDen = decimal.Parse(shortendDenStr);

                    decimal firstFraction = t.Item1 / t.Item2;
                    decimal secondFraction = shortenedNum / shortenedDen;

                    if (firstFraction.Equals(secondFraction))
                    {
                        results.Add(new Tuple<decimal, decimal>(t.Item1, t.Item2));
                    }

                }

            }

            // multiply the fractions we found
            long numProduct = 1;
            long denProduct = 1;
            foreach(var result in results)
            {
                numProduct = numProduct * (long)result.Item1;
                denProduct = denProduct * (long)result.Item2;
            }

            var numFactors = Helpers.GetFactorsOfN(numProduct);
            var denFactors = Helpers.GetFactorsOfN(denProduct);
            long gcf = 0;
            foreach (var numFactor in numFactors.OrderByDescending(x => x))
            {
                if (denFactors.Contains(numFactor))
                {
                    gcf = numFactor;
                    break;
                }
            }

            var finalNum = numProduct / gcf;
            var finalDen = denProduct / gcf;

            return finalDen;
        }
    }
}
