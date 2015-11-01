using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Numerics;

namespace ProjectEuler.Problems
{
    public class Fifteen
    {
        public static long Go()
        {
            return Helpers.GetLatticePaths(20, 20);
        }
    }
}
