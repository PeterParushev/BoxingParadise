using BoxingParadiseBackend.DTOs;
using System.Collections.Generic;

namespace BoxingParadiseBackend.Services.Interfaces
{
    public interface IMatchService
    {
        MatchDto GetMatchById(int id);

        void SaveMatch(MatchDto match);

        void DeleteMatchById(int id);

        IList<MatchDto> GetMatches(int count, int skip);
    }
}