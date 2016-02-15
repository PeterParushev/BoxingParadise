using BoxingParadiseBackend.Repositories.Interfaces;
using System.Data.Entity;
using System.Threading.Tasks;

namespace BoxingParadiseBackend.Repositories
{
    public class AdministratorRepository : IAdministratorRepository
    {
        public async Task<bool> IsProvidedAdministratorKeyValid(string key)
        {
            return await new DatabaseContext().Administrators.AnyAsync(x => x.AdminKey == key).ConfigureAwait(false);
        }
    }
}