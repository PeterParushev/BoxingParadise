using BoxingParadiseBackend.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BoxingParadiseBackend.Repositories.Interfaces
{
    public interface IBoxerRepository
    {
        Task<IList<Boxer>> GetBoxers();

        Task Persist(Boxer boxer);

        Task Delete(int id);

        Task<Boxer> GetById(int id);
    }
}