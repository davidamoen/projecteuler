using ProjectEuler.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectEuler.Problems
{
    public class OneHundredTwo
    {
        public static long Go()
        {
            var triangles = Helpers.GetTrianglesFor102();
            var counter = 0;
            var origin = new Coordinate(0,0);
            foreach (var triangle in triangles)
            {
                if (Helpers.PointInTriangle(origin, triangle) )
                {
                    counter++;
                }
            }
            return counter;
        }
    }
}
