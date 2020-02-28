using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartAlgoProject
{
    enum Days
    {
        Sunday = 0, Monday = 1, Tuseday = 2, Wednesday = 3, Thursday = 4
    }
    class Day
    {
        public Days name;
        public List<Duration_of_Day> duration_Of_Days;

        public Day(Days Days)
        {
            name = Days;
            duration_Of_Days = new List<Duration_of_Day>();
        }
        public void Add_Duration(Duration_of_Day d)
        {
            duration_Of_Days.Add(d);
        }

        public override string ToString()
        {
            return base.ToString() + "name is: " + name;

        }
    }
}
