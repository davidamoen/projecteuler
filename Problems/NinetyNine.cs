using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace ProjectEuler.Problems
{
    public class NinetyNine
    {
        public static long Go()
        {
            var data = System.IO.File.ReadAllText("../../Data/p099_base_exp.txt");
            var lineNumber = 1;
            BigInteger largest = new BigInteger(0);
            int largestRow = lineNumber;
            foreach(var row in data.Split('\n'))
            {
                var numbers = row.Split(',');
                var item = new Tuple<int, int>(int.Parse(numbers[0]), int.Parse(numbers[1]));

                var current = BigInteger.Pow(item.Item1, item.Item1);
                if (current > largest)
                {
                    largest = current;
                    largestRow = lineNumber;
                }

                lineNumber++;
            }

            return 0;
        }
    }
}
