using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectEuler.Problems
{
    public class Thirty
    {
        public static long Go()
        {

            var list = Helpers.GetDigits2Powers(5);

            return list.Sum();
        }
    }
}
