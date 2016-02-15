using System.Threading.Tasks;

namespace BoxingParadiseBackend.Repositories.Interfaces
{
    public interface IAdministratorRepository
    {
        Task<bool> IsProvidedAdministratorKeyValid(string key);
    }
}