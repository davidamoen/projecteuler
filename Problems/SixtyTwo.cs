using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace ProjectEuler.Problems
{
    public class SixtyTwo
    {
        public static long Go()
        {
            long n = 5000;
            var cubes = new List<String>();
            for (var i = n; i < 10000; i++)
            {
                cubes.Add(BigInteger.Pow(i, 3).ToString());
            }

            foreach(var cube in cubes)
            {
                var sameLength = cubes.Where(c => c.Length == cube.Length).ToList();

                var perms = sameLength
                            .AsParallel()
                            .Where(x => Helpers.IsPermutation(x, cube)).ToList();

                if (perms.Count == 5)
                {
                    return long.Parse(cube);
                }
            }

            return 0;
        }
    }
}
