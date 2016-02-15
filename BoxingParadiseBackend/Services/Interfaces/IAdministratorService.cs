using System.Threading.Tasks;

namespace BoxingParadiseBackend.Services.Interfaces
{
    public interface IAdministratorService
    {
        Task<bool> IsProvidedAdministratorKeyValid(string key);
    }
}