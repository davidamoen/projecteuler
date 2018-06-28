using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectEuler.Problems
{
    public class NinetyTwo
    {
        public static long Go()
        {
            var target = 10 * 1000000;
            var arr = GetDefaultArray(target);

            for (var i = 1; i < target; i++)
            {
                if (arr[i] == 0)
                {
                    Console.WriteLine($"Testing {i}");
                    var chain = Helpers.GetSquareDigitChain(new List<int>() { i });
                    var result = chain.Last();
                    foreach (var c in chain)
                    {
                        if (arr[c] != 0) break;
                        arr[c] = result;

                        // add permutations of that result
                        SetAllPermutations(c, result, arr);
                    }
                }
            }
            return arr.Where(x => x == 89).Count();
        }

        private static void SetAllPermutations(int val, int result, int[] arr)
        {
            var digits = Helpers.GetDigits(val);
            while (digits.Count < 7)
            {
                digits.Add(0);
            }

            var perms = Helpers.GetPermutations(digits);
            var lastVal = 0;
            foreach(var perm in perms)
            {
                // get value
                var permVal = GetIntFromList(perm);
                
                // if (arr[permVal] != 0 && permVal != lastVal) break;

                arr[permVal] = result;

                lastVal = permVal;
            }
        }

        private static int GetIntFromList(List<int> list)
        {
            var str = new StringBuilder();
            foreach(var l in list)
            {
                str.Append(l);
            }

            return int.Parse(str.ToString());
        }

        private static int[] GetDefaultArray(int target)
        {
            int[] arr = new int[target];
            for ( var i = 0; i < target; i++)
            {
                arr[i] = 0;
            }
            return arr;
        }
    }
}
