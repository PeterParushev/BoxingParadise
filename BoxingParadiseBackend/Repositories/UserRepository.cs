using BoxingParadiseBackend.Models;
using BoxingParadiseBackend.Repositories.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace BoxingParadiseBackend.Repositories
{
    public class UserRepository : IUserRepository
    {
        public User GetById(int id)
        {
            return new DatabaseContext().Users.FirstOrDefault(x => x.Id == id);
        }

        public void PersistUser(User user)
        {
            DatabaseContext context = new DatabaseContext();
            context.Users.Add(user);
            context.SaveChanges();
        }

        public void DeleteUser(int id)
        {
            DatabaseContext context = new DatabaseContext();
            context.Users.Remove(context.Users.FirstOrDefault(x => x.Id == id));
            context.SaveChanges();
        }

        public IList<User> GetUsers()
        {
            return new DatabaseContext().Users.ToList();
        }
    }
}