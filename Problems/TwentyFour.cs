using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectEuler.Problems
{
    public class TwentyFour
    {
        public static long Go()
        {
            var digits = "0,1,2,3,4,5,6,7,8,9";
            var perms = Helpers.GetLexigraphicPermutations(digits);

            var answer = perms[999999];

            return long.Parse(answer);
        }
    }
}
