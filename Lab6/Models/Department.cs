using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Lab06_ASPNET_MVC.Models
{
    public class Department
    {
        public int DepartmentID { get; set; }
        [Required]
        [StringLength(50)]
        public string Name { get; set; }
        [Column(TypeName = "money")]
        public decimal Budget { get; set; }
        [DataType(DataType.Date)]
        public DateTime StartDate { get; set; }

        public virtual ICollection<Course> Courses { get; set; }
    }
}
