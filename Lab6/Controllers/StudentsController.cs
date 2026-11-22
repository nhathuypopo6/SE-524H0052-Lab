using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using Lab06_ASPNET_MVC.Models;

namespace Lab06_ASPNET_MVC.Controllers
{
    public class StudentsController : Controller
    {
        // Mock In-memory repository with MSSQL seeding for demo
        private static List<Student> _students = new List<Student>
        {
            new Student { StudentID = 1, LastName = "Nguyen", FirstMidName = "Nhat Huy", EnrollmentDate = DateTime.Parse("2023-09-05") },
            new Student { StudentID = 2, LastName = "On", FirstMidName = "Gia Khiem", EnrollmentDate = DateTime.Parse("2023-09-05") },
            new Student { StudentID = 3, LastName = "Vo", FirstMidName = "Nguyen Phuc Thinh", EnrollmentDate = DateTime.Parse("2023-09-05") },
            new Student { StudentID = 4, LastName = "Alexander", FirstMidName = "Carson", EnrollmentDate = DateTime.Parse("2022-09-01") }
        };

        // GET: Students
        public ActionResult Index(string searchString)
        {
            var students = from s in _students select s;
            if (!string.IsNullOrEmpty(searchString))
            {
                students = students.Where(s => s.LastName.Contains(searchString) || s.FirstMidName.Contains(searchString));
            }
            return View(students.ToList());
        }

        // GET: Students/Details/5
        public ActionResult Details(int id)
        {
            var student = _students.FirstOrDefault(s => s.StudentID == id);
            if (student == null) return HttpNotFound();
            return View(student);
        }

        // GET: Students/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Students/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Student student)
        {
            if (ModelState.IsValid)
            {
                student.StudentID = _students.Max(s => s.StudentID) + 1;
                _students.Add(student);
                return RedirectToAction("Index");
            }
            return View(student);
        }

        // GET: Students/Edit/5
        public ActionResult Edit(int id)
        {
            var student = _students.FirstOrDefault(s => s.StudentID == id);
            if (student == null) return HttpNotFound();
            return View(student);
        }

        // POST: Students/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Student student)
        {
            if (ModelState.IsValid)
            {
                var existing = _students.FirstOrDefault(s => s.StudentID == student.StudentID);
                if (existing != null)
                {
                    existing.LastName = student.LastName;
                    existing.FirstMidName = student.FirstMidName;
                    existing.EnrollmentDate = student.EnrollmentDate;
                }
                return RedirectToAction("Index");
            }
            return View(student);
        }

        // GET: Students/Delete/5
        public ActionResult Delete(int id)
        {
            var student = _students.FirstOrDefault(s => s.StudentID == id);
            if (student == null) return HttpNotFound();
            return View(student);
        }

        // POST: Students/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            var student = _students.FirstOrDefault(s => s.StudentID == id);
            if (student != null) _students.Remove(student);
            return RedirectToAction("Index");
        }
    }
}
