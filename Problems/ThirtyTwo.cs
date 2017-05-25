using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectEuler.Problems
{
    public class ThirtyTwo
    {
        public static long Go()
        {
            var pandigitals = Helpers.GetAllPermutationsOfDigits(123456789);
            var products = new List<int>();
            var sum = 0;

            foreach (var pd in pandigitals)
            {
                for (var i = 1; i < 5; i++)
                {
                    var multiplicand = Helpers.GetCombinedDigitsFromList(pd, 0, i);
                    var multiplier = Helpers.GetCombinedDigitsFromList(pd, i, 5 - i);
                    var product = Helpers.GetCombinedDigitsFromList(pd, 5, 4);

                    if (multiplicand * multiplier == product)
                    {
                        products.Add(product);
                    }
                }
            }

            foreach(var p in products.Distinct())
            {
                sum += p;
            }

            return sum;
        }
    }
}
