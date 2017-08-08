using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectEuler.Problems
{
    public class FiftyEight
    {
        public static long Go()
        {
            var sideLength = 3;
            var notFound = true;
            var primes = new List<int>() { 3, 5, 7 };
            var diags = new List<int>() { 1 };
            var grid = Helpers.GetNumberSpriralGrid(3);
            diags.AddRange(Helpers.GetNumberSpiralCornerValues(grid).OrderBy(i => i).ToList());

            while (notFound)
            {
                var corners = Helpers.GetNewDiagonalValuesForGrid(diags.Last(), sideLength);
                var lastItem = corners.Last();
                foreach (var corner in corners)
                {
                    diags.Add(corner);
                    if (corner == lastItem) continue;

                    if (Helpers.IsPrime(corner))
                    {
                        primes.Add(corner);
                    }
                }

                double ratio = (double)primes.Count / (double)diags.Count;
                var r = Math.Round(ratio * 100);
                if (ratio < .1)
                {
                    notFound = false;
                }
                sideLength = sideLength + 2;
            }
            return sideLength;
        }
    }
}
