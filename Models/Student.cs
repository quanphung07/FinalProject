﻿using System;
using System.Collections.Generic;

namespace test1.Models
{
    public partial class Student
    {
        public Student()
        {
            Clazz = new HashSet<Clazz>();
            Enrollment = new HashSet<Enrollment>();
        }

        public string StudentId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime Dob { get; set; }
        public char? Gender { get; set; }
        public string Address { get; set; }
        public string Note { get; set; }
        public string ClazzId { get; set; }

        public virtual Clazz ClazzNavigation { get; set; }
        public virtual ICollection<Clazz> Clazz { get; set; }
        public virtual ICollection<Enrollment> Enrollment { get; set; }
    }
}
