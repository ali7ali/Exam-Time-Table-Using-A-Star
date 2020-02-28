using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartAlgoProject
{
    class P_Cost : IEquatable<P_Cost>, IComparable<P_Cost>
    {
        public int ProctorID { get; set; }

        public int ProctorCost { get; set; }

        public int CompareTo(P_Cost other)
        {
            if (other == null)
                return 1;

            else
                return this.ProctorCost.CompareTo(other.ProctorCost);
        }
        public override bool Equals(object obj)
        {
            return Equals(obj as P_Cost);
        }

        public bool Equals(P_Cost other)
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

        public static bool operator ==(P_Cost cost1, P_Cost cost2)
        {
            return EqualityComparer<P_Cost>.Default.Equals(cost1, cost2);
        }

        public static bool operator !=(P_Cost cost1, P_Cost cost2)
        {
            return !(cost1 == cost2);
        }
    }
}
