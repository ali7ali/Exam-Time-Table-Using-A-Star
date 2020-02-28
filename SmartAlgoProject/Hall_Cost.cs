using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartAlgoProject
{
    class Hall_Cost : IComparable<Hall_Cost>
    {
        public string HallName { get; set; }

        public int HallCost { get; set; }

        public int CompareTo(Hall_Cost cost)
        {
            if (cost == null)
                return 1;

            else
                return this.HallCost.CompareTo(cost.HallCost);
        }

        public override string ToString()
        {
            return "Cost: " + HallCost + "   HallName: " + HallName;
        }
    }
}
