using BoxingParadiseBackend.Models;
using System.Collections.Generic;

namespace BoxingParadiseBackend.Repositories.Interfaces
{
    public interface IUserRepository
    {
        User GetById(int id);

        void PersistUser(User user);

        void DeleteUser(int id);

        IList<User> GetUsers();
    }
}