using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectEuler.Problems
{
    public class TwentyTwo
    {
        public static long Go()
        {
            long total = 0;
            var list = Helpers.GetNameListFor22();

            foreach(var name in list)
            {

                var score = Helpers.GetWordScore(name);
                var position = Helpers.GetPositionInStringList(name, list);
                total = total + (score * position);

            }

            return total;
        }


    }
}
