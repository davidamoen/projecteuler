using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectEuler.Problems
{
    public class Twelve
    {
        public static long Go()
        {
            var factors = new List<long>();
            int counter = 1;
            long triangle = 0;

            while (factors.Count <= 500)
            {
                triangle = triangle + counter;

                factors = Helpers.GetFactorsOfN(triangle);

                counter++;
            }

            return triangle;
        }
}

}
