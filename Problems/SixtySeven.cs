using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectEuler.Problems
{
    public class SixtySeven
    {
        public static long Go()
        {
            var triangle = Helpers.GetTriangleFor67();
            return Helpers.GetMaximumPathSum(triangle);
        }
    }
}
