using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectEuler.Problems
{
    public class Forty
    {
        public static long Go()
        {
            var cham = Helpers.GetChampernownesConstantForNDigits(1000000);

            var d1 = Helpers.GetValFromChampernownesConstant(cham, 1);
            var d10 = Helpers.GetValFromChampernownesConstant(cham, 10);
            var d100 = Helpers.GetValFromChampernownesConstant(cham, 100);
            var d1000 = Helpers.GetValFromChampernownesConstant(cham, 1000);
            var d10000 = Helpers.GetValFromChampernownesConstant(cham, 10000);
            var d100000 = Helpers.GetValFromChampernownesConstant(cham, 100000);
            var d1000000 = Helpers.GetValFromChampernownesConstant(cham, 1000000);

            return d1 * d10 * d100 * d1000 * d10000 * d100000 * d1000000;
        }
    }
}