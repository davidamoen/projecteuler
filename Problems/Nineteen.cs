using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectEuler.Problems
{
    public class Nineteen
    {
        public static long Go()
        {

            var startDate = new DateTime(1901, 1, 1);
            var endDate = new DateTime(2000, 12, 31);
            long total = 0;

            while (startDate <= endDate)
            {

                if (startDate.DayOfWeek == DayOfWeek.Sunday) total++;

                startDate = startDate.AddMonths(1);

            }
            return total;

        }
    }
}
