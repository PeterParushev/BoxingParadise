using BoxingParadiseBackend.Models;
using System.Threading.Tasks;

namespace BoxingParadiseBackend.Repositories.Interfaces
{
    public interface ILoginRepository
    {
        Task<Login> Login(string username, string password);
    }
}