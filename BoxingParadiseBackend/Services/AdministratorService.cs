using BoxingParadiseBackend.Repositories.Interfaces;
using BoxingParadiseBackend.Services.Interfaces;

namespace BoxingParadiseBackend.Services
{
    public class AdministratorService : IAdministratorService
    {
        private readonly IAdministratorRepository m_AdministratorRepository;

        public AdministratorService(IAdministratorRepository administratorRepository)
        {
            m_AdministratorRepository = administratorRepository;
        }

        public bool IsProvidedAdministratorKeyValid(string key)
        {
            return m_AdministratorRepository.IsProvidedAdministratorKeyValid(key);
        }
    }
}