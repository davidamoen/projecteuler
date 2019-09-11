using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectEuler.Models
{
    public class MonopolySquare
    {
        public string Id { get; set; }

        public string Name { get; set; }

        public int Visits { get; set; }

        public bool IsRailroad { get; set; }

        public bool IsUtility { get; set; }

        public bool IsChance { get; set; }

        public bool IsCommunityChest { get; set; }

    }
}
