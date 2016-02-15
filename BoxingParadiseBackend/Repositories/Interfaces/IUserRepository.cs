using BoxingParadiseBackend.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BoxingParadiseBackend.Repositories.Interfaces
{
    public interface IUserRepository
    {
        Task<User> GetById(int id);

        Task PersistUser(User user);

        Task DeleteUser(int id);

        Task<IList<User>> GetUsers(int take, int skip);

        Task<User> GetUserByUsername(string username);
    }
}