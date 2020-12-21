using System;
using System.Collections.Generic;

namespace test1.Models
{
    public partial class Clazz
    {
        public Clazz()
        {
            Student = new HashSet<Student>();
        }

        public string ClazzId { get; set; }
        public string Name { get; set; }
        public string LectureId { get; set; }
        public string MonitorId { get; set; }
        public int? NumberStd { get; set; }

        public virtual Lecture Lecture { get; set; }
        public virtual Student Monitor { get; set; }
        public virtual ICollection<Student> Student { get; set; }
    }
}
