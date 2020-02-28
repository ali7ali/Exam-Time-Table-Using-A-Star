using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartAlgoProject
{

    enum Duration
    {
        First = 1, Second = 2, Third = 3
    }
    class Duration_of_Day
    {
        public Duration Duration;
        public Course Course;
        public List<Exam_Hall> Hall;



        public Duration_of_Day(Duration duration) 
        {
            Duration = duration;
            Hall = new List<Exam_Hall>();
        }
        public void Add_Hall(Exam_Hall hall)
        {
            Hall.Add(hall);
        }
    }
}
