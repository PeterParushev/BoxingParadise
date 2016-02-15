using BoxingParadiseBackend.Repositories.Interfaces;
using BoxingParadiseBackend.Services.Interfaces;
using System.Threading.Tasks;

namespace BoxingParadiseBackend.Services
{
    public class AdministratorService : IAdministratorService
    {
        private readonly IAdministratorRepository m_AdministratorRepository;

        public AdministratorService(IAdministratorRepository administratorRepository)
        {
            m_AdministratorRepository = administratorRepository;
        }

        public async Task<bool> IsProvidedAdministratorKeyValid(string key)
        {
            return await m_AdministratorRepository.IsProvidedAdministratorKeyValid(key).ConfigureAwait(false);
        }
    }
}