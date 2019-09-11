using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectEuler.Problems
{
    public class EightyFour
    {
        public static long Go()
        {
            var turns = 10000000;
            var diceSides = 6;
            var board = Helpers.RunMonopolySimulation(turns, diceSides, true);

            board = board.OrderByDescending(x => x.Visits).ToList();

            return 0;
        }
    }
}
