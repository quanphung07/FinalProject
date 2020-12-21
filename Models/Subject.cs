using System;
using System.Collections.Generic;

namespace test1.Models
{
    public partial class Subject
    {
        public Subject()
        {
            Enrollment = new HashSet<Enrollment>();
            Teaching = new HashSet<Teaching>();
        }

        public string SubjectId { get; set; }
        public string Name { get; set; }
        public int Credit { get; set; }
        public int PercentageFinalExam { get; set; }

        public virtual ICollection<Enrollment> Enrollment { get; set; }
        public virtual ICollection<Teaching> Teaching { get; set; }
    }
}
