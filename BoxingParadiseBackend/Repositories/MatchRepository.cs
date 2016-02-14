using BoxingParadiseBackend.Models;
using BoxingParadiseBackend.Repositories.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace BoxingParadiseBackend.Repositories
{
    public class MatchRepository : IMatchRepository
    {
        public Match GetById(int id)
        {
            return new BoxingParadiseContext().Matches.FirstOrDefault(x => x.Id == id);
        }

        public void Persist(Match match)
        {
            BoxingParadiseContext context = new BoxingParadiseContext();
            context.Matches.Add(match);
            context.SaveChanges();
        }

        public void DeleteById(int id)
        {
            BoxingParadiseContext context = new BoxingParadiseContext();
            context.Matches.Remove(context.Matches.FirstOrDefault(x => x.Id == id));
            context.SaveChanges();
        }

        public IList<Match> GetMatches(int count, int skip)
        {
            return new BoxingParadiseContext().Matches.ToList();
        }
    }
}