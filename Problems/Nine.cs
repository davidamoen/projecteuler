using System;
using System.Collections.Generic;

namespace ProjectEuler.Problems
{
    public class Nine
    {
        public static long Go()
        {
            // get a list of all triplets that follow this pattern
            // a + b + c = 1000
            // where a < b < c
            // iterate over this collection, find the one that is pythagorean
            foreach(var p in GetAllEligibleTriplets())
            {
                if (Helpers.IsPythagoreanTriplet(p))
                {
                    return p.A * p.B * p.C;
                }
            }

            return 0;
        }



        private static List<Triplet> GetAllEligibleTriplets()
        {
            var list = new List<Triplet>();
            

            var i = 1;
            var j = 1;

            for (i = 1; i < 1000; i++)
            {
                var startingJ = i + 1;
                var endingJ = 1000 - i;
                

                for (j = startingJ; j <= endingJ; j++)
                {
                    var remainingSum = 1000 - i - j;


                    var a = i;
                    var b = j;
                    var c = remainingSum;

                    if (a >= b || b >= c) continue;

                    if (a + b + c != 1000) continue;

                    list.Add(new Triplet { A = a, B = b, C = c });

                }
            }
            return list;

        }

    }




    public class Triplet
    {
        public int A { get; set; }
        private int _b;
        public int B
        {
            get { return _b; }
            set
            {
                if (value > A)
                {
                    _b = value;
                }
                else
                {
                    throw new Exception();
                }
            }
        }

        private int _c;
        public int C
        {
            get { return _c; }
            set
            {
                if (value > B)
                {
                    _c = value;
                }
                else
                {
                    throw new Exception();
                }
            }
        }


    }
}
