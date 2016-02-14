using BoxingParadiseBackend.Models;
using BoxingParadiseBackend.Repositories.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace BoxingParadiseBackend.Repositories
{
    public class BetRepository : IBetRepository
    {
        public IList<Bet> GetBetsByUserId(int userId)
        {
            return new BoxingParadiseContext().Bets.ToList();
        }

        public void Persist(Bet bet)
        {
            BoxingParadiseContext context = new BoxingParadiseContext();
            context.Bets.Add(bet);
            context.SaveChanges();
        }

        public void CancelBet(int betId)
        {
            BoxingParadiseContext context = new BoxingParadiseContext();
            var bet = context.Bets.FirstOrDefault(x => x.Id == betId);
            if (bet != null)
            {
                bet.Canceled = true;
            }

            context.SaveChanges();
        }

        public void CancelAllBetsForAMatch(int matchId)
        {
            BoxingParadiseContext context = new BoxingParadiseContext();
            context.Bets.Where(x => x.MatchId == matchId).ToList().ForEach(x => x.Canceled = true);
            context.SaveChanges();
        }
    }
}