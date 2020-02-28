using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartAlgoProject
{
    class Exam_Hall
    {
        public string Name;
        public int Capacity;
        public int Required_p;
        public int floor;

        public Exam_Hall(string Name, int Capacity ,int Required_p, int Floor)
        {
            this.Name = Name;
            this.Capacity = Capacity;
            this.floor = Floor;

            this.Required_p = Required_p;

        }
    }
}
