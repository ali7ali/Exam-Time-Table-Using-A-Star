using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartAlgoProject
{
    class State
    {
       public Dictionary<Course, List<Exam_Hall>> keyValuePairs;

        public State(Dictionary<Course, List<Exam_Hall>> KeyValuePairs)
        {
            this.keyValuePairs = KeyValuePairs;
        }

        public Dictionary<Course, List<Exam_Hall>> K
        {
            set { keyValuePairs = value; }
            get { return keyValuePairs; }
        }

        public override bool Equals(object obj)
        {
            var state = obj as State;
            return state != null &&
                   EqualityComparer<Dictionary<Course, List<Exam_Hall>>>.Default.Equals(keyValuePairs, state.keyValuePairs) &&
                   EqualityComparer<Dictionary<Course, List<Exam_Hall>>>.Default.Equals(K, state.K);
        }

        public override int GetHashCode()
        {
            var hashCode = 1532282144;
            hashCode = hashCode * -1521134295 + EqualityComparer<Dictionary<Course, List<Exam_Hall>>>.Default.GetHashCode(keyValuePairs);
            hashCode = hashCode * -1521134295 + EqualityComparer<Dictionary<Course, List<Exam_Hall>>>.Default.GetHashCode(K);
            return hashCode;
        }
    }
}
