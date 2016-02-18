using BoxingParadiseBackend.DTOs;
using BoxingParadiseBackend.Repositories.Interfaces;
using BoxingParadiseBackend.Services.Interfaces;
using BoxingParadiseBackend.Services.Mapping.Interface;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BoxingParadiseBackend.Services
{
    public class BetService : IBetService
    {
        private readonly IBetRepository m_BetRepository;
        private readonly IBetMapper m_BetMapper;

        public BetService(IBetRepository betRepository, IBetMapper betMapper)
        {
            m_BetRepository = betRepository;
            m_BetMapper = betMapper;
        }

        public async Task<IList<BetDto>> GetBetsByUserId(int userId)
        {
            return
                (await m_BetRepository.GetBetsByUserId(userId).ConfigureAwait(false)).Select(
                    bet => m_BetMapper.MapToDto(bet)).ToList();
        }

        public async Task CreateBet(BetDto bet)
        {
            await m_BetRepository.Persist(await m_BetMapper.MapFromDto(bet).ConfigureAwait(false)).ConfigureAwait(false);
        }

        public async Task DeleteBet(int betId)
        {
            await m_BetRepository.CancelBet(betId).ConfigureAwait(false);
        }
    }
}