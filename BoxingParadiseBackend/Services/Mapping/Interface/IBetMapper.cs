using BoxingParadiseBackend.DTOs;
using BoxingParadiseBackend.Models;
using System.Threading.Tasks;

namespace BoxingParadiseBackend.Services.Mapping.Interface
{
    public interface IBetMapper
    {
        BetDto MapToDto(Bet bet);

        Task<Bet> MapFromDto(BetDto betDto);
    }
}