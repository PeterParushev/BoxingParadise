using BoxingParadiseBackend.Models;
using System.Collections.Generic;

namespace BoxingParadiseBackend.Repositories.Interfaces
{
    public interface IMatchRepository
    {
        Match GetById(int id);

        void Persist(Match match);

        void DeleteById(int id);

        IList<Match> GetMatches(int count, int skip);
    }
}