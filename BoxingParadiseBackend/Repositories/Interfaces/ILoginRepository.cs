using BoxingParadiseBackend.Models;

namespace BoxingParadiseBackend.Repositories.Interfaces
{
    public interface ILoginRepository
    {
        string Login(User user);
    }
}