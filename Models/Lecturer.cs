using System;
using System.Collections.Generic;

namespace test1.Models
{
    public partial class Lecturer
    {
        public string LecturerId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime Dob { get; set; }
        public char? Gender { get; set; }
        public string Address { get; set; }
        public string Email { get; set; }
    }
}
