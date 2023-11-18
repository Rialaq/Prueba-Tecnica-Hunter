using Domain.Models;

namespace Application
{
    public interface IUserServices
    {
        string Login(string username, string password);
        string GenerateToken(string username);
        void CreateUser(User user);
        IEnumerable<User> GetUsers();
    }
}
