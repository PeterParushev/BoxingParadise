using AutoMapper;
using BoxingParadiseBackend.DTOs;
using BoxingParadiseBackend.Models;
using BoxingParadiseBackend.Repositories.Interfaces;
using BoxingParadiseBackend.Services.Interfaces;

namespace BoxingParadiseBackend.Services
{
    public class LoginService : ILoginService
    {
        private ILoginRepository m_LoginRepository;

        public LoginService(ILoginRepository loginRepository)
        {
            m_LoginRepository = loginRepository;
        }

        public string Login(UserDto user)
        {
            return m_LoginRepository.Login(Mapper.Map<User>(user));
        }
    }
}