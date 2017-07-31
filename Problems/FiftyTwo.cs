using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectEuler.Problems
{
    public class FiftyTwo
    {
        public static long Go()
        {
            var notFound = true;
            var n = 125874;
            Console.WriteLine(n);
            while (notFound)
            {
                n++;
                if (Helpers.ContainTheSameDigits(n, n*2))
                {
                    if (Helpers.ContainTheSameDigits(n, n * 3))
                    {
                        if (Helpers.ContainTheSameDigits(n, n * 4))
                        {
                            if (Helpers.ContainTheSameDigits(n, n * 5))
                            {
                                if (Helpers.ContainTheSameDigits(n, n * 6))
                                {
                                    notFound = false;
                                }
                            }
                        }
                    }
                }
            }
            return n;
        }
    }
}
