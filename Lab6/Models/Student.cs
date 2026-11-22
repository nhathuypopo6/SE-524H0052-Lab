using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Lab06_ASPNET_MVC.Models
{
    public class Student
    {
        public int StudentID { get; set; }
        [Required]
        [Display(Name = "Last Name")]
        [StringLength(50)]
        public string LastName { get; set; }
        [Required]
        [Display(Name = "First / Mid Name")]
        [StringLength(50)]
        public string FirstMidName { get; set; }
        [DataType(DataType.Date)]
        [Display(Name = "Enrollment Date")]
        public DateTime EnrollmentDate { get; set; }

        public string FullName => $"{LastName} {FirstMidName}";
        public virtual ICollection<Enrollment> Enrollments { get; set; }
    }
}
