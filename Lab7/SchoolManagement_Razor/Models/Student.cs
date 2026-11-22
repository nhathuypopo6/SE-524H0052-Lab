using System;
using System.Collections.Generic;

namespace SchoolManagement_Razor.Models
{
    public partial class Student
    {
        public int StudentId { get; set; }
        public string LastName { get; set; } = null!;
        public string FirstMidName { get; set; } = null!;
        public DateTime EnrollmentDate { get; set; }

        public string FullName => $"{LastName} {FirstMidName}";
        public virtual ICollection<Enrollment> Enrollments { get; set; } = new List<Enrollment>();
    }
}
