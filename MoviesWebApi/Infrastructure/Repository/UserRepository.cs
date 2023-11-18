using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repository
{
    public class UserRepository : IUserRepository
    {
        private readonly Context _context;

        public UserRepository(Context context)
        {
            _context = context;
        }

        public void CreateUser(User user)
        {
            _context.Users?.Add(user);
            _context.SaveChanges();
        }

        public IEnumerable<User>? GetUsers()
        {
            return _context.Users?.ToList();
        }

        public User Login(string username, string password)
        {
            var user = _context.Users?.Where(u => u.Username.ToLower() == username.ToLower() && u.Password == password).FirstOrDefault();
            if (user == null)
            {
                return null;
            }

            return user;
        }
    }
}
