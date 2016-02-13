using BoxingParadiseBackend.Models;
using System.Collections.Generic;

namespace BoxingParadiseBackend.Repositories.Interfaces
{
    public interface IVenueRepository
    {
        IList<Venue> GetVenues();

        void Delete(int id);

        void Persist(Venue venue);
    }
}