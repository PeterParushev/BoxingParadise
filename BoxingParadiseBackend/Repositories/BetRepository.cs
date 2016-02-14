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
            return new DatabaseContext().Bets.ToList();
        }

        public void Persist(Bet bet)
        {
            DatabaseContext context = new DatabaseContext();
            context.Bets.Add(bet);
            context.SaveChanges();
        }

        public void CancelBet(int betId)
        {
            DatabaseContext context = new DatabaseContext();
            var bet = context.Bets.FirstOrDefault(x => x.Id == betId);
            if (bet != null)
            {
                bet.Canceled = true;
            }

            context.SaveChanges();
        }

        public void CancelAllBetsForAMatch(int matchId)
        {
            DatabaseContext context = new DatabaseContext();
            context.Bets.Where(x => x.MatchId == matchId).ToList().ForEach(x => x.Canceled = true);
            context.SaveChanges();
        }
    }
}