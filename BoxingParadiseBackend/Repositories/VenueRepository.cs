using BoxingParadiseBackend.Models;
using BoxingParadiseBackend.Repositories.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace BoxingParadiseBackend.Repositories
{
    public class VenueRepository : IVenueRepository
    {
        public IList<Venue> GetVenues()
        {
            return new DatabaseContext().Venues.ToList();
        }

        public void Delete(int id)
        {
            DatabaseContext context = new DatabaseContext();
            context.Venues.Remove(context.Venues.FirstOrDefault(x => x.Id == id));
            context.SaveChanges();
        }

        public void Persist(Venue venue)
        {
            DatabaseContext context = new DatabaseContext();
            context.Venues.Add(venue);
            context.SaveChanges();
        }
    }
}