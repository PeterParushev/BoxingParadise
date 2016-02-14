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
            return new DatabaseContext().Matches.FirstOrDefault(x => x.Id == id);
        }

        public void Persist(Match match)
        {
            DatabaseContext context = new DatabaseContext();
            context.Matches.Add(match);
            context.SaveChanges();
        }

        public void DeleteById(int id)
        {
            DatabaseContext context = new DatabaseContext();
            context.Matches.Remove(context.Matches.FirstOrDefault(x => x.Id == id));
            context.SaveChanges();
        }

        public IList<Match> GetMatches(int? count, int? skip)
        {
            return new DatabaseContext().Matches.ToList();
        }
    }
}