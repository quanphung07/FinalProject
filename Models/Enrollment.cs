using System;
using System.Collections.Generic;

namespace test1.Models
{
    public partial class Enrollment
    {
        public string StudentId { get; set; }
        public string SubjectId { get; set; }
        public string Semester { get; set; }
        public double? MidtermScore { get; set; }
        public double? FinalScore { get; set; }

        public virtual Student Student { get; set; }
        public virtual Subject Subject { get; set; }
    }
}
