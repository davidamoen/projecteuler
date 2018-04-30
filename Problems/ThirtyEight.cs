using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectEuler.Problems
{
    public class ThirtyEight
    {
        public static long Go()
        {
            var perms = Helpers.GetAllPermutationsOfDigits(987654321);

            var splits = new List<List<int>>
            {
                new List<int>() { 1, 2, 3, 3 },
                new List<int>() { 1, 3, 5 },
                new List<int>() { 2, 2, 2, 3 },
                new List<int>() { 2, 3, 4 },
                new List<int>() { 3, 3, 3 },
                new List<int>() { 4, 5 }
            };

            foreach (var perm in perms)
            {
                Console.WriteLine("Permutation: " + String.Join(",", perm.ToArray()));
                foreach (var split in splits)
                {
                    Console.WriteLine("Split: " + String.Join(",", split.ToArray()));
                    var list = new List<long>();
                    var startIdx = 0;
                    foreach (var part in split)
                    {
                        var val = Helpers.GetCombinedDigitsFromList(perm, startIdx, part);
                        list.Add(val);
                        startIdx += part;
                    }

                    Console.WriteLine("List: " + String.Join(",", list.ToArray()));

                    var n = 2;
                    var multiplier = list[0];
                    foreach (var item in list.GetRange(1, list.Count-1))
                    {
                        if ((multiplier * n) != item)
                        {
                            break;
                        }

                        n++;
                    }
                }
            }


            return 0;
        }
    }
}
