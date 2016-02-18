using BoxingParadiseBackend.DTOs;
using BoxingParadiseBackend.Models;
using System.Threading.Tasks;

namespace BoxingParadiseBackend.Services.Mapping.Interface
{
    public interface IMatchMapper
    {
        Task<Match> MapFromDto(MatchDto matchDto);

        MatchDto MapToDto(Match match);
    }
}