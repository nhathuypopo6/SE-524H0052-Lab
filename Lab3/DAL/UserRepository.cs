using System;
using System.Collections.Generic;
using System.Linq;

namespace DAL
{
    public class UserRepository
    {
        private readonly Exer1DbContext _context;

        public UserRepository()
        {
            _context = new Exer1DbContext();
        }

        public User ValidateUser(string username, string password)
        {
            return _context.Users.FirstOrDefault(u => u.Username == username && u.Password == password);
        }

        public User GetUserByUsername(string username)
        {
            return _context.Users.FirstOrDefault(u => u.Username == username);
        }

        public List<User> GetAllUsers()
        {
            return _context.Users.ToList();
        }

        public void AddUser(User user)
        {
            _context.Users.Add(user);
            _context.SaveChanges();
        }
    }
}
