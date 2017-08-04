using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectEuler.Problems
{
    public class FiftyFour
    {
        public static long Go()
        {
            var games = Helpers.GetPokerGamesFor54();
            var counter = 0;

            foreach (var game in games)
            {
                if (Helpers.Player1WinsPokerHand(game)) counter++;
            }

            return counter;
        }
    }
}
