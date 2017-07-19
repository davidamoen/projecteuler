using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectEuler.Problems
{
    public class FortyOne
    {
        public static long Go()
        {
            var all = new List<int>() { 123456789, 12345678, 1234567, 123456 };
            long largest = 0;

            foreach(var digits in all)
            {
                var pandigitals = Helpers.GetAllPermutationsOfDigits(digits);

                foreach(var pd in pandigitals)
                {
                    var i = Helpers.GetIntFromIntList(pd);

                    if (Helpers.IsPrime(i))
                    {
                        if (i > largest) largest = i;
                    }
                }
            }

            return largest;
        }
    }
}
