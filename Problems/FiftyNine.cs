using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectEuler.Problems
{
    public class FiftyNine
    {
        public static long Go()
        {
            var ints = Helpers.GetIntegersFor59();
            var letters = "abcdefghijklmnopqrstuvwxyz";
            var sum = 0;

            // build all possible passwords
            var passwords = new List<string>();
            for(var a = 0; a < 26; a++)
            {
                for(var b = 0; b < 26; b++)
                {
                    for(var c = 0; c < 26; c++)
                    {
                        passwords.Add(string.Format("{0}{1}{2}", letters[a], letters[b], letters[c]));
                    }
                }
            }

            // decrypt the string for every password until we find common english words
            foreach(var pw in passwords)
            {
                // build the key
                var key = new List<int>();
                var idx = 0;
                while (key.Count < ints.Count)
                {
                    key.Add(pw[idx % 3]);
                    idx++;
                }

                var keyCount = key.Count;
                var result = new StringBuilder();
                sum = 0;
                for (var i = 0; i < keyCount; i++)
                {
                    var xor = ints[i] ^ key[i];
                    sum = sum + xor;
                    result.Append((char)xor);
                }

                var rStr = result.ToString();
                if (rStr.IndexOf("and") >= 0 && rStr.IndexOf("the") >= 0 && rStr.IndexOf("with") >= 0)
                {
                    break;
                }
            }

            return sum;
        }
    }
}
