using BoxingParadiseBackend.DTOs;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BoxingParadiseBackend.Services.Interfaces
{
    public interface IMatchService
    {
        Task<MatchDto> GetMatchById(int id);

        Task SaveMatch(MatchDto matchDto);

        Task DeleteMatchById(int id);

        Task<IList<MatchDto>> GetMatches(int? take, int? skip);

        Task Cancel(int matchId);

        Task<IList<MatchDto>> GetMatches(int? take, int? skip, string query);
    }
}