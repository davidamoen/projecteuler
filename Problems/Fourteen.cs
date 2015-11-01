using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectEuler.Problems
{
    public class Fourteen
    {
        public static long Go()
        {

            var longestSequence = new List<long>();
            var startingNumber = 0;

            for(var i = 1; i < 1000000; i++)
            {
                var seq = Helpers.GetCollatzSequence(i);
                if (seq.Count > longestSequence.Count)
                {
                    longestSequence = seq;
                    startingNumber = i;
                }
            }


            return startingNumber;  
        }


    }
}
