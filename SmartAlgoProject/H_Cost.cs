using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartAlgoProject
{
    class H_Cost : IEquatable<H_Cost>, IComparable<H_Cost>
    {
        public int ProctorID { get; set; }

        public int ProctorCost { get; set; }

        public int CompareTo(H_Cost other)
        {
            if (other == null)
                return 1;

            else
                return this.ProctorCost.CompareTo(other.ProctorCost);
        }

        public override bool Equals(object obj)
        {
            return Equals(obj as H_Cost);
        }

        public bool Equals(H_Cost other)
        {
            return other != null &&
                   ProctorID == other.ProctorID &&
                   ProctorCost == other.ProctorCost;
        }

        public override int GetHashCode()
        {
            var hashCode = -725798326;
            hashCode = hashCode * -1521134295 + ProctorID.GetHashCode();
            hashCode = hashCode * -1521134295 + ProctorCost.GetHashCode();
            return hashCode;
        }

        public override string ToString()
        {
            return "ProctorID: " + ProctorID + "   ProctorCost: " + ProctorCost;
        }

        public static bool operator ==(H_Cost cost1, H_Cost cost2)
        {
            return EqualityComparer<H_Cost>.Default.Equals(cost1, cost2);
        }

        public static bool operator !=(H_Cost cost1, H_Cost cost2)
        {
            return !(cost1 == cost2);
        }
    }
}
