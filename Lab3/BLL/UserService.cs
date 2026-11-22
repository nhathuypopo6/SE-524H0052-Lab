using System;
using System.Collections.Generic;
using DAL;

namespace BLL
{
    public class UserService
    {
        private readonly UserRepository _userRepository;

        public UserService()
        {
            _userRepository = new UserRepository();
        }

        public bool ValidateLogin(string username, string password, out User user)
        {
            user = null;
            if (string.IsNullOrWhiteSpace(username) || string.IsNullOrWhiteSpace(password))
            {
                return false;
            }

            user = _userRepository.ValidateUser(username.Trim(), password);
            return user != null;
        }

        public bool RegisterUser(User user, out string errorMessage)
        {
            errorMessage = string.Empty;
            if (string.IsNullOrWhiteSpace(user.Username))
            {
                errorMessage = "Username is required!";
                return false;
            }

            if (string.IsNullOrWhiteSpace(user.Password))
            {
                errorMessage = "Password is required!";
                return false;
            }

            var existing = _userRepository.GetUserByUsername(user.Username.Trim());
            if (existing != null)
            {
                errorMessage = "Username already exists!";
                return false;
            }

            _userRepository.AddUser(user);
            return true;
        }

        public List<User> GetAllUsers()
        {
            return _userRepository.GetAllUsers();
        }
    }
}
