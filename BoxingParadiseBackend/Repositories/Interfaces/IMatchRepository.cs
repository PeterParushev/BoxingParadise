using BoxingParadiseBackend.Models;

namespace BoxingParadiseBackend.Repositories.Interfaces
{
    public interface IMatchRepository
    {
        Match GetById(int id);

        void Persist(Match match);

        void DeleteById(int id);
    }
}