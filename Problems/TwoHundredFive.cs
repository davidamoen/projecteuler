using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectEuler.Problems
{
    public class TwoHundredFive
    {
        public static decimal Go()
        {
            var peterList = new List<int>() { 1, 2, 3, 4 };
            var colinList = new List<int>() { 1, 2, 3, 4, 5, 6 };

            decimal peterRolls2 = Decimal.Multiply(Decimal.Divide(4, 6), Decimal.Divide(1, 4));
            decimal peterRolls3 = Decimal.Multiply(Decimal.Divide(3, 6), Decimal.Divide(1, 4));
            decimal peterRolls4 = Decimal.Multiply(Decimal.Divide(2, 6), Decimal.Divide(1, 4));
            decimal prob = peterRolls2 + peterRolls3 + peterRolls4;

            return 0; 
        }
    }
}
