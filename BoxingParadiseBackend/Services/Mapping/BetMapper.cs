using AutoMapper;
using BoxingParadiseBackend.DTOs;
using BoxingParadiseBackend.Models;
using BoxingParadiseBackend.Repositories.Interfaces;
using BoxingParadiseBackend.Services.Mapping.Interface;
using System.Threading.Tasks;

namespace BoxingParadiseBackend.Services.Mapping
{
    public class BetMapper : IBetMapper
    {
        private readonly IBoxerRepository m_BoxerRepository;
        private readonly IUserRepository m_UserRepository;
        private readonly IMatchMapper m_MatchMapper;

        public BetMapper(IBoxerRepository boxerRepository, IUserRepository userRepository, IMatchMapper matchMapper)
        {
            m_BoxerRepository = boxerRepository;
            m_UserRepository = userRepository;
            m_MatchMapper = matchMapper;
        }

        public BetDto MapToDto(Bet bet)
        {
            return new BetDto
            {
                BoxerId = bet.BoxerId,
                MatchId = bet.MatchId,
                Id = bet.Id,
                UserId = bet.UserId,
                Canceled = bet.Canceled
            };
        }

        public async Task<Bet> MapFromDto(BetDto betDto)
        {
            return new Bet
           {
               BoxerId = betDto.BoxerId,
               MatchId = betDto.MatchId,
               Id = betDto.Id,
               UserId = betDto.UserId,
               Canceled = betDto.Canceled
           };
        }
    }
}