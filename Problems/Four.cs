using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectEuler.Problems
{
    public class Four
    {
        public static long Go()
        {

            var largest3DigitNumber = 999;
            var smallest3DigitNumber = 100;
            var palindromes = new List<long>();

            for (var i = smallest3DigitNumber; i <= largest3DigitNumber; i++)
            {
                for (var j = smallest3DigitNumber; j <= largest3DigitNumber; j++)
                {
                    var product = i * j;
                    if (Helpers.IsPalindrome(product)) palindromes.Add(product);
                }
            }
            return palindromes.Max();
        }
    }
}
