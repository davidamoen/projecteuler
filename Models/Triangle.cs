using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectEuler.Models
{
    public class Triangle
    {
        public Coordinate A { get; set; }
        public Coordinate B { get; set; }
        public Coordinate C { get; set; }



        public bool Contains(Coordinate coord)
        {

            return true;
        }
    }

    public class Coordinate
    {
        public Coordinate(int X, int Y)
        {
            this.X = X;
            this.Y = Y;
        }

        public double X { get; set; }
        public double Y { get; set; }
    }

    public class Line
    {
        public Line(Coordinate A, Coordinate B)
        {
            this.A = A;
            this.B = B;
            GetIntercepts();
        }
        public Coordinate A { get; set; }
        public Coordinate B { get; set; }

        public double XIntercept { get; set; }
        public double YIntercept { get; set; }

        private void GetIntercepts()
        {
            var eq = new LineEquation
            {
                Slope = (B.Y - A.Y) / (B.X - A.X)
            };

            // sub in one point
            eq.X = A.X;
            eq.Y = A.Y;

            var mb = eq.Slope * eq.X;
            eq.B = eq.Y - mb;
            XIntercept = -1 * eq.B / eq.Slope;
            YIntercept = eq.B;
            }
    }

    public class LineEquation
    {
        public double Slope { get; set; }

        public double B { get; set; }

        public double X { get; set; }

        public double Y { get; set; }
    }


}
