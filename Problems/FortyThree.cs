using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectEuler.Problems
{
    public class FortyThree
    {
        public static long Go()
        {
            var pans = Helpers.GetAllPermutationsOfDigits(1234567890);
            var allWithProperty = new List<int>();

            // var test = HasProperty(new List<int>() { 1, 4, 0, 6, 3, 5, 7, 2, 8, 9 });

            foreach(var p in pans)
            {
                if (HasProperty(p))
                {
                    allWithProperty.Add(Helpers.GetIntFromIntList(p));
                }
            }

            return 0;
        }

        private static bool HasProperty(List<int> list)
        {
            if (getValsFromList(list, 2,3,4) % 2 == 0)
            {
                if (getValsFromList(list, 3, 4, 5) % 3 == 0)
                {
                    if (getValsFromList(list, 4, 5, 6) % 5 == 0)
                    {
                        if (getValsFromList(list, 5, 6, 7) % 7 == 0)
                        {
                            if (getValsFromList(list, 6, 7, 8) % 11 == 0)
                            {
                                if (getValsFromList(list, 7, 8, 9) % 13 == 0)
                                {
                                    if (getValsFromList(list, 8, 9, 10) % 17 == 0)
                                    {
                                        return true;
                                    }
                                }
                            }
                        }
                    }
                }
            }
            return false;
        }

        private static int getValsFromList(List<int> list, int idx1, int idx2, int idx3)
        {
            return (list[idx1 - 1] * 100) + (list[idx2 - 1] * 10) + list[idx3 - 1];
        }
    }
}
