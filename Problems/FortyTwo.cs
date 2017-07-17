using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectEuler.Problems
{
    public class FortyTwo
    {
        public static long Go()
        {
            var tris = new List<double>();
            var words = Helpers.GetWordListFor42();
            var triangleWords = new List<string>();

            for(int i = 1; i <=100; i++)
            {
                tris.Add(Helpers.GetTriangleNumberForN(i));
            }

            var testScore = Helpers.GetWordScore("SKY");

            foreach(var word in words)
            {
                var score = Helpers.GetWordScore(word);
                if (tris.IndexOf(score) >= 0)
                {
                    triangleWords.Add(word);
                }
            }

            return triangleWords.Count;
        }
    }
}
