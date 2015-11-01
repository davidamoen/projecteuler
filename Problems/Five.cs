using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectEuler.Problems
{
    public class Five
    {
        public static long Go() 
        {

            var numbers = new List<int>();

            for (var i = 20; i > 0; i--)
            {
                numbers.Add(i);
            }

            var biggest = numbers.First();
            var current = biggest;
            var counter = 1;

            while (!Helpers.IsMultipleOfAllNumbers(current, numbers))
            {
                counter++;
                current = biggest * counter;
            }
            return current;
        
        }
    }
}
