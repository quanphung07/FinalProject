using System;
using System.Collections.Generic;

namespace test1.Models
{
    public partial class Lecture
    {
        public Lecture()
        {
            Clazz = new HashSet<Clazz>();
            Teaching = new HashSet<Teaching>();
        }

        public string LectureId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime? Dob { get; set; }
        public char? Gender { get; set; }
        public string Address { get; set; }
        public string Email { get; set; }

        public virtual ICollection<Clazz> Clazz { get; set; }
        public virtual ICollection<Teaching> Teaching { get; set; }
    }
}
