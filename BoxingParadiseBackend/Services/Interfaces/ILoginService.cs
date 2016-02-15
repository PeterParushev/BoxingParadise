using BoxingParadiseBackend.Models;
using System.Threading.Tasks;

namespace BoxingParadiseBackend.Services.Interfaces
{
    public interface ILoginService
    {
        Task<Login> Login(string username, string password);
    }
}