using BoxingParadiseBackend.DTOs;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BoxingParadiseBackend.Services.Interfaces
{
    public interface IBetService
    {
        Task<IList<BetDto>> GetBetsByUserId(int userId);

        Task PlaceBet(BetDto bet);

        Task CancelBet(int betId);

        Task CancelAllBetsForAMatch(int matchId);
    }
}