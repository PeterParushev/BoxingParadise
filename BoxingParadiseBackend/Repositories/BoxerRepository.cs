using BoxingParadiseBackend.Models;
using BoxingParadiseBackend.Repositories.Interfaces;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;

namespace BoxingParadiseBackend.Repositories
{
    public class BoxerRepository : IBoxerRepository
    {
        public async Task<IList<Boxer>> GetBoxers()
        {
            return await new DatabaseContext().Boxers.ToListAsync().ConfigureAwait(false);
        }

        public async Task Persist(Boxer boxer)
        {
            DatabaseContext context = new DatabaseContext();
            context.Boxers.Add(boxer);
            await context.SaveChangesAsync().ConfigureAwait(false);
        }

        public async Task Delete(int id)
        {
            DatabaseContext context = new DatabaseContext();
            context.Boxers.Remove(context.Boxers.FirstOrDefault(x => x.Id == id));
            await context.SaveChangesAsync().ConfigureAwait(false);
        }
    }
}