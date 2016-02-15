using BoxingParadiseBackend.DTOs;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BoxingParadiseBackend.Services.Interfaces
{
    public interface IUserService
    {
        Task<UserDto> GetById(int id);

        Task SaveUser(UserDto user);

        Task DeleteUser(int userId);

        Task<IList<UserDto>> GetUsers();
    }
}