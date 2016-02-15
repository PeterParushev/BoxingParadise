﻿using BoxingParadiseBackend.Models;
using BoxingParadiseBackend.Repositories.Interfaces;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;

namespace BoxingParadiseBackend.Repositories
{
    public class BetRepository : IBetRepository
    {
        public async Task<IList<Bet>> GetBetsByUserId(int userId)
        {
            return await new DatabaseContext().Bets.ToListAsync();
        }

        public async Task Persist(Bet bet)
        {
            DatabaseContext context = new DatabaseContext();
            context.Bets.Add(bet);
            await context.SaveChangesAsync().ConfigureAwait(false);
        }

        public async Task CancelBet(int betId)
        {
            DatabaseContext context = new DatabaseContext();
            var bet = context.Bets.FirstOrDefault(x => x.Id == betId);
            if (bet != null)
            {
                bet.Canceled = true;
            }

            await context.SaveChangesAsync().ConfigureAwait(false);
        }

        public async Task CancelAllBetsForAMatch(int matchId)
        {
            DatabaseContext context = new DatabaseContext();
            context.Bets.Where(x => x.Match.Id == matchId).ToList().ForEach(x => x.Canceled = true);
            await context.SaveChangesAsync().ConfigureAwait(false);
        }
    }
}