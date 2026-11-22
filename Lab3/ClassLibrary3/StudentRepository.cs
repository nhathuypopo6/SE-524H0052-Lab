using System.Collections.Generic;
using System.Linq;

namespace DAL
{
    public class StudentRepository
    {
        private readonly Exer1DbContext _context;

        public StudentRepository()
        {
            _context = new Exer1DbContext();
        }

        public void AddStudent(Student student)
        {
            _context.Students.Add(student);
            _context.SaveChanges();
        }

        public Student GetStudentById(int id)
        {
            return _context.Students.FirstOrDefault(s => s.Id == id);
        }

        public Student GetStudentByCode(string code)
        {
            return _context.Students.FirstOrDefault(s => s.StudentCode == code);
        }

        public List<Student> GetAllStudents()
        {
            return _context.Students.ToList();
        }

        public void UpdateStudent(Student student)
        {
            var existing = _context.Students.FirstOrDefault(s => s.Id == student.Id);
            if (existing != null)
            {
                existing.StudentCode = student.StudentCode;
                existing.FullName = student.FullName;
                existing.DateOfBirth = student.DateOfBirth;
                existing.Gender = student.Gender;
                existing.Email = student.Email;
                existing.Major = student.Major;
                _context.SaveChanges();
            }
        }

        public void DeleteStudent(int id)
        {
            var student = _context.Students.FirstOrDefault(s => s.Id == id);
            if (student != null)
            {
                _context.Students.Remove(student);
                _context.SaveChanges();
            }
        }
    }
}
