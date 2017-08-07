using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectEuler.Problems
{
    public class FiftyFive
    {
        public static long Go()
        {
            long n = 9999;
            var list = new List<long>();
            while (n > 0)
            {
                if (Helpers.IsLychrel(n))
                {
                    list.Add(n);
                }
                n--;
            }
            return list.Count;
        }
    }
}
