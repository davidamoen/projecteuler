using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectEuler.Problems
{
    public class FortyFour
    {
        public static long Go()
        {
            double result = 0;
            bool notFound = true;
            int i = 1;
            while(notFound)
            {
                i++;
                double n = Helpers.GetPentagonForN(i);
                for (int j = i-1; j > 0; j--)
                {
                    double m = Helpers.GetPentagonForN(j);
                    if (Helpers.IsPentagonal(n - m) && Helpers.IsPentagonal(n + m))
                    {
                        result = n - m;
                        notFound = false;
                        break;
                    }
                }
            }
            return (long)result;
        }

    }
    class PentPair
    {
        public double A { get; set; }
        public double B { get; set; }
        public double Difference
        {
            get
            {
                return Math.Abs(B - A);
            }
        }
    }
}
