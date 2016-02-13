using AutoMapper;
using BoxingParadiseBackend.DTOs;
using BoxingParadiseBackend.Models;
using BoxingParadiseBackend.Repositories.Interfaces;
using BoxingParadiseBackend.Services.Interfaces;

namespace BoxingParadiseBackend.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository m_UserRepository;

        public UserService(IUserRepository userRepository)
        {
            m_UserRepository = userRepository;
            Mapper.CreateMap<User, UserDto>();
            Mapper.CreateMap<UserDto, User>();
        }

        public UserDto GetById(int id)
        {
            return Mapper.Map<UserDto>(m_UserRepository.GetById(id));
        }

        public void SaveUser(UserDto user)
        {
            m_UserRepository.PersistUser(Mapper.Map<User>(user));
        }

        public void DeleteUser(int userId)
        {
            m_UserRepository.DeleteUser(userId);
        }
    }
}