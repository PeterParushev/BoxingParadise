using BoxingParadiseBackend.DTOs;

namespace BoxingParadiseBackend.Services.Interfaces
{
    public interface IMatchService
    {
        MatchDto GetMatchById(int id);

        void SaveMatch(MatchDto match);

        void DeleteMatchById(int id);
    }
}