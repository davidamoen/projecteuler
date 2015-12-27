using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectEuler.Problems
{
    public class TwentyEight
    {
        public static long Go()
        {

            var grid = Helpers.GetNumberSpriralGrid(1001);

            return Helpers.GetNumberSpiralDiagonalSum(grid);

        }
    }
}
