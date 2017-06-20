using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectEuler.Problems
{
    public class ThirtyNine
    {
        public static long Go()
        {

            var longestList = new List<List<int>>();
            var maxP = 0;

            for (var i = 1; i <=1000; i++)
            {
                Console.WriteLine(i);
                var list = Helpers.GetRightTriangleSolutionsForP(i);
                if (list.Count > longestList.Count)
                {
                    longestList = list;
                    maxP = i;
                }
            }


            return maxP;
        }
    }
}
