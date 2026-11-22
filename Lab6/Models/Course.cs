using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Lab06_ASPNET_MVC.Models
{
    public class Course
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        [Display(Name = "Course Number")]
        public int CourseID { get; set; }
        [Required]
        [StringLength(100)]
        public string Title { get; set; }
        [Range(1, 5)]
        public int Credits { get; set; }
        public int DepartmentID { get; set; }

        public virtual Department Department { get; set; }
        public virtual ICollection<Enrollment> Enrollments { get; set; }
    }
}
