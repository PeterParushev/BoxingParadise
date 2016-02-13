using BoxingParadiseBackend.DTOs;
using System.Collections.Generic;

namespace BoxingParadiseBackend.Services.Interfaces
{
    public interface IBetService
    {
        IList<BetDto> GetBetsByUserId(int userId);

        void PlaceBet(BetDto bet);

        void CancelBet(int betId);

        void CancelAllBetsForAMatch(int matchId);
    }
}