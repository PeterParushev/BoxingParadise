using BoxingParadiseBackend.Models;
using BoxingParadiseBackend.Repositories.Interfaces;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;

namespace BoxingParadiseBackend.Repositories
{
    public class VenueRepository : IVenueRepository
    {
        public async Task<IList<Venue>> GetVenues()
        {
            return await new DatabaseContext().Venues.ToListAsync().ConfigureAwait(false);
        }

        public async Task Delete(int id)
        {
            DatabaseContext context = new DatabaseContext();
            context.Venues.Remove(context.Venues.FirstOrDefault(x => x.Id == id));
            await context.SaveChangesAsync().ConfigureAwait(false);
            //context.Dispose();
        }

        public async Task Persist(Venue venue)
        {
            DatabaseContext context = new DatabaseContext();
            context.Venues.Add(venue);
            await context.SaveChangesAsync().ConfigureAwait(false);
            //context.Dispose();
        }

        public async Task<Venue> GetById(int id)
        {
            return await new DatabaseContext().Venues.FirstOrDefaultAsync(x => x.Id == id).ConfigureAwait(false);
        }
    }
}