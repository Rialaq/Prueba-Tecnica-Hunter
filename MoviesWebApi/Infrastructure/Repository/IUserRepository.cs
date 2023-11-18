using Domain.Models;

namespace Infrastructure.Repository
{
    public interface IUserRepository
    {
        void CreateUser(User user);
        User Login(string username, string password);
        IEnumerable<User>? GetUsers();
    }
}
