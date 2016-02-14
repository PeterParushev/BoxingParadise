using BoxingParadiseBackend.Repositories.Interfaces;
using System.Linq;

namespace BoxingParadiseBackend.Repositories
{
    public class AdministratorRepository : IAdministratorRepository
    {
        public bool IsProvidedAdministratorKeyValid(string key)
        {
            return new DatabaseContext().Administrators.Any(x => x.AdminKey == key);
        }
    }
}