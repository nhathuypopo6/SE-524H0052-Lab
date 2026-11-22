using System;
using System.Collections.Generic;
using DAL;

namespace BLL
{
    public class StudentService
    {
        private readonly StudentRepository _studentRepository;

        public StudentService()
        {
            _studentRepository = new StudentRepository();
        }

        public void AddStudent(Student student)
        {
            if (string.IsNullOrWhiteSpace(student.FullName))
            {
                throw new ArgumentException("Student full name cannot be empty!");
            }
            if (string.IsNullOrWhiteSpace(student.StudentCode))
            {
                throw new ArgumentException("Student code cannot be empty!");
            }

            var existing = _studentRepository.GetStudentByCode(student.StudentCode.Trim());
            if (existing != null)
            {
                throw new InvalidOperationException($"Student code '{student.StudentCode}' already exists!");
            }

            _studentRepository.AddStudent(student);
        }

        public Student GetStudent(int id)
        {
            return _studentRepository.GetStudentById(id);
        }

        public Student GetStudentByCode(string code)
        {
            return _studentRepository.GetStudentByCode(code);
        }

        public List<Student> GetAllStudents()
        {
            return _studentRepository.GetAllStudents();
        }

        public void UpdateStudent(Student student)
        {
            if (string.IsNullOrWhiteSpace(student.FullName))
            {
                throw new ArgumentException("Student full name cannot be empty!");
            }
            if (string.IsNullOrWhiteSpace(student.StudentCode))
            {
                throw new ArgumentException("Student code cannot be empty!");
            }
            _studentRepository.UpdateStudent(student);
        }

        public void DeleteStudent(int id)
        {
            _studentRepository.DeleteStudent(id);
        }
    }
}
