using System;

namespace DAL
{
    public class Student
    {
        public int Id { get; set; }
        public string StudentCode { get; set; }
        public string FullName { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string Gender { get; set; }
        public string Email { get; set; }
        public string Major { get; set; }
    }
}
