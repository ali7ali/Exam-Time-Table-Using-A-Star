using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartAlgoProject
{
    enum Title{
        Dr = 0, Eng =1
    }
    class Head_of_Hall
    {
        public string F_Name, L_Name;
        public Title Title;
        public int Id;
        public int Hours;
        public Dictionary<Day, List<Duration_of_Day>> days;

        public  Head_of_Hall(string f_Name, string l_Name, Title title , int id, int hours)
        {
            this.F_Name = f_Name;
            this.L_Name = l_Name;
            this.Title = title;
            this.Id = id;
            this.Hours = hours;
            days = new Dictionary<Day, List<Duration_of_Day>>();
        }
        public void Add_Available(Day A, List<Duration_of_Day> du)
        {
            days.Add(A, du);
        }
        public Dictionary<Day, List<Duration_of_Day>> Days
        {

            get { return days; }
        }

    }

}
