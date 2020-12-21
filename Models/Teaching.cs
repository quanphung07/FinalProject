using System;
using System.Collections.Generic;

namespace test1.Models
{
    public partial class Teaching
    {
        public string SubjectId { get; set; }
        public string LectureId { get; set; }

        public virtual Lecture Lecture { get; set; }
        public virtual Subject Subject { get; set; }
    }
}
