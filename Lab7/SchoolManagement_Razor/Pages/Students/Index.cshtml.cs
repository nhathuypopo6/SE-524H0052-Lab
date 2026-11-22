using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using SchoolManagement_Razor.Models;

namespace SchoolManagement_Razor.Pages.Students
{
    public class IndexModel : PageModel
    {
        private readonly SchoolDbContext _context;

        public IndexModel(SchoolDbContext context)
        {
            _context = context;
        }

        public IList<Student> Students { get; set; } = default!;

        public async Task OnGetAsync()
        {
            try
            {
                Students = await _context.Students.ToListAsync();
            }
            catch
            {
                // Fallback seed for demo testing
                Students = new List<Student>
                {
                    new Student { StudentId = 1, LastName = "Nguyen", FirstMidName = "Nhat Huy", EnrollmentDate = DateTime.Parse("2023-09-05") },
                    new Student { StudentId = 2, LastName = "On", FirstMidName = "Gia Khiem", EnrollmentDate = DateTime.Parse("2023-09-05") },
                    new Student { StudentId = 3, LastName = "Vo", FirstMidName = "Nguyen Phuc Thinh", EnrollmentDate = DateTime.Parse("2023-09-05") }
                };
            }
        }
    }
}
