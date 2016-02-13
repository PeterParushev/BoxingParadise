using BoxingParadiseBackend.Models;
using System.Collections.Generic;

namespace BoxingParadiseBackend.Repositories.Interfaces
{
    public interface IBetRepository
    {
        IList<Bet> GetBetsByUserId(int userId);

        void Persist(Bet bet);

        void CancelBet(int betId);

        void CancelAllBetsForAMatch(int matchId);
    }
}