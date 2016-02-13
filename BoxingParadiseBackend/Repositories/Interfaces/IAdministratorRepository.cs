namespace BoxingParadiseBackend.Repositories.Interfaces
{
    public interface IAdministratorRepository
    {
        bool IsProvidedAdministratorKeyValid(string key);
    }
}