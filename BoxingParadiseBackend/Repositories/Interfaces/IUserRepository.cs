using BoxingParadiseBackend.Models;

namespace BoxingParadiseBackend.Repositories.Interfaces
{
    public interface IUserRepository
    {
        User GetById(int id);

        void PersistUser(User user);

        void DeleteUser(int userId);
    }
}