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
                BoxerDto = Mapper.Map<BoxerDto>(bet.Boxer),
                MatchDto = m_MatchMapper.MapToDto(bet.Match),
                Id = bet.Id,
                UserDto = Mapper.Map<UserDto>(bet.User),
                Canceled = bet.Canceled
            };
        }

        public async Task<Bet> MapFromDto(BetDto betDto)
        {
            return new Bet
           {
               Boxer = await m_BoxerRepository.GetById(betDto.BoxerDto.Id).ConfigureAwait(false),
               Match = await m_MatchMapper.MapFromDto(betDto.MatchDto).ConfigureAwait(false),
               Id = betDto.Id,
               User = m_UserRepository.GetById(betDto.UserDto.Id).Result,
               Canceled = betDto.Canceled
           };
        }
    }
}