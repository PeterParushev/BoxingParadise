using AutoMapper;
using BoxingParadiseBackend.DTOs;
using BoxingParadiseBackend.Models;
using BoxingParadiseBackend.Repositories.Interfaces;
using BoxingParadiseBackend.Services.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace BoxingParadiseBackend.Services
{
    public class BetService : IBetService
    {
        private readonly IBetRepository m_BetRepository;

        public BetService(IBetRepository betRepository)
        {
            m_BetRepository = betRepository;
            Mapper.CreateMap<Bet, BetDto>();
            Mapper.CreateMap<BetDto, Bet>();
        }

        public IList<BetDto> GetBetsByUserId(int userId)
        {
            return m_BetRepository.GetBetsByUserId(userId).Select(bet => Mapper.Map<BetDto>(bet)).ToList();
        }

        public void PlaceBet(BetDto bet)
        {
            m_BetRepository.Persist(Mapper.Map<Bet>(bet));
        }

        public void CancelBet(int betId)
        {
            m_BetRepository.CancelBet(betId);
        }

        public void CancelAllBetsForAMatch(int matchId)
        {
            m_BetRepository.CancelAllBetsForAMatch(matchId);
        }
    }
}