using AutoMapper;
using BoxingParadiseBackend.DTOs;
using BoxingParadiseBackend.Models;
using BoxingParadiseBackend.Repositories.Interfaces;
using BoxingParadiseBackend.Services.Interfaces;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Http;

namespace BoxingParadiseBackend.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository m_UserRepository;

        public UserService(IUserRepository userRepository)
        {
            m_UserRepository = userRepository;
        }

        public async Task<UserDto> GetUser(int id)
        {
            return Mapper.Map<UserDto>(await m_UserRepository.GetById(id).ConfigureAwait(false));
        }

        public async Task CreateUser(UserDto user)
        {
            await m_UserRepository.PersistUser(Mapper.Map<User>(user)).ConfigureAwait(false);
        }

        public async Task DeleteUser(int userId)
        {
            await m_UserRepository.DeleteUser(userId).ConfigureAwait(false);
        }

        public async Task<IList<UserDto>> GetUser()
        {
            return
                (await m_UserRepository.GetUsers().ConfigureAwait(false)).Select(x => Mapper.Map<UserDto>(x)).ToList();
        }
    }
}