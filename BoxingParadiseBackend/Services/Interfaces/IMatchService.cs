using BoxingParadiseBackend.DTOs;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BoxingParadiseBackend.Services.Interfaces
{
    public interface IMatchService
    {
        Task<MatchDto> GetMatchById(int id);

        Task SaveMatch(MatchDto matchDto, string adminKey);

        Task DeleteMatchById(int id, string adminKey);

        Task Cancel(int matchId, string adminKey);

        Task<IList<MatchDto>> GetMatches(int? take, int? skip, string query);
    }
}