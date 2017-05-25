using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace ProjectEuler.Problems
{
    public class ThirtySix
    {
        public static long Go()
        {
            var result = new List<int>();
            var sum = 0;
            for (var i = 1; i < 1000000; i++)
            {

                if (Helpers.IsPalindrome(i))
                {
                    Console.WriteLine(i);
                    var binary = Convert.ToString(i, 2);

                    if (Helpers.IsStringPalindrome(binary))
                    {
                        result.Add(i);
                        sum += i;
                    }

                }
            }
            return sum;
        }
    }
}
