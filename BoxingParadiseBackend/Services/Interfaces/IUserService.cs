using BoxingParadiseBackend.DTOs;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BoxingParadiseBackend.Services.Interfaces
{
    public interface IUserService
    {
        Task<UserDto> GetUser(int id);

        Task CreateUser(UserDto user);

        Task DeleteUser(int userId);

        Task<IList<UserDto>> GetUser();
    }
}