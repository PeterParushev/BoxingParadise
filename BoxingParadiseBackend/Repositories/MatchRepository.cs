using BoxingParadiseBackend.Models;
using BoxingParadiseBackend.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;

namespace BoxingParadiseBackend.Repositories
{
    public class MatchRepository : IMatchRepository
    {
        private readonly IBetRepository m_BetRepository;

        public MatchRepository(IBetRepository betRepository)
        {
            m_BetRepository = betRepository;
        }

        public async Task<Match> GetById(int id)
        {
            return await new DatabaseContext().Matches.FirstOrDefaultAsync(x => x.Id == id).ConfigureAwait(false);
        }

        public async Task Persist(Match match)
        {
            using (DatabaseContext context = new DatabaseContext())
            {
                context.Matches.Add(match);
                await context.SaveChangesAsync().ConfigureAwait(false);
            }
        }

        public async Task DeleteById(int id)
        {
            DatabaseContext context = new DatabaseContext();

            var match = context.Matches.FirstOrDefault(x => x.Id == id);
            if (match != null)
            {
                match.Canceled = true;
            }

            await m_BetRepository.CancelAllBetsByMatchId(id).ConfigureAwait(false);

            await context.SaveChangesAsync().ConfigureAwait(false);
            //context.Dispose();
        }

        public async Task<IList<Match>> GetMatches(int? take, int? skip)
        {
            return await
                new DatabaseContext().Matches.Where(x => !x.Canceled && x.WinnerId == null)
                    .OrderBy(x => x.StartDate)
                    .Take(take.Value)
                    .Skip(skip.Value)
                    .Include("BoxerOne")
                    .Include("BoxerTwo")
                    .Include("Venue")
                    .Include("Winner")
                    .ToListAsync().ConfigureAwait(false);
        }

        public async Task Cancel(int matchId)
        {
            DatabaseContext context = new DatabaseContext();
            context.Bets.Where(x => x.MatchId == matchId).ToList().ForEach(x => x.Canceled = true);
            await context.SaveChangesAsync().ConfigureAwait(false);
        }

        public async Task<IList<Match>> GetMatches(int? take, int? skip, string searchWord)
        {
            DatabaseContext context = new DatabaseContext();

            IQueryable<Match> query = context.Matches.Where(x => !x.Canceled).OrderBy(x => x.StartDate);

            if (!string.IsNullOrEmpty(searchWord))
            {
                Boxer boxer = await context.Boxers.FirstOrDefaultAsync(x => x.Name == searchWord);
                Venue venue = await context.Venues.FirstOrDefaultAsync(x => x.Name == searchWord);

                if (boxer != null)
                {
                    query = venue != null
                        ? query.Where(x => x.BoxerOneId == boxer.Id || x.BoxerTwoId == boxer.Id || x.VenueId == venue.Id)
                        : query.Where(x => x.BoxerOneId == boxer.Id || x.BoxerTwoId == boxer.Id);
                }
                else if (venue != null)
                {
                    query = query.Where(x => x.VenueId == venue.Id);
                }
            }

            return await query.ToListAsync().ConfigureAwait(false);
        }
    }
}