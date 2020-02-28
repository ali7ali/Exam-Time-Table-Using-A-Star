using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartAlgoProject
{
    class F_State : IEquatable<F_State>
    {
        public Day Daay { get; set; }
        public Duration_of_Day Duuration { get; set; }
        public Course Coourse { get; set; }
        public Exam_Hall Exxam_Hall { get; set; }
        public Head_of_Hall heead_Of_Hall { get; set; }
        public Proctor_in_Hall seecret_Of_Hall { get; set; }
        public List<Proctor_in_Hall> prroctor_In_Hall { get; set; }

        public F_State(Day day, Duration_of_Day duration, Course course, Exam_Hall exam_Hall, Head_of_Hall head_Of_Hall, Proctor_in_Hall secret_Of_Hall, List<Proctor_in_Hall> proctor_In_Hall)
        {
            Daay = day ?? throw new ArgumentNullException(nameof(day));
            Duuration = duration ?? throw new ArgumentNullException(nameof(duration));
            Coourse = course ?? throw new ArgumentNullException(nameof(course));
            Exxam_Hall = exam_Hall ?? throw new ArgumentNullException(nameof(exam_Hall));
            this.heead_Of_Hall = head_Of_Hall ?? throw new ArgumentNullException(nameof(head_Of_Hall));
            this.seecret_Of_Hall = secret_Of_Hall ?? throw new ArgumentNullException(nameof(secret_Of_Hall));
            this.prroctor_In_Hall = proctor_In_Hall ?? throw new ArgumentNullException(nameof(proctor_In_Hall));
        }

        public override bool Equals(object obj)
        {
            return Equals(obj as F_State);
        }

        public bool Equals(F_State other)
        {
            return other != null &&
                   EqualityComparer<Day>.Default.Equals(Daay, other.Daay) &&
                   EqualityComparer<Duration_of_Day>.Default.Equals(Duuration, other.Duuration) &&
                   EqualityComparer<Course>.Default.Equals(Coourse, other.Coourse) &&
                   EqualityComparer<Head_of_Hall>.Default.Equals(heead_Of_Hall, other.heead_Of_Hall) &&
                   EqualityComparer<Proctor_in_Hall>.Default.Equals(seecret_Of_Hall, other.seecret_Of_Hall) &&
                   EqualityComparer<List<Proctor_in_Hall>>.Default.Equals(prroctor_In_Hall, other.prroctor_In_Hall);
        }

        public override int GetHashCode()
        {
            var hashCode = -1698505212;
            hashCode = hashCode * -1521134295 + EqualityComparer<Day>.Default.GetHashCode(Daay);
            hashCode = hashCode * -1521134295 + EqualityComparer<Duration_of_Day>.Default.GetHashCode(Duuration);
            hashCode = hashCode * -1521134295 + EqualityComparer<Course>.Default.GetHashCode(Coourse);
            hashCode = hashCode * -1521134295 + EqualityComparer<Head_of_Hall>.Default.GetHashCode(heead_Of_Hall);
            hashCode = hashCode * -1521134295 + EqualityComparer<Proctor_in_Hall>.Default.GetHashCode(seecret_Of_Hall);
            hashCode = hashCode * -1521134295 + EqualityComparer<List<Proctor_in_Hall>>.Default.GetHashCode(prroctor_In_Hall);
            return hashCode;
        }

        public void print(List<Proctor_in_Hall> proctor_In_Halls)
        {
            foreach(Proctor_in_Hall proctor_In_Hall in proctor_In_Halls)
            {
                Console.Write(" " + proctor_In_Hall.f_Name + " " + proctor_In_Hall.l_Name + " ");
            }   
        }
        public override string ToString()
        { 
            Console.Write( "Day: " + Daay.name + "   Duration: " + Duuration.Duration.ToString() + "   Course: " + Coourse.name + "   Head of Hall: " + heead_Of_Hall.F_Name + " " + heead_Of_Hall.L_Name + "   Secret of Hall: " + seecret_Of_Hall.f_Name + " "+ seecret_Of_Hall.l_Name + " Proctors: ");
            print(prroctor_In_Hall);
            Console.WriteLine();
            return base.ToString();
        }
        public static bool operator ==(F_State state1, F_State state2)
        {
            return EqualityComparer<F_State>.Default.Equals(state1, state2);
        }

        public static bool operator !=(F_State state1, F_State state2)
        {
            return !(state1 == state2);
        }
    }
}
