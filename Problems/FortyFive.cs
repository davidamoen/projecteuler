using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectEuler.Problems
{
    public class FortyFive
    {
        public static long Go()
        {
            //var test = Helpers.IsHexagonal(40755);
            //var test2 = Helpers.IsPentagonal(40755);
            //var test3 = Helpers.IsTriangular(40755);

            var notFound = true;
            var n = 285;
            double result = 0;

            while(notFound)
            {
                n++;
                var t = Helpers.GetTriangleNumberForN(n);
                Console.WriteLine(t);
                if (Helpers.IsPentagonal(t) && Helpers.IsHexagonal(t))
                {
                    result = t;
                    notFound = false;
                }
            }

            return (long)result;
        }
    }
}
