using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectEuler.Problems
{
    public class OneHundredTwelve
    {
        public static long Go()
        {
            double target = .99;
            double i = 100;
            bool targetReached = false;
            int bouncy = 0;

            while (!targetReached)
            {
                var isBouncy = Helpers.IsBouncyNumber((long)i);
                if (isBouncy) bouncy++;

                double currentProportion = bouncy / i;

                Console.WriteLine($"i = {i}, isBouncy = {isBouncy.ToString()}, Proportion = {Math.Round(currentProportion * 100, 5, MidpointRounding.AwayFromZero)}%");

                if (currentProportion == target)
                {
                    return (long)i;
                }

                i++;
            }

            return 0;
        }
    }
}
