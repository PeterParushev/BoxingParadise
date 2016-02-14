using BoxingParadiseBackend.DTOs;

namespace BoxingParadiseBackend.Services.Interfaces
{
    public interface ILoginService
    {
        string Login(UserDto user);
    }
}