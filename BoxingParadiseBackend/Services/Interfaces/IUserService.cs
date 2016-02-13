using BoxingParadiseBackend.DTOs;

namespace BoxingParadiseBackend.Services.Interfaces
{
    public interface IUserService
    {
        UserDto GetById(int id);

        void SaveUser(UserDto user);

        void DeleteUser(int userId);
    }
}
