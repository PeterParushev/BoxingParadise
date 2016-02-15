using AutoMapper;
using BoxingParadiseBackend.DTOs;
using BoxingParadiseBackend.Models;
using BoxingParadiseBackend.Repositories.Interfaces;
using BoxingParadiseBackend.Services.Interfaces;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BoxingParadiseBackend.Services
{
    public class BetService : IBetService
    {
        private readonly IBetRepository m_BetRepository;

        public BetService(IBetRepository betRepository)
        {
            m_BetRepository = betRepository;
        }

        public async Task<IList<BetDto>> GetBetsByUserId(int userId)
        {
            return
                (await m_BetRepository.GetBetsByUserId(userId).ConfigureAwait(false)).Select(
                    bet => Mapper.Map<BetDto>(bet)).ToList();
        }

        public async Task CreateBet(BetDto bet)
        {
            await m_BetRepository.Persist(Mapper.Map<Bet>(bet)).ConfigureAwait(false);
        }

        public async Task DeleteBet(int betId)
        {
            await m_BetRepository.CancelBet(betId).ConfigureAwait(false);
        }
    }
}