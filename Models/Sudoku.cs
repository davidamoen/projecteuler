using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectEuler.Models
{
    public class Sudoku
    {
        public Sudoku()
        {
            Grid = new List<List<int>>();
        }

        public Sudoku(string str)
        {
            Grid = new List<List<int>>();
            Load(str);
        }

        public string Name { get; set; }

        public List<List<int>> Grid { get; set; }

        private void Load(string str)
        {
            var arr = str.Split(new[] { Environment.NewLine }, StringSplitOptions.None);

            foreach (var line in arr)
            {
                if (line != string.Empty)
                {
                    var lineList = new List<int>();
                    var res = line.Select(x => new string(x, 1)).ToArray();

                    foreach(var cell in line)
                    {
                        lineList.Add(int.Parse(cell.ToString()));
                    }
                    Grid.Add(lineList);
                }
            }
        }
    }
}
