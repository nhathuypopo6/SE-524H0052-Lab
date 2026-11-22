using DAL;

namespace BLL
{
    public class UserService
    {
        private readonly UserRepository _repository;
        public UserService()
        {
            _repository = new UserRepository();
        }

        public bool Authenticate(string username, string password, out string role)
        {
            var user = _repository.ValidateUser(username, password);
            if (user != null)
            {
                role = user.Role;
                return true;
            }
            role = null;
            return false;
        }
    }
}
