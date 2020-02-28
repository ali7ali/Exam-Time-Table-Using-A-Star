using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartAlgoProject
{
    enum Rule
    {
        Emp=0,Master=1
    }
    class Proctor_in_Hall
    {
        public string f_Name, l_Name;
        public Rule rule;
        public int Id;
        public int Hours;
        public Dictionary<Day,List<Duration_of_Day>> days;
        public Proctor_in_Hall(string F_Name, string L_Name, Rule Rule, int id, int hours)
        {
            this.f_Name = F_Name;
            this.l_Name = L_Name;
            this.rule = Rule;
            this.Id = id;
            this.Hours = hours;
            days = new Dictionary<Day, List<Duration_of_Day>>();
        }
        public void Add_Available(Day A,List<Duration_of_Day> du)
        {
            days.Add(A,du);
        }
        public Dictionary<Day, List<Duration_of_Day>> Days
        {
            
            get { return days; }
        }

    }
}
