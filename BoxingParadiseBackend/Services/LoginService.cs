using BoxingParadiseBackend.Models;
using BoxingParadiseBackend.Repositories.Interfaces;
using BoxingParadiseBackend.Services.Interfaces;
using System.Threading.Tasks;

namespace BoxingParadiseBackend.Services
{
    public class LoginService : ILoginService
    {
        private readonly ILoginRepository m_LoginRepository;

        public LoginService(ILoginRepository loginRepository)
        {
            m_LoginRepository = loginRepository;
        }

        public async Task<Login> Login(string username, string password)
        {
            return await m_LoginRepository.Login(username, password).ConfigureAwait(false);
        }
    }
}