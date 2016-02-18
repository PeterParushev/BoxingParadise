using BoxingParadiseBackend.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BoxingParadiseBackend.Repositories.Interfaces
{
    public interface IVenueRepository
    {
        Task<IList<Venue>> GetVenues();

        Task Delete(int id);

        Task Persist(Venue venue);

        Task<Venue> GetById(int id);
    }
}