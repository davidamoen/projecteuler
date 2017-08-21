using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectEuler.Problems
{
    public class SixtyOne
    {
        public static long Go()
        {
            var all = new List<long>();
            var triangles = new List<long>();
            var squares = new List<long>();
            var pentagons = new List<long>();
            var hexagons = new List<long>();
            var heptagons = new List<long>();
            var octogons = new List<long>();

            for (var n = 1010; n < 10000; n++)
            {
                var onAList = false;
                if (Helpers.IsTriangular(n)) { triangles.Add(n); onAList = true; }
                if (Helpers.IsSquare(n)) { squares.Add(n); onAList = true; }
                if (Helpers.IsPentagonal(n)) { pentagons.Add(n); onAList = true; }
                if (Helpers.IsHexagonal(n)) { hexagons.Add(n); onAList = true; }
                if (Helpers.IsHeptagonal(n)) { heptagons.Add(n); onAList = true; }
                if (Helpers.IsOctagonal(n)) { octogons.Add(n); onAList = true; }

                if (onAList) all.Add(n);
            }

            all = all.OrderBy(a => a).Distinct().ToList();

            foreach(var a in all)
            {
                var startB = long.Parse(a.ToString().Substring(2)) * 100;
                var endB = startB + 100;
                foreach(var b in all)
                {
                    if (b >= startB && b <= endB)
                    {
                        var startC = long.Parse(b.ToString().Substring(2)) * 100;
                        var endC = startC + 100;
                        foreach (var c in all)
                        {
                            if (c >= startC && c <= endC)
                            {
                                var startD = long.Parse(c.ToString().Substring(2)) * 100;
                                var endD = startD + 100;
                                foreach (var d in all)
                                {
                                    if (d >= startD && d <= endD)
                                    {
                                        var startE = long.Parse(d.ToString().Substring(2)) * 100;
                                        var endE = startE + 100;
                                        foreach (var e in all)
                                        {
                                            if (e >= startE && e <= endE)
                                            {
                                                foreach (var f in all)
                                                {
                                                    var startOfA = a.ToString().Substring(0, 2);
                                                    var endOfF = f.ToString().Substring(2);
                                                    var startOfF = f.ToString().Substring(0, 2);
                                                    var endOfE = e.ToString().Substring(2);
                                                    if (startOfA == endOfF && startOfF == endOfE)
                                                    {
                                                        var remainingCyclics = new List<long>() { a, b, c, d, e, f };

                                                        int tri = 0;
                                                        int sqr = 0;
                                                        int pent = 0;
                                                        int hex = 0;
                                                        int hep = 0;
                                                        int oct = 0;

                                                        foreach(var rc in remainingCyclics)
                                                        {
                                                            if (Helpers.IsTriangular(rc) && tri == 0) tri = 1;
                                                            else if (Helpers.IsSquare(rc) && sqr == 0) sqr = 1;
                                                            else if (Helpers.IsPentagonal(rc) && pent == 0) pent = 1;
                                                            else if (Helpers.IsHexagonal(rc) && hex == 0) hex = 1;
                                                            else if (Helpers.IsHeptagonal(rc) && hep == 0) hep = 1;
                                                            else if (Helpers.IsOctagonal(rc) && oct == 0) oct = 1;
                                                        }

                                                        if (tri + sqr + pent + hex + hep + oct == 6)
                                                        {
                                                            return remainingCyclics.Sum();
                                                        }
                                                    }
                                                }
                                            }
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
            }

            return 0;
        }

        private static List<long> getCyclics(long n)
        {
            var digits = n.ToString().Substring(2);
            var i = 1010;
            var list = new List<long>();
            while (i < 10000)
            {
                var testDigits= i.ToString().Substring(0, 2);
                if (testDigits == digits) list.Add(i);
                i++;
            }

            return list;
        }
    }
}
