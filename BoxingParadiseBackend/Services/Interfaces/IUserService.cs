using BoxingParadiseBackend.DTOs;
using BoxingParadiseBackend.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BoxingParadiseBackend.Services.Interfaces
{
    public interface IUserService
    {
        Task<UserDto> GetUser(int id);

        Task CreateUser(UserDto user);

        Task DeleteUser(int userId);

        Task<IList<UserDto>> GetUser(int take, int skip);

        Task<UserDto> GetUser(string username);

        void UpdateUserRatings(Match match);
    }
}