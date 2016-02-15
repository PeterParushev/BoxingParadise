using BoxingParadiseBackend.Models;
using BoxingParadiseBackend.Repositories.Interfaces;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;

namespace BoxingParadiseBackend.Repositories
{
    public class MatchRepository : IMatchRepository
    {
        public async Task<Match> GetById(int id)
        {
            return await new DatabaseContext().Matches.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task Persist(Match match)
        {
            DatabaseContext context = new DatabaseContext();
            context.Matches.Add(match);
            await context.SaveChangesAsync().ConfigureAwait(false);
        }

        public async Task DeleteById(int id)
        {
            DatabaseContext context = new DatabaseContext();
            ;
            context.Matches.Remove(context.Matches.FirstOrDefault(x => x.Id == id));
            await context.SaveChangesAsync().ConfigureAwait(false);
        }

        public async Task<IList<Match>> GetMatches(int? count, int? skip)
        {
            return await
                new DatabaseContext().Matches.Include("BoxerOne")
                    .Include("BoxerTwo")
                    .Include("Venue")
                    .Include("Winner")
                    .ToListAsync().ConfigureAwait(false);
        }
    }
}