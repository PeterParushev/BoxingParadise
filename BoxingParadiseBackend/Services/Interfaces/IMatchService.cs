using BoxingParadiseBackend.DTOs;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BoxingParadiseBackend.Services.Interfaces
{
    public interface IMatchService
    {
        Task<MatchDto> GetMatchById(int id);

        Task SaveMatch(MatchDto match);

        Task DeleteMatchById(int id);

        Task<IList<MatchDto>> GetMatches(int? count, int? skip);

        Task Cancel(int matchId);
    }
}